using JAR.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace JAR.Tests.Mocks
{
    public static class UserManagerMock
    {
        public static Mock<UserManager<User>> Instance
        {
            get
            {
                var userStoreMock = new Mock<IUserStore<User>>();

                var userManagerMock = new Mock<UserManager<User>>(
                    userStoreMock.Object,
                    null, 
                    null, 
                    null, 
                    null, 
                    null, 
                    null, 
                    null, 
                    null 
                );

                userManagerMock.Setup(um => um.FindByIdAsync(It.IsAny<string>()))
                    .ReturnsAsync((string userId) => new User { Id = userId });

                userManagerMock.Setup(um => um.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(IdentityResult.Success);

                userManagerMock.Setup(um => um.RemoveFromRoleAsync(It.IsAny<User>(), It.IsAny<string>()))
                    .ReturnsAsync(IdentityResult.Success);

                return userManagerMock;
            }
        }
    }
}