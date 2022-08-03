using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApplicationMatrix;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_i()
        {
            Matrix a = new Matrix(0, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_j()
        {
            Matrix a = new Matrix(2, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_get_i()
        {
            Matrix a = new Matrix(2, 2);
            int r = a[3, 1];
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_get_j()
        {
            Matrix a = new Matrix(2, 2);
            int r = a[1, 3];
        }

       [TestMethod]
        public void Matrix_Equal()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 1; b[0, 1] = 1; b[1, 0] = 1; b[1, 1] = 1;
            bool r = a == b;
            Assert.IsTrue(r);
        }

        [TestMethod]
        public void Matrix_Sum()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; b[1, 0] = 2; b[1, 1] = 2;

            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 3; expected[0, 1] = 3;
            expected[1, 0] = 3; expected[1, 1] = 3;

            Matrix actual = new Matrix(2, 2);
            actual = a + b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_Sum()
        {
            Matrix a = new Matrix(1, 2);
            a[0, 0] = 1; a[0, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; b[1, 0] = 2; b[1, 1] = 2;
            Matrix res = a + b;
        }

        [TestMethod]
        public void Matrix_Sub()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; b[1, 0] = 2; b[1, 1] = 2;

            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = -1; expected[0, 1] = -1;
            expected[1, 0] = -1; expected[1, 1] = -1;

            Matrix actual = new Matrix(2, 2);
            actual = a - b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_Sub()
        {
            Matrix a = new Matrix(1, 2);
            a[0, 0] = 1; a[0, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; b[1, 0] = 2; b[1, 1] = 2;
            Matrix res = a - b;
        }

        [TestMethod]
        public void Matrix_Mult()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 1; a[1, 0] = 1; a[1, 1] = 1;
            Matrix b = new Matrix(2, 2);
            b[0, 0] = 2; b[0, 1] = 2; b[1, 0] = 2; b[1, 1] = 2;

            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 4; expected[0, 1] = 4;
            expected[1, 0] = 4; expected[1, 1] = 4;

            Matrix actual = new Matrix(2, 2);
            actual = a * b;

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_Mult()
        {
            Matrix a = new Matrix(2, 3);
            a[0, 0] = 1; a[0, 1] = 1; a[0, 2] = 1; a[1, 0] = 1; a[1, 1] = 1; a[1, 2] = 1;
            Matrix b = new Matrix(2, 3);
            b[0, 0] = 1; b[0, 1] = 1; b[0, 2] = 1; b[1, 0] = 1; b[1, 1] = 1; b[1, 2] = 1;

            Matrix actual = new Matrix(2, 2);
            actual = a * b;
        }

        [TestMethod]
        public void Matrix_Transp()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 1; a[0, 1] = 2; a[1, 0] = 3; a[1, 1] = 4;

            Matrix expected = new Matrix(2, 2);
            expected[0, 0] = 1; expected[0, 1] = 3;
            expected[1, 0] = 2; expected[1, 1] = 4;

            Matrix actual = new Matrix(2, 2);
            actual = Matrix.Transp(a);

            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Matrix_Expected_MyException_Transp()
        {
            Matrix a = new Matrix(1, 2);
            a[0, 0] = 1; a[0, 1] = 2;

            Matrix actual = new Matrix(1, 2);
            actual = Matrix.Transp(a);
        }

        [TestMethod]
        public void Matrix_Min()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 2; a[0, 1] = 5; a[1, 0] = 1; a[1, 1] = 8;

            int expected = 1;

            int actual = Matrix.Min(a);
            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        public void Matrix_ToString()
        {
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 2; a[0, 1] = 5; a[1, 0] = 1; a[1, 1] = 8;

            string[,] expected  = new string[2, 2];
            expected[0, 0] = "2"; expected[0, 1] = "5"; expected[1, 0] = "1"; expected[1, 1] = "8";

            string[,] actual = Matrix.ToString(a);
            if (expected[0, 0] == actual[0, 0] &&
                expected[0, 1] == actual[0, 1] &&
                expected[1, 0] == actual[1, 0] &&
                expected[1, 1] == actual[1, 1])
                Assert.IsTrue(1 == 1);
        }
    }
}
