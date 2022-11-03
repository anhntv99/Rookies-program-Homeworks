using OpenQA.Selenium;
using RookieTest.PageObject;

namespace RookieTest.PageObject
{
    public class VideosPage : HeaderPage
    {
        public VideosPage(IWebDriver? driver) : base(driver)
        {
        }

        public IWebElement? GetVideoByTitle(string videoByTitle)
        {
            By video = By.XPath($"//yt-formatted-string[contains(text(),'{videoByTitle}')]");
            return _driver?.FindElement(video);
        }

        public VideoDetailPage OpenVideo(string videoTitle)
        {
            GetVideoByTitle(videoTitle)?.Click();
            return new VideoDetailPage(_driver);
        }
    }
}