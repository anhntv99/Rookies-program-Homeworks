using OpenQA.Selenium;
using Framework.DriverCore;

namespace SeleFay3.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver? driver) : base(driver)
        {
        }

        private readonly string searchBox = "//*[@title ='Tìm kiếm']";
        private readonly string firstResult = "//a[@href=\"https://nunit.org/\"]//h3[1]";


      
        public HomePage Search(string keyword)
        {
            SendKeys_(searchBox, keyword);
            FindEdlementByXpath(searchBox).SendKeys(Keys.Enter);

            return this;
        }

        public void ClickFirstResultScreen()
        {
            Click(firstResult);
        }

        public void VerifyTextInFirstResultScreen(string locator, string key)
        {
            VerifyTitleOfElement(locator, key);
        }

        public void VerifyTitleOfResultPage(string key)
        {
            VerifyTitleOfPage(key);
        }
    }
}