using Azure;
using InLineBackend.Domain.Aggregate;
using InLineBackend.Infrastructure.Contexts;
using InLineBackend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace InLineBackend.Host.Test
{
    public class InfraTest
    {
        private readonly Mock<AppOnlyDbContext> _contextMock;
        private readonly JuegoRepository _repository;

        public InfraTest()
        {
            // Crear mock del DbContext con su constructor real
            var options = new DbContextOptionsBuilder<AppOnlyDbContext>()
                .UseSqlServer("FakeConnection") // no se conecta de verdad
                .Options;

            _contextMock = new Mock<AppOnlyDbContext>(options);
            _repository = new JuegoRepository(_contextMock.Object);

        }

        [Fact]
        public async Task SaveAsync_ok()
        {
            // Arrange
            _contextMock.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
                        .ReturnsAsync(1);

            // Act
            await _repository.SaveAsync();

            // Assert
            _contextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetEstadoJuego_Should_Return_Juego_When_Exists()
        {
            // Arrange
            var juegos = new List<Juego>
            {
            Juego.Crear(1,2)
            };

            _contextMock.Setup(c => c.Juegos).ReturnsDbSet(juegos);

            // Act
            var result = await _repository.GetEstadoJuego(juegos[0].IdJuego);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetEstadoJuego_Should_Return_Null_When_NotFound()
        {
            // Arrange
            var data = new List<Juego> {
            Juego.Crear (4,4)
        };

            _contextMock.Setup(c => c.Juegos)
                        .ReturnsDbSet(data);

            // Act
            var result = await _repository.GetEstadoJuego("no-existe");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task NuevoJuego_Should_Add_Juego_To_DbSet()
        {
            // Arrange
            var juego = Juego.Crear(4, 4);

            var dbSetMock = new Mock<DbSet<Juego>>();
            _contextMock.Setup(c => c.Juegos).Returns(dbSetMock.Object);

            // Act
            var result = await _repository.NuevoJuego(juego);

            // Assert
            dbSetMock.Verify(d => d.AddAsync(juego, It.IsAny<CancellationToken>()), Times.Once);
            Assert.Equal(juego, result);
        }

        [Fact]
        public void BorrarJuegos_Should_Call_RemoveRange()
        {
            // Arrange
            var juegos = new List<Juego> {
            Juego.Crear(4, 4),
            Juego.Crear(4, 4)
        };

            _contextMock.Setup(c => c.Juegos).ReturnsDbSet(juegos);

            // Act
            _repository.BorrarJuegos();

            // Assert
            _contextMock.Verify(c => c.Juegos.RemoveRange(_contextMock.Object.Juegos), Times.Once);
        }
    }
}
