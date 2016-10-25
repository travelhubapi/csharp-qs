using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace QueryString
{
    public class QS
    {
        public static string Stringify(object obj, string prefix = "")
        {
            var result = _stringify(obj, prefix);
            var query = result.Remove(result.Length - 1);
            return query;
        }

        private static string _stringify(object obj, string prefix = "", string format = "{0}={1}&")
        {
            if (obj == null)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            var type = obj.GetType();
            var typeName = type.Name;
            var genericEnumerableInterface = type.GetInterfaces().FirstOrDefault(
                                  i => i.IsGenericType &&
                                      i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
            var isIterable = genericEnumerableInterface != null && typeName != "String";

            if (isIterable)
            {
                var i = 0;
                foreach (var item in (IEnumerable)obj)
                {
                    var itemType = item.GetType();
                    if (!itemType.IsPrimitive && itemType.Name != "String")
                    {
                        var properties = itemType.GetProperties();
                        foreach (var prop in properties)
                        {
                            var propValue = prop.GetValue(item);
                            var propType = prop.PropertyType;
                            var _format = string.IsNullOrEmpty(prefix) ? "{1}[{2}]" : "{0}[{1}][{2}]";
                            result.Append(_stringify(propValue, string.Format(_format, prefix, i, prop.Name), format));
                        }
                    }
                    else
                    {
                        typeName = string.Empty;
                        result.Append(string.Format("{0}[{1}]={2}&", prefix, i, item));
                    }

                    i++;
                }
            }
            else if (type.IsPrimitive || type.IsEnum || typeName == "String")
            {
                result.Append(string.Format(format, prefix, obj));
            }
            else
            {
                var properties = type.GetProperties();
                foreach (var prop in properties)
                {
                    var propValue = prop.GetValue(obj);
                    var propType = prop.PropertyType;
                    var p = string.IsNullOrEmpty(prefix) ? prefix : prefix + ".";
                    result.Append(_stringify(propValue, p + prop.Name, format));
                }
            }

            var query = result.ToString();
            return query;
        }
    }
}
