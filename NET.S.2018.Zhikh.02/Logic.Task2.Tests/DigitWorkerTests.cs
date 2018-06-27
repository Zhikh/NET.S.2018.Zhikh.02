using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Task2.Tests
{
    [TestClass]
    public class DigitWorkerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Filter_WithNull_ThrowArgumentNullException()
            => DigitWorker.Filter(null, 1);

        [TestMethod]
        public void Filter_WithIntValues_ReturnExampleResult()
        {
            int[] array = {3, 56, 456, 234, 7, 98, 5};
            int value = 5;

            int[] expected = { 56, 456,5 };

            int[] actual = DigitWorker.Filter(array, value);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Filter_WithDoubleValues_ReturnExampleResult()
        {
            double[] array = { 14.1, 57.89, 2, 4, 12.3, 65.4, 0.12, 54.3, -32.1, -20.12, 5.1, 10.11 };
            double value = 0.1;

            double[] expected = { 0.12, -20.12, 10.11 };

            double[] actual = DigitWorker.Filter(array, value);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
