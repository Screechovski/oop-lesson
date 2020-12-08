using System;

namespace lab4
{
    class CypressTrees
    {
        private string type = "shrubby";
        public string GetType
        {
            get { return type; }
            set { type = value; }
        }
    }
    class ConiferousTrees : CypressTrees
    {
        private string leafType = "needleLike";
        private string crownColor = "green";

        public string GetLeafType
        {
            get { return leafType; }
            set { leafType = value; }
        }

        public string GetCrownColor
        {
            get { return crownColor; }
            set { crownColor = value; }
        }
    }
    class Wood : ConiferousTrees
    {
        private float woodHeight;
        private int woodAge;
        public Wood (float _height, int _age)
        {
            woodHeight = _height;
            woodAge = _age;
        }

        public float GetWoodHeight
        {
            get { return woodHeight; }
            set { woodHeight = value; }
        }

        public int GetWoodAge
        {
            get { return woodAge; }
            set { woodAge = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wood thujaTree = new Wood(20.75f, 5);

            Console.WriteLine(thujaTree.GetType);
            Console.WriteLine(thujaTree.GetLeafType);
            Console.WriteLine(thujaTree.GetWoodAge);

            Console.Read();
        }
    }
}
