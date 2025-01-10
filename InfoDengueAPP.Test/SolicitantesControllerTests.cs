using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using InfoDengueAPP.INFRASTRUCTURE.Repositories.Interfaces;
using InfoDengueAPP.SERVICES.Interfaces;
using InfoDengueAPP.SERVICES;
using InfoDengueAPP.Domain.Entities;
using InfoDengueAPP.API.Controllers;

namespace InfoDengueAPP.Test
{
    public class SolicitantesControllerTests
    {
        private readonly Mock<ISolicitanteService> _mockSolicitanteService;
        private readonly SolicitantesController _controller;

        public SolicitantesControllerTests()
        {
            _mockSolicitanteService = new Mock<ISolicitanteService>();
            _controller = new SolicitantesController(_mockSolicitanteService.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllSolicitantes()
        {
            // Arrange
            var solicitantes = new List<Solicitante>
    {
        new Solicitante { Id = 1, Nome = "John Doe", Cpf = "12345678900" },
        new Solicitante { Id = 2, Nome = "Jane Smith", Cpf = "98765432100" }
    };

            _mockSolicitanteService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(solicitantes);

            // Act
            var result = await _controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedSolicitantes = Assert.IsType<List<Solicitante>>(result.Value);
            Assert.Equal(2, returnedSolicitantes.Count);
        }

        [Fact]
        public async Task Add_ShouldCallServiceAddOnce()
        {
            // Arrange
            var solicitante = new Solicitante { Nome = "John Doe", Cpf = "12345678900" };

            // Act
            var result = await _controller.Add(solicitante);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockSolicitanteService.Verify(service => service.AddAsync(solicitante), Times.Once);
        }


    }
}
