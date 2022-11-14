using NUnit.Framework;
using NUnit.Framework.Internal;
using CoreFramework.APICore;
using RookieTest.Service;


namespace RookieTest 
{
    [TestFixture]
    public class APITest
    {

        [Test]
        public void APIRequestTest()
        {
            APIResponse response = new APIChallenge().ID4();
            Assert.AreEqual(response.responseStatusCode, "404");
        }

        [Test]
        public void APIRequestTest05()
        {
            APIResponse response = new APIChallenge().ID5();
            Assert.AreEqual(response.responseStatusCode, "200");
        }
        [Test]
        public void APIRequestTest06()
        {
            APIResponse response = new APIChallenge().ID6();
            Assert.AreEqual(response.responseStatusCode, "404");
        }
    }
}
