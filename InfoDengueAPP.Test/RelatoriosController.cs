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
    public class RelatoriosControllerTests
    {
        private readonly Mock<IRelatorioService> _mockRelatorioService;
        private readonly RelatoriosController _controller;

        public RelatoriosControllerTests()
        {
            _mockRelatorioService = new Mock<IRelatorioService>();
            _controller = new RelatoriosController(_mockRelatorioService.Object);
        }

        //Testar Obtenção de Todos os Relatórios
        [Fact]
        public async Task GetAll_ShouldReturnAllRelatorios()
        {
            // Arrange
            var relatorios = new List<Relatorio>
    {
        new Relatorio { Id = 1, Municipio = "Rio de Janeiro", Arbovirose = "Dengue", TotalCasos = 100 },
        new Relatorio { Id = 2, Municipio = "São Paulo", Arbovirose = "Zika", TotalCasos = 50 }
    };

            _mockRelatorioService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(relatorios);

            // Act
            var result = await _controller.GetAll() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedRelatorios = Assert.IsType<List<Relatorio>>(result.Value);
            Assert.Equal(2, returnedRelatorios.Count);
            Assert.Contains(returnedRelatorios, r => r.Municipio == "Rio de Janeiro");
            Assert.Contains(returnedRelatorios, r => r.Municipio == "São Paulo");
        }

        //Testar Adição de Relatório
        [Fact]
        public async Task Add_ShouldCallServiceAddOnce()
        {
            // Arrange
            var relatorio = new Relatorio
            {
                Municipio = "Rio de Janeiro",
                CodigoIbge = "3304557",
                Arbovirose = "Dengue",
                TotalCasos = 100
            };

            // Act
            var result = await _controller.Add(relatorio);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockRelatorioService.Verify(service => service.AddAsync(relatorio), Times.Once);
        }

        //Testar Obtenção de Relatórios RJ/SP
        [Fact]
        public async Task GetAllEpidemiologicalDataForRJAndSP_ShouldReturnRelatorios()
        {
            // Arrange
            var relatorios = new List<Relatorio>
    {
        new Relatorio { Id = 1, Municipio = "Rio de Janeiro", Arbovirose = "Dengue", TotalCasos = 100 },
        new Relatorio { Id = 2, Municipio = "São Paulo", Arbovirose = "Zika", TotalCasos = 50 }
    };

            _mockRelatorioService.Setup(service => service.GetAllEpidemiologicalDataForRJAndSPAsync())
                .ReturnsAsync(relatorios);

            // Act
            var result = await _controller.GetAllEpidemiologicalDataForRJAndSP() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedRelatorios = Assert.IsType<List<Relatorio>>(result.Value);
            Assert.Equal(2, returnedRelatorios.Count);
            Assert.Contains(returnedRelatorios, r => r.Municipio == "Rio de Janeiro");
            Assert.Contains(returnedRelatorios, r => r.Municipio == "São Paulo");
        }


        //Testar Obtenção de Relatórios por Código IBGE
        [Fact]
        public async Task GetByCodigoIbge_ShouldReturnRelatorios()
        {
            // Arrange
            var codigoIbge = "3304557";
            var relatorios = new List<Relatorio>
            {
                new Relatorio { Id = 1, Municipio = "Rio de Janeiro", CodigoIbge = codigoIbge, Arbovirose = "Dengue", TotalCasos = 100 }
            };

            _mockRelatorioService.Setup(service => service.GetByIbgeCodeAsync(codigoIbge))
                .ReturnsAsync(relatorios);

            // Act
            var result = await _controller.GetByCodigoIbge(codigoIbge) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedRelatorios = Assert.IsType<List<Relatorio>>(result.Value);
            Assert.Single(returnedRelatorios);
            Assert.Equal("Rio de Janeiro", returnedRelatorios[0].Municipio);
        }

        //Testar Obtenção de Relatórios por Arbovirose
        [Fact]
        public async Task GetByArbovirose_ShouldReturnRelatorios()
        {
            // Arrange
            var arbovirose = "Dengue";
            var relatorios = new List<Relatorio>
            {
                new Relatorio { Id = 1, Municipio = "Rio de Janeiro", Arbovirose = arbovirose, TotalCasos = 100 }
            };

            _mockRelatorioService.Setup(service => service.GetByArboviroseAsync(arbovirose))
                .ReturnsAsync(relatorios);

            // Act
            var result = await _controller.GetByArbovirose(arbovirose) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var returnedRelatorios = Assert.IsType<List<Relatorio>>(result.Value);
            Assert.Single(returnedRelatorios);
            Assert.Equal("Rio de Janeiro", returnedRelatorios[0].Municipio);
        }


    }


}
