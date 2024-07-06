using QueryString.Tests.Objects;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;


namespace QueryString.Tests
{

    public class QSTest
    {
        public QSTest() { 
            
        }

        [Trait("QS", "")]
        [Trait("QS - Stringify", "Person")]
        [Fact(DisplayName = "QS - Stringify Person")]
        public void Should_Stringify_Person_Obj()
        {
            var person = new Person("Harry", 20);
            string query = QS.Stringify(person);
            query.Should().Be("Name=Harry&Age=20");
        }

        [Trait("QS", "")]
        [Trait("QS - Stringify", "Array")]
        [Fact(DisplayName = "QS - Stringify Object with Array")]
        public void Should_Stringify_Object_With_Array()
        {
            var fruitsBasket = new FruitsBasket();
            fruitsBasket.Fruits = new string[] { 
                "Orange",
                "Lemon"
            };
            string query = QS.Stringify(fruitsBasket);
            query.Should().Be("Fruits[0]=Orange&Fruits[1]=Lemon");
        }

        [Trait("QS", "")]
        [Trait("QS - Stringify", "Nested")]
        [Fact(DisplayName = "QS - Stringify Nested")]
        public void Should_Stringify_Nested_Obj()
        {
            var father = new Father("Harry", 20);
            father.Child = new Person("Bob", 5);
            string query = QS.Stringify(father);
            query.Should().Be("Child.Name=Bob&Child.Age=5&Name=Harry&Age=20");
        }

        [Trait("QS", "")]
        [Trait("QS - Stringify", "Nested")]
        [Trait("QS - Stringify", "Array")]
        [Fact(DisplayName = "QS - Stringify Nested With Array")]
        public void Should_Stringify_Nested_Obj_With_Array()
        {
            var mother = new Mother("Angela", 32);
            mother.Children = new Person[] {
                new Person("Bob", 5),
                new Person("Ste", 6),
            };
            string query = QS.Stringify(mother);
            var expected = "Children[0][Name]=Bob&Children[0][Age]=5&Children[1][Name]=Ste&Children[1][Age]=6&Name=Angela&Age=32";
            query.Should().Be(expected);
        }

        [Trait("QS", "")]
        [Trait("QS - Stringify", "Prefix")]
        [Fact(DisplayName = "QS - Stringify Object With Prefix")]
        public void Should_Stringify_Obj_With_Prefix()
        {
            var room = new RoomParameter();
            room.Adt = 5;
            room.Chd = 2;
            room.ChdAges = new List<short> {
                5, 6
            };
            room.Snr = 1;
            string query = QS.Stringify(room, "room");
            var expected = "room.Snr=1&room.Adt=5&room.Chd=2&room.ChdAges[0]=5&room.ChdAges[1]=6";
            query.Should().Be(expected);
        }

        [Trait("QS", "")]
        [Trait("QS - Stringify", "Prefix")]
        [Trait("QS - Stringify", "Array")]
        [Fact(DisplayName = "QS - Stringify Array")]
        public void Should_Stringify_Array()
        {
            var rooms = new List<RoomParameter>();
            var room = new RoomParameter();
            room.Adt = 5;
            room.Chd = 2;
            room.ChdAges = new List<short> {
                5, 6
            };
            room.Snr = 1;
            rooms.Add(room);
            rooms.Add(room);
            string query = QS.Stringify(rooms);
            var expected = "0[Snr]=1&0[Adt]=5&0[Chd]=2&0[ChdAges][0]=5&0[ChdAges][1]=6&1[Snr]=1&1[Adt]=5&1[Chd]=2&1[ChdAges][0]=5&1[ChdAges][1]=6";
            query.Should().Be(expected);
        }

        [Trait("QS", "")]
        [Trait("QS - Stringify", "Prefix")]
        [Trait("QS - Stringify", "Array")]
        [Fact(DisplayName = "QS - Stringify Array With Prefix")]
        public void Should_Stringify_Array_With_Prefix()
        {
            var rooms = new List<RoomParameter>();
            var room = new RoomParameter();
            room.Adt = 5;
            room.Chd = 2;
            room.ChdAges = new List<short> {
                5, 6
            };
            room.Snr = 1;
            rooms.Add(room);
            rooms.Add(room);
            string query = QS.Stringify(rooms, "rooms");
            var expected = "rooms[0][Snr]=1&rooms[0][Adt]=5&rooms[0][Chd]=2&rooms[0][ChdAges][0]=5&rooms[0][ChdAges][1]=6&rooms[1][Snr]=1&rooms[1][Adt]=5&rooms[1][Chd]=2&rooms[1][ChdAges][0]=5&rooms[1][ChdAges][1]=6";

            query.Should().Be(expected);
        }
    }
}
