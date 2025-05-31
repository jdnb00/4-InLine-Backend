using FluentAssertions;
using InLineBackend.Application.Commnads.PostNuevaJugada;
using InLineBackend.Application.Commnads.PostNuevoJuego;
using InLineBackend.Application.Services;
using InLineBackend.Domain.Aggregate;
using InLineBackend.Domain.Interfaces;
using InLineBackend.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InLineBackend.Host.Test
{
    public class ApplicationTest
    {
        private readonly Mock<IJuegoRepository> _repo;
        private readonly JuegoService _service;
        private readonly PostNuevoJuegoCommandHandler _handlerJuego;
        private readonly PostNuevaJugadaCommandHandler _handlerJugada;
        public ApplicationTest()
        {
            _repo = new Mock<IJuegoRepository>();
            _service = new JuegoService(_repo.Object);
            _handlerJuego = new PostNuevoJuegoCommandHandler(_repo.Object);
            _handlerJugada = new PostNuevaJugadaCommandHandler(_service);

            _repo.Setup(m => m.SaveAsync());
        }

        [Fact]
        public async Task Handle_PostNuevoJuegoCommand_OK()
        {
            //Arrage
            var commad = new PostNuevoJuegoCommand(7, 6);
            var res = Juego.Crear(7, 6);

            _repo.Setup(m => m.BorrarJuegos());

            _repo.Setup(m => m.NuevoJuego( It.IsAny<Juego>()))
                .ReturnsAsync(res);
            //Act
            var result = await _handlerJuego.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevoJuegoResultDto>();
        }
        [Fact]
        public async Task Handle_PostNuevoJuegoCommand_KO()
        {
            //Arrage
            var commad = new PostNuevoJuegoCommand(7, 6);
            //Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                _handlerJuego.Handle(commad, default));
            //Assert
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_OK()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456",7, 6);
            var res1 = Juego.Crear(7, 6);

            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);
            //Act
            var result = await _handlerJugada.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevaJugadaResultDto>();
        }
        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_KO_JuegoNUll()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 7, 6);
            //Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                _handlerJugada.Handle(commad, default));
            //Assert
            Assert.IsType<ArgumentException>(exception);
        }
        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_KO_FailCol()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 7, 16);
            var res1 = Juego.Crear(7, 6);

            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);

            //Act
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                _handlerJugada.Handle(commad, default));
            //Assert
            Assert.IsType<ArgumentException>(exception);
        }
        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_KO_FilaFail()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 1, 0);
            var res1 = Juego.Crear(7, 6);
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "",
                Jugador = 1,
                Columna = 0,
                Fila = 16
            });

            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);
            //Act
            var result = await _handlerJugada.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevaJugadaResultDto>();
        }
        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_KO_Finalizado()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 17, 6);
            var res1 = Juego.Crear(7, 6);
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 0,
                Fila = 16,
                Marcada = true
            });

            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);
            //Act
            var result = await _handlerJugada.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevaJugadaResultDto>();
        }

        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_Horizontal()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 1, 1);
            var res1 = Juego.Crear(4, 4);
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 0,
                Fila = 0
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 2,
                Fila = 0
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 3,
                Fila = 0
            });


            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);
            //Act
            var result = await _handlerJugada.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevaJugadaResultDto>();
        }
        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_Vertl()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 1, 0);
            //var commad2 = new PostNuevaJugadaCommand("123456", 1, 0);
            //var commad3 = new PostNuevaJugadaCommand("123456", 1, 0);
            var res1 = Juego.Crear(4, 4);
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 0,
                Fila = 0
            });


            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);
            //Act
            var result = await _handlerJugada.Handle(commad, default);
            result = await _handlerJugada.Handle(commad, default);
            result = await _handlerJugada.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevaJugadaResultDto>();
        }

        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_diagonalder()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 1, 1);
            var res1 = Juego.Crear(4, 4);
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 0,
                Columna = 1,
                Fila = 0
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 0,
                Fila = 0
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 2,
                Fila = 2
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 3,
                Fila = 3
            });


            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);
            //Act
            var result = await _handlerJugada.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevaJugadaResultDto>();
        }

        [Fact]
        public async Task Handle_PostNuevaJugadaCommand_diagonalIzq()
        {
            //Arrage
            var commad = new PostNuevaJugadaCommand("123456", 1, 1);
            var res1 = Juego.Crear(4, 4);
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 0,
                Columna = 1,
                Fila = 0
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 0,
                Fila = 0
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 2,
                Fila = 2
            });
            res1.Jugadas.Add(new Jugada()
            {
                IdJuego = "123456",
                Jugador = 1,
                Columna = 3,
                Fila = 3
            });


            _repo.Setup(m => m.GetEstadoJuego(It.IsAny<string>()))
                .ReturnsAsync(res1);
            //Act
            var result = await _handlerJugada.Handle(commad, default);
            //Assert
            result.Should().BeOfType<PostNuevaJugadaResultDto>();
        }

    }
}
