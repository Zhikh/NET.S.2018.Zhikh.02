using System;
using NUnit.Framework;

namespace Logic.Task2.NUnitTests
{
    [TestFixture]
    public class DigitWorkerTests
    {
        [Test]
        public void Filter_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => DigitWorker.FilterDivision(1, new IntContain(), null));

        [Test]
        public void Filter_WithExampleValues_ReturnExprctedArray()
        {
            int[] array = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int value = 7;
            int[] expected = { 7, 7, 70, 17 };

            int[] actual = DigitWorker.FilterDivision(value, new IntContain(), array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_WithNegativeValue_ReturnExprctedArray()
        {
            int[] array = { -7, 1, 2, 3, 5, 6, 7, 68, 69, 70, 15, 17 };
            int value = 7;
            int[] expected = { -7, 7, 70, 17 };

            int[] actual = DigitWorker.FilterDivision(value, new IntContain(), array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_WithLongValues_ReturnExprctedArray()
        {
            int[] array = { -700, 551, 20005, 300, 135, 633389, 7324687, 11, 64569, 70, 15, 173333, 112 };
            int value = 5;
            int[] expected = { 551, 20005, 135, 64569, 15 };

            int[] actual = DigitWorker.FilterDivision(value, new IntContain(), array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_WithoutValue_ReturnEmptyArray()
        {
            int[] array = { 7, 1, 2, 3, 5, 6, 7, 68, 69, 70, 15, 17 };
            int value = 4;
            int[] expected = { };

            int[] actual = DigitWorker.FilterDivision(value, new IntContain(), array);

            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
