using Moq;
using Microsoft.EntityFrameworkCore;
using MyCarService.Models.DatabaseModels;
using Xunit;

namespace MyCarService.Tests
{
    public class OwnerTests
    {
        [Fact]
        public void GetOwnerById()
        {
            //Setup DbContext and DbSet mock
            var expectedOwner = new Owner { Id = 2, Name = "Test", Surname = "Testowicz" };
            var dbContextMock = new Mock<MyCarServiceContext>();
            var dbSetMock = new Mock<DbSet<Owner>>();
            dbSetMock.Setup(s => s.Find(It.IsAny<long>())).Returns(expectedOwner);
            dbContextMock.Setup(s => s.Set<Owner>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var unitOfWork = new UnitOfWork(dbContextMock.Object);
            var owner = unitOfWork.GetOwnerById(100000);

            //Assert  
            Assert.NotNull(owner);
            Assert.Equal(expectedOwner, owner);
        }
    }

  
}