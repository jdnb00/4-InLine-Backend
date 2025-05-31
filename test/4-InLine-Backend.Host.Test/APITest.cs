using FluentAssertions;
using InLineBackend.API.Controllers;
using InLineBackend.Application.Commnads.PostNuevaJugada;
using InLineBackend.Application.Commnads.PostNuevoJuego;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace InLineBackend.Host.Test
{
    [ExcludeFromCodeCoverage]
    public class APITest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly OneController _controller;

        public APITest()
        {
            _mediator = new Mock<IMediator>();
            _controller = new OneController(_mediator.Object);
        }

        [Fact]
        public async Task PostNuevoJuegoOK()
        {
            //Arrage
            int columna = 7;
            int fila = 6;
            PostNuevoJuegoResultDto response = new PostNuevoJuegoResultDto()
            {
                IdJuego= "123456",
                ColumnasMax = columna,
                FilasMax = fila,
                Finalizado  = false
            };
            
            _mediator.Setup(m => m.Send(
                    It.IsAny<PostNuevoJuegoCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.PostNuevoJuego(columna, fila);
            var commadtest = new PostNuevoJuegoCommand(columna, fila);

            // Assert

            commadtest.Columna.Should().Be(columna);
            commadtest.Fila.Should().Be(fila);
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public async Task PostNuevoJuegoKO()
        {
            //Arrage
            _mediator.Setup(m => m.Send(
                    It.IsAny<PostNuevoJuegoCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ArgumentException("Error al crear el juego"));

            //Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _controller.PostNuevoJuego(1,2));

            var exception1 =  Assert.Throws<ArgumentException>(() => new PostNuevoJuegoCommand(10, -1));
            var exception2 =  Assert.Throws<ArgumentException>(() => new PostNuevoJuegoCommand(-1, 10));

            //Assert      
            Assert.IsType<ArgumentException>(exception);
            Assert.IsType<ArgumentException>(exception1);
            Assert.IsType<ArgumentException>(exception2);
        }

        [Fact]
        public async Task PostNuevaJugadaOK()
        {
            //Arrage
            PostNuevaJugadaResultDto response = new PostNuevaJugadaResultDto()
            {
                MatrizJugadas = new List<(int, int, bool, int)>
                {
                    (1, 2, true, 4),
                    (3, 5, false, 7)
                },
                Finalizado = false
            };

            _mediator.Setup(m => m.Send(
                    It.IsAny<PostNuevaJugadaCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.PostNuevaJugada("id",1,1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
        }
        [Fact]
        public async Task PostNuevaJugadaKO()
        {
            //Arrage
            _mediator.Setup(m => m.Send(
                    It.IsAny<PostNuevaJugadaCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ArgumentException("Error al crear el juego"));

            //Act
            var exception = await Xunit.Assert.ThrowsAsync<ArgumentException>(() => _controller.PostNuevaJugada("id",1,1));

            //Assert      
            Assert.IsType<ArgumentException>(exception);
        }

    }
}