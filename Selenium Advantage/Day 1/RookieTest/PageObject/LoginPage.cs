using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using RookieTest.PageObject;
using Framework.DriverCore;

namespace RookieTest.PageObject
{
    public class LoginPage : WebDriverAction
    {
        public LoginPage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly String tfUsername = "//input[@name = 'uid']";

        public void inputUserName(string Username)
        {
            SendKeys(tfUsername, Username);
        }
    }
}
