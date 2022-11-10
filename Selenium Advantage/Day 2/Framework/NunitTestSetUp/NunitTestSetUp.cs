﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CoreFramework.Reporter;
using Framework.DriverCore;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;



namespace CoreFramework.NunitTestSetUp
{
    public class NunitTestSetUp
    {
        protected IWebDriver? _driver;
        public WebDriverAction driverBaseAction;
        protected ExtentReports? _extentReport;
       

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            HtmlReport.createReport();
            HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName);
        }
        [SetUp]
        public void Setup()
        {
            HtmlReport.Pass("abc");
            HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
            driverBaseAction = new WebDriverAction(_driver);
          
        }

        [TearDown]
        public void TearDown()
        {
            //_driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
            }
            else if (testStatus.Equals(TestStatus.Passed))
            {
            }
            HtmlReport.flush();

        }
    }
}
