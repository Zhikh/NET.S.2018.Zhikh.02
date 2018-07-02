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

    }
}
