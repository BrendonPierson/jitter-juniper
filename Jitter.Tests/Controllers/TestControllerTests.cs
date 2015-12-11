using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Mvc;
using Jitter.Controllers;

namespace Jitter.Tests.Controllers
{
    [TestClass]
    public class TestControllerTests
    {
        [TestMethod]
        public void TestControllerEnsureICanGetAction()
        {
            TestController my_controller = new TestController();
            string expected_output = "Hello World";
            string actual_ouput = my_controller.Get();
            Assert.AreEqual(expected_output, actual_ouput);

        }
    }
}
