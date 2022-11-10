using CoreFramework.NunitTestSetUp;
using NUnit.Framework;

namespace SeleDay2.TestSetUp
{
    public class SeleDay2SetUp : NunitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://nunit.org/";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
