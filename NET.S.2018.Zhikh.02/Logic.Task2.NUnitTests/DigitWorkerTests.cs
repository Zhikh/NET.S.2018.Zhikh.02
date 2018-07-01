using System;
using NUnit.Framework;

namespace Logic.Task2.NUnitTests
{
    [TestFixture]
    public class DigitWorkerTests
    {
        [Test]
        public void Filter_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => DigitWorker.FilterDivision(1, null));

        [Test]
        public void Filter_WithExampleValues_ReturnExampleResult()
        {
            int[] array = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int value = 7;
            int[] expected = { 7, 7, 70, 17 };

            int[] actual = DigitWorker.FilterDivision(value, array);

            CollectionAssert.AreEqual(expected, actual);
        }

        //[Test]
        //public void Filter_WithDoubleValues_ReturnCorrectResult()
        //{
        //    double[] array = { 0.4, 0.3, 2.5, 7, 6.56, 87.9874, 5.6, 3.6, 56.89 };
        //    int value = 56;
        //    double[] expected = { 6.56, 56.89 };

        //    double[] actual = DigitWorker.Filter(array, value);

        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[Test]
        //public void Filter_WithIntValues_ReturnIncorrectResult()
        //{
        //    double[] array = { 4, 67, 56, 3, 5, 8, 9, 0, 32, 54, 11 };
        //    int value = 6;
        //    double[] expected = { 67 };

        //    double[] actual = DigitWorker.Filter(array, value);

        //    CollectionAssert.AreNotEqual(expected, actual);
        //}
    }
}
