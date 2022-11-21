using CoreFramework.NunitTestSetUp;
using NUnit.Framework;

namespace SeleniumFinalExamination.TestSetUp
{
    public class NunitWebTestSetUp: NunitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToUrl(Constant.BASE_URL);
        }

        [TearDown]
        public void TearDown()
        {
            driverBaseAction.Quit();
        }
    }
}
