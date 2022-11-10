using CoreFramework.NunitTestSetUp;
using NUnit.Framework;

namespace SeleDay3.TestSetUp
{
    public class SeleDay3SetUp: NunitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://www.google.com/";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
