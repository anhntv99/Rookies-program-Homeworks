using NUnit.Framework;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using CoreFramework.NunitTestSetUp;
using RookieTest.PageObject;
using RookieTest.TestSetUp;
using Framework.DriverCore;
using static System.Net.WebRequestMethods;


namespace RookieTest 
{
    [TestFixture]
    public class SimpleTests : ProjectNunitTestSetUp
    {

        [Test]
        public void UserCanInputUserName()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("text");
            WebDriverAction ss = new WebDriverAction(_driver);
            ss.ScreenShot();
        }

        [Test]
        public void VerifyTitleOfEmement()
        {
            WebDriverAction text = new WebDriverAction(_driver);
            string title = text.GetTextElement("//a[@href=\"http://demo.guru99.com/test/newtours/\"]");
        }

    }

}
