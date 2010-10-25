using Fungasm.Science;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FungasmUnitTests
{
    
    
    /// <summary>
    ///This is a test class for Singleton_SingletonFactoryTest and is intended
    ///to contain all Singleton_SingletonFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class Singleton_SingletonFactoryTest
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
        ///A test for SingletonFactory Constructor
        ///</summary>
        public void Singleton_SingletonFactoryConstructorTestHelper<T>()
            where T : Singleton<T>
        {
            Singleton_Accessor<T>.SingletonFactory target = new Singleton_Accessor<T>.SingletonFactory();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod()]
        [DeploymentItem("Fungasm.dll")]
        public void Singleton_SingletonFactoryConstructorTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of T. " +
                    "Please call Singleton_SingletonFactoryConstructorTestHelper<T>() with appropriat" +
                    "e type parameters.");
        }
    }
}
