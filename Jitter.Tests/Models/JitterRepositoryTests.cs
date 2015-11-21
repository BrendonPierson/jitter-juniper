using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepositoryTests
    {
        [TestMethod]
        public void JitterContextEnsureICanCreateInstance()
        {
            JitterContext context = new JitterContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void JitterRepositoryEnsureIcanCreateInstance()
        {
            JitterRepository repository = new JitterRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanGetAllUsers()
        {
            // Arrange
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "adam1" },
                new JitterUser { Handle = "adam2" }
            };

            // Mock<> - Look for all behaviors of this class and duplicate it
            // Pretty much is now that class, but we won't break the data
            // Stubbing - replacing real return value with what we want it to return
            Mock<JitterContext> mock_context = new Mock<JitterContext>();

            // the type in the mock below is the same as in the JitterContext
            Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();
            mock_set.Object.AddRange(expected);

            // a represents instance of whatever is in mock angle brackest
            mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object);

            JitterRepository repository = new JitterRepository(mock_context.Object);

            // Act
            var actual = repository.GetAllUsers();

            // Assert
            // Assert.AreEqual("adam1", actual.First().Handle);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JitterRepositoryEnsureIHaveAContext()
        {
            // Arrange 
            JitterRepository repository = new JitterRepository();
            // Act
            var actual = repository.Context;
            // Assert
            Assert.IsInstanceOfType(actual, typeof(JitterContext));
        }

        [TestMethod]
        public void JitterRepository()
        {

        }
    }
}
