using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix matrix1 = new MyMatrix(2, -3, 1, 5);

            Console.WriteLine(matrix1.MatrixDeterminant());

            Console.Read();
        }
    }

    class MyMatrix : IOperations
    {
        public Matrix myMatrix;
        public MyMatrix (float a, float b, float c, float d)
        {
            myMatrix = new Matrix(a, b, c, d);
        }
        public float MatrixDeterminant()
        {
            return myMatrix.Determinant();
        }
    }

    class Matrix
    {
        private float a11;
        private float a21;
        private float a12;
        private float a22;

        public Matrix(float _a11, float _a21, float _a12, float _a22)
        {
            this.a11 = _a11;
            this.a21 = _a21;
            this.a12 = _a12;
            this.a22 = _a22;
        }

        public float Determinant()
        {
            return (a11 * a22) - (a21 * a12);
        }
    }

    interface IOperations
    {
        float MatrixDeterminant();
    }
}
