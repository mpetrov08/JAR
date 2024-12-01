using JAR.Core.Contracts;
using JAR.Core.Services;
using JAR.Infrastructure.Data.Models;
using JAR.Tests.Mocks;
using static JAR.Infrastructure.Constants.AdministratorConstants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace JAR.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;
        private ILecturerService lecturerService;
        private Mock<UserManager<User>> userManagerMock;

        [OneTimeSetUp]
        public void SetUp()
        {
            userManagerMock = UserManagerMock.Instance; 
            lecturerService = new LecturerService(repository);
            userService = new UserService(repository, userManagerMock.Object, lecturerService);
        }

        [Test]
        public async Task AllAsync_ShouldWorkCorrectly()
        {
            var result = await userService.AllAsync();

            Assert.IsNotNull(result);

            var allUsers = repository
                .AllReadOnly<User>()
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(allUsers.Count()));

            var resultUser = result.FirstOrDefault(rc => rc.Id == OwnerUser.Id);
            var isLecturer = await lecturerService.IsLecturer(OwnerUser.Id);

            Assert.IsNotNull(resultUser);
            Assert.That(resultUser.Email, Is.EqualTo(OwnerUser.Email));
            Assert.That(resultUser.FullName, Is.EqualTo(OwnerUser.FirstName + " " + OwnerUser.LastName));
            Assert.That(resultUser.IsLecturer, Is.EqualTo(isLecturer));
        }

        [Test]
        public async Task PromoteUserToAdminAsync_ShouldWorkCorrectly()
        {
            var userId = OwnerUser.Id;

            var result = await userService.PromoteUserToAdminAsync(userId);

            Assert.IsTrue(result);

            userManagerMock.Verify(um => um.AddToRoleAsync(It.Is<User>(u => u.Id == userId), AdminRole), Times.Once);
            userManagerMock.Verify(um => um.FindByIdAsync(It.Is<string>(id => id == userId)), Times.Once);
        }

        [Test]
        public async Task RemoveAdminRoleAsync_ShouldWorkCorrectly()
        {
            var userId = OwnerUser.Id;

            var userMock = new Mock<User>();
            userMock.Setup(u => u.Id).Returns(userId); 
            userMock.Setup(u => u.Email).Returns(OwnerUser.Email); 
            userMock.Setup(u => u.UserName).Returns(OwnerUser.UserName);

            userManagerMock.Setup(um => um.FindByIdAsync(userId)).ReturnsAsync(userMock.Object);

            var result = await userService.RemoveAdminRoleAsync(userId);

            Assert.IsTrue(result);

            userManagerMock.Verify(um => um.FindByIdAsync(It.Is<string>(id => id == userId)), Times.Exactly(2));

            userManagerMock.Verify(um => um.RemoveFromRoleAsync(It.Is<User>(u => u.Id == userId), AdminRole), Times.Once);
        }
    }
}