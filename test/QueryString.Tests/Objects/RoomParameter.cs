using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryString.Tests.Objects
{
    public class RoomParameter
    {
        #region Propriedades
        /// <summary>
        /// Gets or sets the number of seniors in the accommodation.
        /// </summary>
        public short Snr { get; set; }

        /// <summary>
        /// Gets or sets the number of adults in the accommodation.
        /// </summary>
        public short Adt { get; set; }

        /// <summary>
        /// Gets or sets the number of children in the accommodation.
        /// </summary>
        public short Chd { get; set; }

        /// <summary>
        /// Gets or sets the children age.
        /// </summary>
        public List<short> ChdAges { get; set; }

        /// <summary>
        /// Gets or sets the type of bed in the room.
        /// </summary>
        //public virtual Bed Bed { get; set; }
        #endregion
    }
}
