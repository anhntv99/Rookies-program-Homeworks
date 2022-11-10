using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleFay3.PageObject;
using SeleDay3.TestSetUp;
using Framework.DriverCore;


namespace SeleDay3
{
    [TestFixture]
    public class SimpleTest : SeleDay3SetUp
    {


        [Test]
        public void SearchByGoogle()
        {
            // Input any text to search
            HomePage homePage = new HomePage(_driver);
            homePage.Search("NUnit");

            // Reach to result screen, verify Title of this screen is matching with text in step 2
            WebDriverAction getTitle = new WebDriverAction(_driver);
            getTitle.VerifyTitleOfPage("NUnit - Tìm trên Google");

            // Click on 1st result, verify any text in this screen
            homePage.ClickFirstResultScreen();
            homePage.VerifyTextInFirstResultScreen("//a[@href=\"/news/\"]", "News");
        }
    }
}

