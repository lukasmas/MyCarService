using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyCarService.AuthServices;
using MyCarService.Models.Auth;
using MyCarService.Models.DatabaseModels;
using MyCarService.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyCarService.Tests.UnitOfWorkTest
{
    public class AuthUnitTest
    {
        [Fact]
        public void LoginUserAllDataIsCorrect()
        {
            var authService = new AuthService("TOP_SECRET_TOKEN", 10);

            UserAuth userLoginData = new UserAuth { Username = "test", Password = "test" };
            var password = authService.HashPassword("testtestsalt123");
            User expectedUser = new User { Email = "test@test.com", Id = "abc-123", Password = password, Salt = "salt123", Username = "test"};
            var users = new List<User> { expectedUser }.AsQueryable();
            
            var dbContextMock = new Mock<MyCarServiceContext>();
            var dbSetMock = new Mock<DbSet<User>>();
            dbSetMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            dbSetMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            dbSetMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            dbSetMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            dbContextMock.Setup(s => s.Set<User>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var authUnit = new AuthUnit(dbContextMock.Object, authService);

            var result = authUnit.LoginUser(userLoginData);

            Assert.True(result.IsSuccess());
            Assert.NotNull(result.GetSuccess());
            Assert.NotNull(result.GetSuccess()!.Token);
            Assert.Equal(result.GetSuccess()!.Id, expectedUser.Id);
        }
    }
}
