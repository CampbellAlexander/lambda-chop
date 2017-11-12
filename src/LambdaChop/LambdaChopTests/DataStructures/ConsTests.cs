using Microsoft.VisualStudio.TestTools.UnitTesting;
using LambdaChop.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaChop.DataStructures.Tests
{
    [TestClass()]
    public class ConsTests
    {
        [TestMethod()]
        public void IsEmpty_NewCons_ReturnsTrue()
        {
            if (new Cons<int>().IsEmpty != true)
                Assert.Fail();
        }

        [TestMethod()]
        public void IsEmpty_Add1_ReturnsFalse()
        {
            if (new Cons<int>().Add(0).IsEmpty == true)
                Assert.Fail();
        }

        [TestMethod()]
        public void IsEmpty_Add2_ReturnsFalse()
        {
            if (new Cons<int>().Add(0).Add(0).IsEmpty == true)
                Assert.Fail();
        }
    }
}