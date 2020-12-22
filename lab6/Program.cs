using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    abstract class Figure
    {
        public string name;
        public double a;
        public double b;

        public Figure()
        {
            name = "Квадрат";
            a = 5;
            b = 5;
        }

        public virtual double GetSurfaceArea()
        {
            return a * b;
        }
    }


    class Cube : Figure
    {
        public Cube (double _a)
        {
            a = _a;
            name = "Куб";
        }

        public override double GetSurfaceArea()
        {
            return a * a * 6;
        }
    }

    class Tetrahedron : Figure
    {
        public Tetrahedron(double _a)
        {
            a = _a;
            name = "Тетраэдр";
        }

        public override double GetSurfaceArea()
        {
            return a * a * Math.Sqrt(3);
        }
    }

    class Ball : Figure
    {
        public double r;

        public Ball(float _r)
        {
            r = _r;
            name = "Шар";
        }

        public override double GetSurfaceArea()
        {
            return 4 * Math.PI * r * r;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ball ball1 = new Ball(5);
            Tetrahedron tetrahedron1 = new Tetrahedron(5.6);
            Cube cube1 = new Cube(7.14);

            Console.WriteLine(ball1.GetSurfaceArea()); //314,159265358979
            Console.WriteLine(tetrahedron1.GetSurfaceArea()); //54,31711332536
            Console.WriteLine(cube1.GetSurfaceArea()); //305,8776

            Console.Read();
        }
    }
}
