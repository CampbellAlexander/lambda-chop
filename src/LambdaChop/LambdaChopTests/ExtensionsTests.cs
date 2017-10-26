using Microsoft.VisualStudio.TestTools.UnitTesting;
using LambdaChop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChop.Tests
{

    [TestClass()]
    public class ExtensionsTests
    {
        private readonly object[] empty = new object[0];
        private readonly int[] zeros = new int[5] { 0, 0, 0, 0, 0 };
        private readonly int[] ones = new int[5] { 1, 1, 1, 1, 1 };
        private readonly int[] twos = new int[5] { 2, 2, 2, 2, 2 };

        private T Identity<T>(T item) => item;
        private int Square(int x) => x * x;

        [TestMethod()]
        public void Map_EmptyArray_ReturnsNewEmptyArray()
        {
            object[] output = empty.Map(Identity);

            if (output.Length != 0)
                Assert.Fail();
        }

        [TestMethod()]
        public void Map_SquareAll0s_NewArrayAll0s()
        {
            int[] output = zeros.Map(Square);

            foreach (int i in output)
                if (i != 0)
                    Assert.Fail();
        }

        [TestMethod()]
        public void Map_SquareAll1s_NewArrayAll1s()
        {
            int[] output = ones.Map(Square);

            foreach (int i in output)
                if (i != 1)
                    Assert.Fail();
        }

        [TestMethod()]
        public void Map_SquareAll2s_NewArrayAll4s()
        {
            int[] output = twos.Map(Square);

            foreach (int i in output)
                if (i != 4)
                    Assert.Fail();
        }
    }
}