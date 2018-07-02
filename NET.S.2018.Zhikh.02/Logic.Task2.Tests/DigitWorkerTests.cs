using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Task2.Tests
{
    [TestClass]
    public class DigitWorkerTests
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterDivision_WithNull_ThrowArgumentNullException()
            => DigitWorker.FilterDivision(1, null);

        [TestMethod]
        public void FilterDivision_WithIntValues_ReturnExampleResult()
        {
            int[] array = { 3, 56, 456, 234, 7, 98, 5 };
            int value = 5;

            int[] expected = { 56, 456, 5 };

            int[] actual = DigitWorker.FilterDivision(value, array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [DataSource("System.Data.SqlClient", @"Data Source=DESKTOP-7HKSO63\SQLEXPRESS;Initial Catalog=NET.S.2018.Zhikh.02;integrated security=True;Pooling=False", "FilterTestData", DataAccessMethod.Sequential)]
        [TestMethod]
        public void FilterDivision_FromDataSource_ReturnDataSourceResult()
        {
            string elementsFromDb = TestContext.DataRow["Element"].ToString();
            int[] elements = ParseToIntArray(elementsFromDb);

            int value;
            if (int.TryParse(TestContext.DataRow["CheckValue"].ToString(), out value))
            {
                string expectedFromDb = TestContext.DataRow["Expected"].ToString();
                int[] expected = ParseToIntArray(expectedFromDb);

                int[] actual = DigitWorker.FilterDivision(value, elements);

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void FilterDivision_FilterString_BigValues_DivisionTimeLess()
        {
            int[] array = GenerateIntValues(10000, 10);
            int value = 2;

            var stopwatch = new Stopwatch();

            stopwatch.Start();
            DigitWorker.FilterDivision(value, array);
            stopwatch.Stop();

            long divisionTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            DigitWorker.FilterString(value, array);
            stopwatch.Stop();

            long stringTime = stopwatch.ElapsedMilliseconds;

            bool isBigger = false;

            if(stringTime < divisionTime)
            {
                isBigger = true;
            }

            Assert.IsFalse(isBigger);
        }

        private int[] GenerateIntValues(int n, int range)
        {
            var result = new int[n];
            var rng = new Random(range);

            for (int i = 0; i < n; ++i)
            {
                result[i] = rng.Next();
            }

            return result;
        }

        private int[] ParseToIntArray(string str)
        {
            string pattern = @"\d+";

            Regex reg = new Regex(pattern);
            MatchCollection m = reg.Matches(str);

            int[] array = new int[m.Count];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(m[i].Value);
            }

            return array;
        }
    }
}
