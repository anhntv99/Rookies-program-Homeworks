using NUnit.Framework;
using OpenQA.Selenium;
using CoreFramework.Reporter;

namespace Framework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;


        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;

        }

        public string getTitle()
        {
            string title = driver.Title;
            return title;
        }

        public IWebElement highlightElement(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border = '2px solid red'", element);
            return element;
        }

        public IWebElement FindEdlementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(By.XPath(locator));
            highlightElement(e);
            return e;
        }

        public void Click(IWebElement e)
        {
            try
            {
                highlightElement(e);
                e.Click();
                TestContext.WriteLine("Click into element " + e.ToString() + " passed");
                HtmlReport.Pass("Click into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into element " + e.ToString() + " failed");
                HtmlReport.Fail("Click into element " + e.ToString() + " passed", TakeScreenshot());
                throw ex;
            }
        }

        public void Click(string locator)
        {
            try
            {
                FindEdlementByXpath(locator).Click();
                HtmlReport.Pass("Click into element " + locator + " passed");

            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Click into element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public void SendKeys_(IWebElement e, string key)
        {
            try
            {
                e.SendKeys(key)
;
                HtmlReport.Pass("SendKey into element " + e.ToString() + " passed");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("SendKey into element " + e.ToString() + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public void SendKeys_(string locator, string key)
        {
            try
            {
                FindEdlementByXpath(locator).SendKeys(key);
                HtmlReport.Pass("SendKey into element " + locator + " passed");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("SendKey into element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }

        // action Take Screenshot
        public string TakeScreenshot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }

        // action Get text element
        public string GetTextElement(string locator)
        {
            try
            {
                IWebElement e = FindEdlementByXpath(locator);
                string text = e.Text;
                return text;
                HtmlReport.Pass("Get Text Element " + locator + " passed");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Get Text Element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public void VerifyTitleOfElement(string locator, string key)
        {
            try
            {
                string title = GetTextElement(locator);
                Assert.That(title, Is.EqualTo(key));
                HtmlReport.Pass("Verify title of element " + locator + " passed");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Verify title of element " + locator + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public void VerifyTitleOfPage(string key)
        {
            try
            {
                string title = getTitle();
                Assert.That(title, Is.EqualTo(key));
                HtmlReport.Pass("Verify title of page " + key + " passed");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Verify title of page " + key + " failed", TakeScreenshot());
                throw ex;
            }
        }

        public void Back()
        {
            try
            {
                driver.Navigate().Back();
                HtmlReport.Pass("Get back passed");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Get back failed", TakeScreenshot());
                throw ex;
            }
        }

        public void Forward()
        {
            try
            {
                driver.Navigate().Forward();
                HtmlReport.Pass("Get forward passed");
            }
            catch (Exception ex)
            {
                HtmlReport.Fail("Get forward failed", TakeScreenshot());
                throw ex;
            }
        }

    }
}
