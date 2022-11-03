using Framework.DriverCore;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;


namespace CoreFramework.NunitTestSetUp
{
    public class NunitTestSetUp
    {
        protected IWebDriver? _driver;

        [SetUp]
        public void Setup()
        {
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
        }

        [TearDown]
        public void TearDown()
        {
            //_driver.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                TestContext.WriteLine("Passed");
            }
            else if (testStatus.Equals(TestStatus.Passed))
            {
                TestContext.WriteLine("Failed");
            }

        }
    }
}
