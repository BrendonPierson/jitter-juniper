using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jitter.Models;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace Jitter.Tests.Models
{
    [TestClass]
    public class JitterRepositoryTestsec
    {
        private Mock<JitterContext> mock_context;
        private Mock<DbSet<JitterUser>> mock_set;
        private JitterRepository repository;

        //Test classes can have methods that aren't run as tests
        private void ConectMocksToDataStore(IEnumerable<JitterUser> data_store)
        {
            var data_source = data_store.AsQueryable<JitterUser>();

            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());


            // This is Stubbing the JitterUsers property getter
            mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object);
        }

        // Runs before each test
        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<JitterContext>();
            mock_set = new Mock<DbSet<JitterUser>>();
            repository = new JitterRepository(mock_context.Object);

        }

        //runs after each test
        [TestCleanup]
        public void CleanUP()
        {
            mock_context = null;
            mock_set = null;
            repository = null ;
        }

        [TestMethod]
        public void JitterContextEnsureICanCreateInstance()
        {
            JitterContext context = mock_context.Object;
            //JitterContext context = new JitterContext();
            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanCreatInstance()
        {
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanGetAllUsers()
        {
            // want list of users to behave like a data store
            // Arrange
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "adam1" },
                new JitterUser { Handle = "rumbadancer2" }
            };
            Mock<JitterContext> mock_context = new Mock<JitterContext>();
            Mock<DbSet<JitterUser>> mock_set = new Mock<DbSet<JitterUser>>();

            mock_set.Object.AddRange(expected);

            var data_source = expected.AsQueryable();

            // stub in the methods/properties to convince LINQ that our Mock DbSet is a relational Data store
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.Provider).Returns(data_source.Provider);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.Expression).Returns(data_source.Expression);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.ElementType).Returns(data_source.ElementType);
            mock_set.As<IQueryable<JitterUser>>().Setup(data => data.GetEnumerator()).Returns(data_source.GetEnumerator());

            // This is Stubbing the JitterUsers property getter
            mock_context.Setup(a => a.JitterUsers).Returns(mock_set.Object);
            JitterRepository repository = new JitterRepository(mock_context.Object);

            // Act
            var actual = repository.GetAllUsers();
            // Assert
            //Assert.AreEqual("adam1", actual.First().Handle);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JitterRepositoryEnsureICanGetAllUsersShortVersion()
        {
            var expected = new List<JitterUser>
            {
                new JitterUser { Handle = "adam1" },
                new JitterUser { Handle = "rumbadancer2" }
            };

            //mock_set.Object.AddRange(expected);

            ConectMocksToDataStore(expected);

            // Act
            var actual = repository.GetAllUsers();

            // Assert
            Assert.AreEqual("adam1", actual.First().Handle);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void JitterRepositoryEnsureIHaveAContext()
        {
            // Arrange
            // Act
            var actual = repository.Context;
            // Assert
            Assert.IsInstanceOfType(actual, typeof(JitterContext));
        }


    }
}
