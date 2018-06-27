using System;
using System.Collections;
using NUnit.Framework;

namespace Logic.Task1.NUnitTests
{
    [TestFixture]
    class BitWorkerTests
    {
        [Test]
        public void Insert_WithIndexMoreThanMaxIntSize_ThrowArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => BitWorker.Insert(1, 1, 0, 34));

        [Test]
        public void GreetingMethod_WithNegativeIndex_ThrowArgumentOutOfRangeException()
            => Assert.Throws<ArgumentOutOfRangeException>(() => BitWorker.Insert(1, 1, -8, 34));

        [Test]
        public void Insert_WithUsingOfJLessThanI_ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => BitWorker.Insert(1, 1, 6, 5));

        [TestCase(-255, 69, 2, 6, ExpectedResult = -235)]
        public int Insert_WithNegativeValue_ReturnCorrectResult(int numberSource, int numberIn, int i, int j)
                => BitWorker.Insert(numberSource, numberIn, i, j);

        [Test, TestCaseSource(typeof(DataForTests), nameof(DataForTests.TestCases))]
        public int nsert_InsertValuesFromExample_ReturnResultFromExample(int numberSource, int numberIn, int i, int j) 
            => BitWorker.Insert(numberSource, numberIn, i, j);
    }

    public class DataForTests
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(15, 15, 0, 0).Returns(15);
                yield return new TestCaseData(8, 15, 0, 0).Returns(9);
                yield return new TestCaseData(8, 15, 3, 8).Returns(120);
            }
        }
    }
}
