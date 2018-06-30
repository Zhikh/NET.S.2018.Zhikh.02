using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Task1.Tests
{
    [TestClass]
    public class BitWorkerTests
    {
        [TestMethod]
        public void Insert_InsertTwoValuesOFIntDefaultValue_ReturnIntDefaultValue()
        {
            int defaultValue = 0;
            int expected = 0;

            int actual = BitWorker.Insert(defaultValue, defaultValue, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_InsertWithUsingOfNegativeFirtsIndex_ThrowArgumentOutOfRangeException()
            => BitWorker.Insert(1, 1, -1, 34);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_InsertWithUsingOfNegativeLastIndex_ThrowArgumentOutOfRangeException()
            => BitWorker.Insert(1, 1, 0, -34);

        [TestMethod]
        public void Insert_InsertWithMaxValue_ReturnResultValueFromExample()
        {
            int expected = 1;

            int actual = BitWorker.Insert(int.MaxValue, 0, 1, 30);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Insert_InsertWithUsingOfIndexMoreThanMaxIntSize_ThrowArgumentOutOfRangeException()
            => BitWorker.Insert(1, 1, 0, 34);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_InsertWithUsingOfJLessThanI_ThrowArgumentException()
            => BitWorker.Insert(1, 1, 10, 2);

        [TestMethod]
        public void Insert_InsertTwoValuesFromFirstExample_ReturnResultValueFromExample()
        {
            int expected = 15;

            int actual = BitWorker.Insert(15, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_InsertTwoValuesFromSecondExample_ReturnResultValueFromExample()
        {
            int expected = 9;

            int actual = BitWorker.Insert(8, 15, 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_InsertTwoValuesFromThirdExample_ReturnResultValueFromExample()
        {
            int expected = 120;

            int actual = BitWorker.Insert(8, 15, 3, 8);

            Assert.AreEqual(expected, actual);
        }
    }
}
