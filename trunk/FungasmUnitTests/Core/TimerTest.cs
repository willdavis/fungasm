using Fungasm.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FungasmUnitTests
{
    
    
    /// <summary>
    ///This is a test class for TimerTest and is intended
    ///to contain all TimerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TimerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Timer Constructor
        ///</summary>
        [TestMethod()]
        public void TimerConstructorTest()
        {
            Timer target = new Timer();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetElapsedTime
        ///</summary>
        [TestMethod()]
        public void GetElapsedTimeTest()
        {
            Timer target = new Timer(); // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.GetElapsedTime();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for QueryPerformanceCounter
        ///</summary>
        [TestMethod()]
        public void QueryPerformanceCounterTest()
        {
            long PerformanceCount = 0; // TODO: Initialize to an appropriate value
            long PerformanceCountExpected = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = Timer.QueryPerformanceCounter(ref PerformanceCount);
            Assert.AreEqual(PerformanceCountExpected, PerformanceCount);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for QueryPerformanceFrequency
        ///</summary>
        [TestMethod()]
        public void QueryPerformanceFrequencyTest()
        {
            long PerformanceFrequency = 0; // TODO: Initialize to an appropriate value
            long PerformanceFrequencyExpected = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = Timer.QueryPerformanceFrequency(ref PerformanceFrequency);
            Assert.AreEqual(PerformanceFrequencyExpected, PerformanceFrequency);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
