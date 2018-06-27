using System;
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
        public void Filter_WithNull_ThrowArgumentNullException()
            => DigitWorker.Filter(null, 1);

        [TestMethod]
        public void Filter_WithIntValues_ReturnExampleResult()
        {
            int[] array = { 3, 56, 456, 234, 7, 98, 5 };
            int value = 5;

            int[] expected = { 56, 456, 5 };

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
        
        [DataSource("System.Data.SqlClient", @"Data Source=DESKTOP-7HKSO63\SQLEXPRESS;Initial Catalog=NET.S.2018.Zhikh.02;integrated security=True;Pooling=False", "FilterTestData", DataAccessMethod.Sequential)]
        [TestMethod]
        public void FromDataSourceTest()
        {
            string elementsFromDb = TestContext.DataRow["Element"].ToString();
            int[] elements = ParseToIntArray(elementsFromDb);

            int value;
            if (int.TryParse(TestContext.DataRow["CheckValue"].ToString(), out value))
            {
                string expectedFromDb = TestContext.DataRow["Expected"].ToString();
                int[] expected = ParseToIntArray(expectedFromDb);

                int[] actual = DigitWorker.Filter(elements, value);

                CollectionAssert.AreEqual(expected, actual);
            }
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
