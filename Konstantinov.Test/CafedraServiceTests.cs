using KonstantinovMihailKt_31_22.Database;
using KonstantinovMihailKt_31_22.Filters.CafedraFilters;
using KonstantinovMihailKt_31_22.Interfaces.CafedraInterfase;
using KonstantinovMihailKt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace KonstantinovMihailKt_31_22.Tests
{
    public class CafedraServiceTests
    {
        private readonly Mock<DbSet<Cafedra>> _mockCafedraDbSet;
        private readonly Mock<CafedraDbContext> _mockDbContext;
        private readonly List<Cafedra> _testCafedras;

        public CafedraServiceTests()
        {
            _testCafedras = new List<Cafedra>
            {
                new Cafedra
                {
                    CafedraId = 1,
                    CafedraName = "Кафедра информатики",
                    AdminId = 1,
                    totalPrerods = 15,
                    dataosnovania = new DateTime(2000, 1, 1),
                    Admin = new Prepods { IdPrepod = 1, FirstName = "Иван", LastName = "Иванов", MidName = "Иванович" }
                },
                new Cafedra
                {
                    CafedraId = 2,
                    CafedraName = "Кафедра математики",
                    AdminId = 2,
                    totalPrerods = 20,
                    dataosnovania = new DateTime(1995, 1, 1),
                    Admin = new Prepods { IdPrepod = 2, FirstName = "Петр", LastName = "Петров", MidName = "Петрович" }
                },
                new Cafedra
                {
                    CafedraId = 3,
                    CafedraName = "Кафедра физики",
                    AdminId = 3,
                    totalPrerods = 10,
                    dataosnovania = new DateTime(2010, 1, 1),
                    Admin = new Prepods { IdPrepod = 3, FirstName = "Сергей", LastName = "Сергеев", MidName = "Сергеевич" }
                }
            };

            var queryable = _testCafedras.AsQueryable();
            _mockCafedraDbSet.As<IQueryable<Cafedra>>().Setup(m => m.Provider).Returns(queryable.Provider);
            _mockCafedraDbSet.As<IQueryable<Cafedra>>().Setup(m => m.Expression).Returns(queryable.Expression);
            _mockCafedraDbSet.As<IQueryable<Cafedra>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            _mockCafedraDbSet.As<IQueryable<Cafedra>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            _mockDbContext.Setup(x => x.Set<Cafedra>()).Returns(_mockCafedraDbSet.Object);
        }
        [Fact]
        public void GetCafedrasByFilter_NoFilter_ReturnsAllCafedras()
        {
            // Arrange
            var service = new CafedraService(_mockDbContext.Object);
            var filter = new CafedraFilter();

            // Act
            var result = service.GetCafedrasByFilter(filter);

            // Assert
            Assert.Equal(3, result.Length);
            Assert.Equal("Кафедра информатики", result[0].CafedraName);
            Assert.Equal("Кафедра математики", result[1].CafedraName);
            Assert.Equal("Кафедра физики", result[2].CafedraName);
        }
    }
}