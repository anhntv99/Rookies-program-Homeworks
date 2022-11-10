
using Framework.DriverCore;
using OpenQA.Selenium;
using SeleDay2.TestSetUp;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SeleDay2
{
    [TestFixture]
    public class SimpleTest : SeleDay2SetUp
    {
        [Test]
        public void Scenario1()
        {
            Console.WriteLine("The Website is opened successfully!");

            // Click to “Download”
            WebDriverAction clickElement = new WebDriverAction(_driver);
            clickElement.Click("//li//a[@href=\"/download/\"]");

            //Verify the title of the form is “Downloads”
            WebDriverAction getTitle1 = new WebDriverAction(_driver);
            getTitle1.VerifyTitleOfElement("//h1[text()= \" Downloads\"]", "Downloads");

            //Come back to Home page (Use ‘Back’ command)
            WebDriverAction getBack = new WebDriverAction(_driver);
            getBack.Back();

            //Verify the title of page is “NUnit.org”
            WebDriverAction getTitle2 = new WebDriverAction(_driver);
            getTitle2.VerifyTitleOfPage("NUnit.org");

            //Again go back to Download page (This time use ‘Forward’ command)
            WebDriverAction getForward = new WebDriverAction(_driver);
            getForward.Forward();
        }
    }
}