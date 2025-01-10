using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using InfoDengueAPP.INFRASTRUCTURE.Repositories.Interfaces;
using InfoDengueAPP.SERVICES.Interfaces;
using InfoDengueAPP.SERVICES;
using InfoDengueAPP.Domain.Entities;

namespace InfoDengueAPP.Test
{
    public class SolicitanteServiceTests
    {
        private readonly Mock<ISolicitanteRepository> _mockSolicitanteRepository;
        private readonly ISolicitanteService _solicitanteService;

        public SolicitanteServiceTests()
        {
            _mockSolicitanteRepository = new Mock<ISolicitanteRepository>();
            _solicitanteService = new SolicitanteService(_mockSolicitanteRepository.Object);
        }
    

    [Fact]
        public async Task AddAsync_ShouldCallRepositoryAddOnce()
        {
            // Arrange
            var solicitante = new Solicitante
            {
                Id = 1,
                Nome = "John Doe",
                Cpf = "12345678900"
            };

            // Act
            await _solicitanteService.AddAsync(solicitante);

            // Assert
            _mockSolicitanteRepository.Verify(repo => repo.AddAsync(solicitante), Times.Once);
        }

        [Fact]
        public async Task GetByCpfAsync_ShouldReturnCorrectSolicitante()
        {
            // Arrange
            var solicitante = new Solicitante
            {
                Id = 1,
                Nome = "John Doe",
                Cpf = "12345678900"
            };

            _mockSolicitanteRepository.Setup(repo => repo.GetByCpfAsync("12345678900"))
                .ReturnsAsync(solicitante);

            // Act
            var result = await _solicitanteService.GetByCpfAsync("12345678900");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John Doe", result.Nome);
            Assert.Equal("12345678900", result.Cpf);
            _mockSolicitanteRepository.Verify(repo => repo.GetByCpfAsync("12345678900"), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllSolicitantes()
        {
            // Arrange
            var solicitantes = new List<Solicitante>
    {
        new Solicitante { Id = 1, Nome = "John Doe", Cpf = "12345678900" },
        new Solicitante { Id = 2, Nome = "Jane Smith", Cpf = "98765432100" }
    };

            _mockSolicitanteRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(solicitantes);

            // Act
            var result = await _solicitanteService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, s => s.Nome == "John Doe");
            Assert.Contains(result, s => s.Nome == "Jane Smith");
        }


    }
    
}
