using Fungasm.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FungasmUnitTests
{
    
    
    /// <summary>
    ///This is a test class for ITaskTest and is intended
    ///to contain all ITaskTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ITaskTest
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


        internal virtual ITask CreateITask()
        {
            // TODO: Instantiate an appropriate concrete class.
            ITask target = null;
            return target;
        }

        /// <summary>
        ///A test for OnResume
        ///</summary>
        [TestMethod()]
        public void OnResumeTest()
        {
            ITask target = CreateITask(); // TODO: Initialize to an appropriate value
            target.OnResume();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for OnSuspend
        ///</summary>
        [TestMethod()]
        public void OnSuspendTest()
        {
            ITask target = CreateITask(); // TODO: Initialize to an appropriate value
            target.OnSuspend();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Start
        ///</summary>
        [TestMethod()]
        public void StartTest()
        {
            ITask target = CreateITask(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Start();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Stop
        ///</summary>
        [TestMethod()]
        public void StopTest()
        {
            ITask target = CreateITask(); // TODO: Initialize to an appropriate value
            target.Stop();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            ITask target = CreateITask(); // TODO: Initialize to an appropriate value
            double elapsedTime = 0F; // TODO: Initialize to an appropriate value
            target.Update(elapsedTime);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for CanKill
        ///</summary>
        [TestMethod()]
        public void CanKillTest()
        {
            ITask target = CreateITask(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.CanKill = expected;
            actual = target.CanKill;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Priority
        ///</summary>
        [TestMethod()]
        public void PriorityTest()
        {
            ITask target = CreateITask(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            target.Priority = expected;
            actual = target.Priority;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
