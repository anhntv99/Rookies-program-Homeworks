using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System.Drawing;
using System.Drawing.Design;
using OpenQA.Selenium.Support.Events;

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
            return driver.Title;
        }

        public IWebElement highlightElement(IWebElement e)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border = '2px solid red'", e);
            return e;
        }

        public IWebElement FindEdlementByXpath(string locator)
        {
            IWebElement e = (IWebElement)driver.FindElements(By.XPath(locator));
            highlightElement(e);
            return e;
        }

        public void Click(IWebElement e)
        {
            try
            {
                e.Click();
                TestContext.WriteLine("Click into emlement" + e.ToString() + "passed");

            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into emlement" + e.ToString() + "failed");
                throw ex;
            }
        }

        public void Click(String locator)
        {
            try
            {
                FindEdlementByXpath(locator).Click();
                TestContext.WriteLine("Click into emlement" + locator + "passed");

            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into emlement" + locator + "failed");
                throw ex;
            }
        }

        public void SendKeys(string locator, string key)
        {
            try
            {
                FindEdlementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("SendKeys into emlement" + locator + "passed");

            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Click into emlement" + locator + "failed");
                throw ex;
            }
        }

        public void ScreenShot()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile("C:\\Users\\VanAnh\\source\\repos\\Test\\RookieTest\\bin" +
                    "\\Screenshot\\Test.png", ScreenshotImageFormat.Png);
                TestContext.WriteLine("Take screenshot successfully!");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Take screenshot successfully!");
                throw ex;
            }

            }

        public void Clear()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                
            }
        }


    }
}
