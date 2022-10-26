using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V104.DOM;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Day_2_Practice
{
    [TestFixture]
    public class SimpleTests
    {
        protected WebDriverWait? _wait;
        protected IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            //Launch the Chrome browser
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Test1()
        {
            //Open website “http://automationpractice.com/index.php”
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Thread.Sleep(3000);

            //Print a Message to display that the website is opened successfully
            Console.WriteLine("Website is opened successfully!");

            //Click to “Contact Us” link on top menu to open Contact us page
            IWebElement searchResult = _driver.FindElement(By.XPath("//*[@title = 'Contact Us']"));
            Thread.Sleep(3000);
            searchResult.Click();
            Thread.Sleep(3000);

            //Verify the title of the form is “CUSTOMER SERVICE - CONTACT US”
            IWebElement title = _driver.FindElement(By.XPath("//*[@class = 'page-heading bottom-indent']"));
            String expectedTitle1 = title.Text;
            if (expectedTitle1.Equals("CUSTOMER SERVICE - CONTACT US"))
            {
                Console.WriteLine("Title of the form is correct!");
            }    
            else
            {
                Console.WriteLine("Title of the form is incorrect!");
            }

            //Come back to Home page (Use ‘Back’ command)
            _driver.Navigate().Back();
            Thread.Sleep(3000);

            //Verify the title of page is “My store”
            String expectedTitle2 = _driver.Title;
            if (expectedTitle2.Equals("My store"))
            {
                Console.WriteLine("Title of the page is correct!");
            }
            else
            {
                Console.WriteLine("Title of the page is incorrect!");
            }

            //Again go back to Contact us page (This time use ‘Forward’ command)
            _driver.Navigate().Forward();
            Thread.Sleep(3000);

            //Close the Browser
            _driver.Close();
            _driver.Quit();;
        }
    }
}