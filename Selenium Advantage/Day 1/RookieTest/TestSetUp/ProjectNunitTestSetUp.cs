using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreFramework.NunitTestSetUp;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace RookieTest.TestSetUp
{
    public class ProjectNunitTestSetUp: NunitTestSetUp
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://demo.guru99.com/v4/";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
