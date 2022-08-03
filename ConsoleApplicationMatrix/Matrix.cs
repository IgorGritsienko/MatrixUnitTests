using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationMatrix
{
    public class MyException : Exception { public MyException(string s) : base(s) { } }
    public class Matrix
    {
        int[,] m;
        //Свойство для работы с числом строк.
        public int J { get; set; }

        //Свойство для работы с числом столбцов.
        public int I { get; set; }

        //Конструктор.
        public Matrix(int i, int j)
        {
            if (i <= 0) throw new 
                    MyException(string.Format("недопустимое значение i = {0}", i));
            if (j <= 0) throw new
                    MyException(string.Format("недопустимое значение j = {0}", j));
            I = i;
            J = j;
            m = new int[i, j];
        }
        
        //Индексатор для доступа к значениям компонентов матрицы.
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 | i > I - 1) throw new
                        MyException(string.Format("неверное значение i = {0}", i));
                if (j < 0 | j > J - 1) throw new
                        MyException(string.Format("неверное значение j = {0}", j));
                return m[i, j];
            }
            set
            {
                if (i < 0 | i > I - 1) throw new
                        MyException(string.Format("неверное значение i = {0}", i));
                if (j < 0 | j > J - 1) throw new
                        MyException(string.Format("неверное значение j = {0}", j));
                m[i, j] = value;
            }
        }

        public static Matrix operator +(Matrix a, Matrix b) 
        {
            if (a.I != b.I || a.J != b.J) throw new 
                    MyException(string.Format("неверные размерности матрицы"));

            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++) 
                for (int j = 0; j < a.J; j++)
                {
                    c[i, j] = a.m[i, j] + b.m[i, j]; 
                }
            return c;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.I != b.I || a.J != b.J) throw new
                    MyException(string.Format("Неверные размерности матрицы"));

            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                {
                    c[i, j] = a.m[i, j] - b.m[i, j];
                }
            return c;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.J != b.I) throw new
                    MyException(string.Format("Неверные размерности матриц"));

            Matrix c = new Matrix(a.I, a.J);
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < b.J; k++)
                        c[i, j] += a.m[i, k] * b.m[k, j];
                }
            return c;
        }

        public static bool operator ==(Matrix a, Matrix b) 
        {
            bool q = true; 
            for (int i = 0; i < a.I; i++) 
                for (int j = 0; j < a.J; j++) 
                {
                    if (a[i, j] != b[i, j])
                    {
                        q = false; break; 
                    }
                } 
            return q;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        public static Matrix Transp(Matrix a)
        {
            Matrix c = new Matrix(a.I, a.J);
            if (a.I != a.J) throw new
                   MyException(string.Format("матрица для транспонирования должна быть квадратной."));
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                    c[j, i] = a.m[i, j];
            return c;
        }

        public static int Min(Matrix a)
        {
            int min = a.m[0, 0];
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                    if (a.m[i, j] < min)
                        min = a.m[i, j];
            return min;
        }

        public static string[,] ToString(Matrix a)
        {
            string[,] str = new string[a.I, a.J];
            for (int i = 0; i < a.I; i++)
                for (int j = 0; j < a.J; j++)
                    str[i, j] = a[i, j].ToString();
            return str;
        }

        public override bool Equals(object obj)
        {
            return (this as Matrix) == (obj as Matrix);
        }
    }
}
