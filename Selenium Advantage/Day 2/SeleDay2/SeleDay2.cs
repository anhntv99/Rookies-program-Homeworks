
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
            WebDriverAction action = new WebDriverAction(_driver);
            Console.WriteLine("The Website is opened successfully!");

            // Click to “Download”
            action.Click("//li//a[@href=\"/download/\"]");

            //Verify the title of the form is “Downloads”            
            action.VerifyTitleOfElement("//h1[text()= \" Downloads\"]", "Downloads");

            //Come back to Home page (Use ‘Back’ command)
            action.Back();

            //Verify the title of page is “NUnit.org”
            action.VerifyTitleOfPage("NUnit.org");

            //Again go back to Download page (This time use ‘Forward’ command)
            action.Forward();
        }
    }
}