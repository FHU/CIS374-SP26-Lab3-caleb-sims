using System;
using Lab3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnionFindUnitTests
    {
        [TestMethod]
        public void TestUnion() 
        {
            string[] elements = {"a", "b", "c", "d"};

            var uf = new UnionFind<string>(elements);
            uf.Union("a","b");
            Assert.AreEqual(true, uf.Connected("a", "b"));
            Assert.AreEqual(false, uf.Connected("a", "c"));
            Assert.AreEqual(false, uf.Connected("a", "d"));
            uf.Union("b","c");
        }
    
    }
}