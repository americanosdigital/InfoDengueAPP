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
    public class RelatorioServiceTests
    {
        private readonly Mock<IRelatorioRepository> _mockRelatorioRepository;
        private readonly IRelatorioService _relatorioService;

        public RelatorioServiceTests()
        {
            _mockRelatorioRepository = new Mock<IRelatorioRepository>();
            _relatorioService = new RelatorioService(_mockRelatorioRepository.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldCallRepositoryAddOnce()
        {
            // Arrange
            var relatorio = new Relatorio
            {
                Id = 1,
                Municipio = "Rio de Janeiro",
                CodigoIbge = "3304557",
                Arbovirose = "Dengue",
                TotalCasos = 100
            };

            // Act
            await _relatorioService.AddAsync(relatorio);

            // Assert
            _mockRelatorioRepository.Verify(repo => repo.AddAsync(relatorio), Times.Once);
        }

        [Fact]
        public async Task GetAllEpidemiologicalDataForRJAndSPAsync_ShouldReturnRelatorios()
        {
            // Arrange
            var relatorios = new List<Relatorio>
    {
        new Relatorio { Id = 1, Municipio = "Rio de Janeiro", Arbovirose = "Dengue" },
        new Relatorio { Id = 2, Municipio = "São Paulo", Arbovirose = "Zika" }
    };

            _mockRelatorioRepository.Setup(repo => repo.GetAllEpidemiologicalDataForRJAndSPAsync())
                .ReturnsAsync(relatorios);

            // Act
            var result = await _relatorioService.GetAllEpidemiologicalDataForRJAndSPAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, r => r.Municipio == "Rio de Janeiro");
            Assert.Contains(result, r => r.Municipio == "São Paulo");
        }

    }
    
}
