using System;

namespace lab4
{
    class Wood
    {
        protected float height;
        protected float width;

        public void SetHeight(float _h)
        {
            this.height = _h;
        }
        public void SetWidth(float _w)
        {
            this.width = _w;
        }
    }
    class ConiferousTrees : Wood
    {
        protected string type = "conifers";

        public string GetTypeWood()
        {
            return this.type;
        }
    }

    class CypressTrees : ConiferousTrees
    {
        protected Boolean bushplant = true;

        public Boolean GetBushplant()
        {
            return this.bushplant;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wood classicWood = new Wood();
            ConiferousTrees coniferousWood = new ConiferousTrees();
            CypressTrees cypressWood = new CypressTrees();

            classicWood.SetHeight(50f);

            coniferousWood.SetWidth(20f);
            Console.WriteLine(coniferousWood.GetTypeWood());

            cypressWood.SetHeight(155f);
            Console.WriteLine(cypressWood.GetTypeWood());
            Console.WriteLine(cypressWood.GetBushplant());

            Console.Read();
        }
    }
}
