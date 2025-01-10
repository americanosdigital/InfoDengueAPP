using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InfoDengueAPP.Domain.Entities;
using InfoDengueAPP.INFRASTRUCTURE.Repositories.Interfaces;
using InfoDengueAPP.SERVICES.Interfaces;


namespace InfoDengueAPP.SERVICES
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioService(IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;
        }

        public async Task<List<Relatorio>> GetAllEpidemiologicalDataForRJAndSPAsync()
        {
            return await _relatorioRepository.GetAllEpidemiologicalDataForRJAndSPAsync();
        }

        public async Task<List<Relatorio>> GetByIbgeCodeAsync(string codigoIbge)
        {
            return await _relatorioRepository.GetByIbgeCodeAsync(codigoIbge);
        }

        public async Task<List<Relatorio>> GetByArboviroseAsync(string arbovirose)
        {
            return await _relatorioRepository.GetByArboviroseAsync(arbovirose);
        }

        public async Task AddAsync(Relatorio relatorio)
        {
            await _relatorioRepository.AddAsync(relatorio);
        }

        public async Task<List<Relatorio>> GetAllAsync()
        {
            return await _relatorioRepository.GetAllAsync();
        }
    }

}
