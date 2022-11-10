using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using CoreFramework.NunitTestSetUp;
using RookieTest.PageObject;
using RookieTest.TestSetUp;
using Framework.DriverCore;



namespace RookieTest
{
    [TestFixture]
    public class LoginTest : ProjectNunitTestSetUp
    {

        [Test]
        public void Id1_Login()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("text");
        }

        [Test]
        public void Id2_Login()
        {
            WebDriverAction text = new WebDriverAction(_driver);
            string title = text.GetTextElement("//a[@href=\"http://demo.guru99.com/test/newtours/\"]");
        }

    }

}
