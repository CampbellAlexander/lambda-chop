using Microsoft.VisualStudio.TestTools.UnitTesting;
using LambdaChop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChopTests
{
    [TestClass()]
    public class FilterTests
    {

        [TestMethod()]
        public void FilterArray_EmptyArray_ReturnsEmptyArray()
        {
            object[] emptyArray = new object[0];
            object[] filtered = emptyArray.Filter(o => true);
            if (filtered.Length != 0) Assert.Fail();
        }

        [TestMethod()]
        public void FilterArray_ArrayOf1FalseTestedIfTrue_ReturnsEmptyArray()
        {
            bool[] oneFalse = new bool[1] { false };
            bool[] filtered = oneFalse.Filter(o => o);
            if (filtered.Length != 0) Assert.Fail();
        }

        [TestMethod()]
        public void FilterArray_ArrayOf2FalsesTestedIfTrue_ReturnsEmptyArray()
        {
            bool[] oneFalse = new bool[2] { false, false };
            bool[] filtered = oneFalse.Filter(o => o);
            if (filtered.Length != 0) Assert.Fail();
        }

        [TestMethod()]
        public void FilterArray_ArrayOf1TrueTestedIfTrue_ReturnsArrayOf1True()
        {
            bool[] oneFalse = new bool[1] { true };
            bool[] filtered = oneFalse.Filter(o => o);
            if (filtered[0] != true) Assert.Fail();
        }

        [TestMethod()]
        public void FilterArray_ArrayOf1True1FalseTestedIfTrue_ReturnsArrayOf1True()
        {
            bool[] oneFalse = new bool[2] { true, false };
            bool[] filtered = oneFalse.Filter(o => o);
            if (filtered.Length != 1 || filtered[0] != true)
                Assert.Fail();
        }

        [TestMethod()]
        public void FilterArray_ArrayOfIntsTestedIfGreaterThanZero_ReturnsCorrectArrayInCorrectOrder()
        {
            int[] ints = new int[5] { 2, -6, 1009, int.MinValue, int.MaxValue };
            int[] filtered = ints.Filter(i => i > 0);
            if (filtered[0] != 2 ||
                filtered[1] != 1009 ||
                filtered[2] != int.MaxValue ||
                filtered.Length != 3)
            {
                Assert.Fail();
            }
        }
        

        [TestMethod()]
        public void FilterArray_ArrayOfObjects123TestedIfOjbect1_Returns1Array()
        {
            object obj1 = new object();
            object obj2 = new object();
            object obj3 = new object();
            object[] objs = new object[3] { obj1, obj2, obj3 };

            object[] filtered = objs.Filter(o => obj1.Equals(o));

            if (filtered.Length != 1 || filtered[0] != obj1)
                Assert.Fail();
        }

        [TestMethod()]
        public void FilterArray_ArrayOfObjects123123123TestedIfOjbect1_Returns111Array()
        {
            object obj1 = new object();
            object obj2 = new object();
            object obj3 = new object();
            object[] objs = new object[9]
            {
                obj1, obj2, obj3, obj1, obj2, obj3, obj1, obj2, obj3
            };

            object[] filtered = objs.Filter(o => obj1.Equals(o));

            if (filtered.Length != 3
                || filtered[0] != obj1
                || filtered[1] != obj1
                || filtered[2] != obj1)
            {
                Assert.Fail();
            }
        }







        [TestMethod()]
        public void pFilterArray_EmptyArray_ReturnsEmptyArray()
        {
            object[] emptyArray = new object[0];
            object[] filtered = emptyArray.pFilter(o => true);
            if (filtered.Length != 0) Assert.Fail();
        }

        [TestMethod()]
        public void pFilterArray_ArrayOf1FalseTestedIfTrue_ReturnsEmptyArray()
        {
            bool[] oneFalse = new bool[1] { false };
            bool[] filtered = oneFalse.pFilter(o => o);
            if (filtered.Length != 0) Assert.Fail();
        }

        [TestMethod()]
        public void pFilterArray_ArrayOf2FalsesTestedIfTrue_ReturnsEmptyArray()
        {
            bool[] oneFalse = new bool[2] { false, false };
            bool[] filtered = oneFalse.pFilter(o => o);
            if (filtered.Length != 0) Assert.Fail();
        }

        [TestMethod()]
        public void pFilterArray_ArrayOf1TrueTestedIfTrue_ReturnsArrayOf1True()
        {
            bool[] oneFalse = new bool[1] { true };
            bool[] filtered = oneFalse.pFilter(o => o);
            if (filtered[0] != true) Assert.Fail();
        }

        [TestMethod()]
        public void pFilterArray_ArrayOf1True1FalseTestedIfTrue_ReturnsArrayOf1True()
        {
            bool[] oneFalse = new bool[2] { true, false };
            bool[] filtered = oneFalse.pFilter(o => o);
            if (filtered.Length != 1 || filtered[0] != true)
                Assert.Fail();
        }

        [TestMethod()]
        public void pFilterArray_ArrayOfIntsTestedIfGreaterThanZero_ReturnsArrayWithCorrectItems()
        {
            int[] ints = new int[5] { 2, -6, 1009, int.MinValue, int.MaxValue };
            int[] filtered = ints.pFilter(i => i > 0);
            if (!filtered.Contains(2) ||
                !filtered.Contains(1009) ||
                !filtered.Contains(int.MaxValue) ||
                filtered.Length != 3)
            {
                Assert.Fail();
            }
        }


        [TestMethod()]
        public void pFilterArray_ArrayOfObjects123TestedIfOjbect1_ReturnsCorrectArray()
        {
            object obj1 = new object();
            object obj2 = new object();
            object obj3 = new object();
            object[] objs = new object[3] { obj1, obj2, obj3 };

            object[] filtered = objs.pFilter(o => obj1.Equals(o));

            if (filtered.Length != 1 || filtered[0] != obj1)
                Assert.Fail();
        }

        [TestMethod()]
        public void pFilterArray_ArrayOfObjects123123123TestedIfOjbect1_ReturnsCorrectArray()
        {
            object obj1 = new object();
            object obj2 = new object();
            object obj3 = new object();
            object[] objs = new object[9]
            {
                obj1, obj2, obj3, obj1, obj2, obj3, obj1, obj2, obj3
            };

            object[] filtered = objs.pFilter(o => obj1.Equals(o));

            if (filtered.Length != 3
                || filtered[0] != obj1
                || filtered[1] != obj1
                || filtered[2] != obj1)
            {
                Assert.Fail();
            }
        }

    }
}
