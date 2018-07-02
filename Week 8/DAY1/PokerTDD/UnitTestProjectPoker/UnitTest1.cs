using System;
using NUnit.Framework;
using PokerTDD;

namespace UnitTestProjectPoker
{
    [TestFixture]
    public class UnitTest1
    {
        Calculation c = new Calculation();
        [Test]
        public void CheckIfSplitInputIs12()
        {
            string input = "Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C AH";
            bool output = c.CheckLength(input);
            Assert.AreEqual(true, output);
        }

        [Test]
        public void CheckHighHand()
        {
            string input = "Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C AH";
            string output = c.HighHand(input);
            Assert.AreEqual("White wins", output);
        }
    }
}
