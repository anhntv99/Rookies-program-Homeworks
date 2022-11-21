using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using Framework.DriverCore;
using SeleniumFinalExamination.TestSetUp;
using NUnit.Framework;

namespace SeleniumFinalExamination.PageObject
{
    public class ElementsPage : WebDriverAction
    {
        public ElementsPage(IWebDriver? driver) : base(driver)
        {
        }

        private String endPointUrl = "/elements";
        public Boolean IsElementsPageDisplayed()
        {

            string url = GetUrl();
            url = Constant.BASE_URL + endPointUrl;
            TestContext.WriteLine("Go to Elements page successfully");
            return true;
        }
    }
}
