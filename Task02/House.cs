using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    public class House : ICloneable
    {
        private Street street;
        public Street Street
        {
            get { return street; }
            set { street = value; }
        }

        private HouseNumber number;
        public HouseNumber  Number
        {
            get { return number; }
            set { number = value; }
        }

        private PostIndex index;
        public PostIndex Index
        {
            get { return index; }
            set { index = value; }
        }

        public House(string streetName, int houseNumber, int postIndex)
        {
            Street = new Street(streetName);
            Number = new HouseNumber(houseNumber);
            Index = new PostIndex() { Index = postIndex };
        }
        

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public object DeepClone()
        {
            House house = this.MemberwiseClone() as House;
            house.Street = new Street(Street.Name);
            house.Number = new HouseNumber(Number.Number);
            return house;
        }
    }

    public class Street
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Street(string streetName)
        {
            Name = streetName;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class HouseNumber
    {
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public HouseNumber(int number)
        {
            Number = number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }

    public struct PostIndex
    {
        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public override string ToString()
        {
            return Index.ToString();
        }
    }
}
