using System;
using KonstantinovMihailKt31-22;
using Moq;


namespace KonstantinovKt_31_22.Tests
{
    public class CafedraServiceTests
    {

        private readonly Mock<CafedraDbContext> _mockDbContext;
        private readonly Mock<DbSet<Cafedra>> _mockCafedraSet;
        private readonly Mock<DbSet<Prepods>> _mockPrepodSet;

        public CafedraServiceTests()
        {
            _mockDbContext = new Mock<CafedraDbContext>();
            _mockCafedraSet = new Mock<DbSet<Cafedra>>();
            _mockPrepodSet = new Mock<DbSet<Prepods>>();
        }

        private ICafedraService GetService()
        {
            return new CafedraService(_mockDbContext.Object);
        }

        [Fact]
        public async Task GetCafedrasByFilterAsync_WithoutFilter_ReturnsAllCafedras()
        {
            // Arrange
            var prepod = new Prepods { IdPrepod = 1, FirstName = "Test", LastName = "Test", MidName = "Test", DegreeId = 1, PositionId = 1 };
            var cafedras = new[]
            {
                new Cafedra { CafedraId = 1, CafedraName = "Test1", AdminId = 1, totalPrerods = 10, dataosnovania = new DateTime(2000, 1, 1), Admin = prepod },
                new Cafedra { CafedraId = 2, CafedraName = "Test2", AdminId = 1, totalPrerods = 20, dataosnovania = new DateTime(2001, 1, 1), Admin = prepod }
            }.AsQueryable();

            _mockCafedraSet.As<IQueryable<Cafedra>>().Setup(m => m.Provider).Returns(cafedras.Provider);
            _mockCafedraSet.As<IQueryable<Cafedra>>().Setup(m => m.Expression).Returns(cafedras.Expression);
            _mockCafedraSet.As<IQueryable<Cafedra>>().Setup(m => m.ElementType).Returns(cafedras.ElementType);
            _mockCafedraSet.As<IQueryable<Cafedra>>().Setup(m => m.GetEnumerator()).Returns(cafedras.GetEnumerator());

            _mockDbContext.Setup(db => db.Set<Cafedra>()).Returns(_mockCafedraSet.Object);
            _mockDbContext.Setup(db => db.Set<Prepods>()).Returns(_mockPrepodSet.Object);

            var service = GetService();
            var filter = new CafedraFilter();

            // Act
            var result = await service.GetCafedrasByFilterAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Length);
        }
    }
}
