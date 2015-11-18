using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JotTests
    {
        [TestMethod]
        public void JotEnsureICanCreateInstance()
        {
            Jot a_jot = new Jot();
            Assert.IsNotNull(a_jot);
        }

        [TestMethod]
        public void JotEnsureJotHasAllTheThings()
        {
            // Arrange
            Jot a_jot = new Jot();
            // Act
            DateTime expectedTime = DateTime.Now;
            a_jot.JotId = 1;
            a_jot.Content = "My Content";
            a_jot.Date = expectedTime;
            a_jot.Author = null;
            a_jot.Picture = "http://google.com";
            // Assert
            Assert.AreEqual(1, a_jot.JotId);
            Assert.AreEqual("My Content", a_jot.Content);
            Assert.AreEqual(expectedTime, a_jot.Date);
            Assert.AreEqual(null, a_jot.Author);
            Assert.AreEqual("http://google.com", a_jot.Picture);
        }
        [TestMethod]
        public void JotEnsureICanUseObjectInitializerSyntax()
        {
            // Arrange
            DateTime expectedTime = DateTime.Now;
            // Act
            Jot a_jot = new Jot
            {
                JotId = 1,
                Content = "My Content",
                Date = expectedTime,
                Author = null,
                Picture = "http://google.com"
            };
           
            // Assert
            Assert.AreEqual(1, a_jot.JotId);
            Assert.AreEqual("My Content", a_jot.Content);
            Assert.AreEqual(expectedTime, a_jot.Date);
            Assert.AreEqual(null, a_jot.Author);
            Assert.AreEqual("http://google.com", a_jot.Picture);
        }
    }
}
