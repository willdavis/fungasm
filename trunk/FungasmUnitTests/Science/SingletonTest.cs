using Fungasm.Science;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FungasmUnitTests
{
    
    
    /// <summary>
    ///This is a test class for SingletonTest and is intended
    ///to contain all SingletonTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SingletonTest
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
        ///A test for Init
        ///</summary>
        public void InitTestHelper<T>()
            where T : Singleton<T>
        {
            T newInstance = default(T); // TODO: Initialize to an appropriate value
            Singleton_Accessor<T>.Init(newInstance);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        [DeploymentItem("Fungasm.dll")]
        public void InitTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call InitTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Initialised
        ///</summary>
        public void InitialisedTestHelper<T>()
            where T : Singleton<T>
        {
            bool actual;
            actual = Singleton_Accessor<T>.Initialised;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("Fungasm.dll")]
        public void InitialisedTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call InitialisedTestHelper<T>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for UniqueInstance
        ///</summary>
        public void UniqueInstanceTestHelper<T>()
            where T : Singleton<T>
        {
            T actual;
            actual = Singleton_Accessor<T>.UniqueInstance;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [DeploymentItem("Fungasm.dll")]
        public void UniqueInstanceTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call UniqueInstanceTestHelper<T>() with appropriate type parameters.");
        }
    }
}
