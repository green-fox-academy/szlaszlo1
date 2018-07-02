using System;
using NUnit.Framework;
using PokerTDD;

namespace UnitTestProjectPoker
{
    [TestFixture]
    public class UnitTest1
    {
        Calculation c;

        [SetUp]
        public void SetUp()
        {
            c = new Calculation();
        }
        [TestCase("2")]
        public void GetValue2(string s)
        {
            
            int output = c.GetValue(s);
            Assert.AreEqual(2, output);
        }
        [TestCase("3")]
        public void GetVaue3(string s)
        {
            int output = c.GetValue(s);
            Assert.AreEqual(3, output);
        }


        [TestCase("J")]
        public void GetValueJ(string s)
        {
            int output = c.GetValue(s);
            Assert.AreEqual(11, output);
        }

        [TestCase("Q")]
        public void GetValueQ(string s)
        {
            int output = c.GetValue(s);
            Assert.AreEqual(12, output);
        }

        [TestCase("K")]
        public void GetValueK(string s)
        {
            int output = c.GetValue(s);
            Assert.AreEqual(13, output);
        }

        [TestCase("A")]
        public void GetValueA(string s)
        {
            int output = c.GetValue(s);
            Assert.AreEqual(14, output);
        }

        [TestCase("2H")]
        public void GetCardWithoutSymbol(string s)
        {
            int output = c.GetValue(s);
            Assert.AreEqual(2, output);
        }
    }
}
