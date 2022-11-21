using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using Framework.DriverCore;

namespace SeleniumFinalExamination.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver? driver) : base(driver)
        {
        }
        private String cardElements = "//*[text() = 'Elements']";
        public void GoToElementsPage()
        {
            ScrollToElement(cardElements);
            Click(cardElements);
        }


    }
}
