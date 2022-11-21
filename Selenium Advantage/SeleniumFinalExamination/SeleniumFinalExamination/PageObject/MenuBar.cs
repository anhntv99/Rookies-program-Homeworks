using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using Framework.DriverCore;

namespace SeleniumFinalExamination.PageObject
{
    public class MenuBar : WebDriverAction
    {
        public MenuBar(IWebDriver? driver) : base(driver)
        {
        }
        private String btnWebTables = "//*[text() = 'Web Tables']";
        public void GoToWebTablesPage()
        {
            ScrollToElement(btnWebTables);
            Click(btnWebTables);
        }
    }
}
