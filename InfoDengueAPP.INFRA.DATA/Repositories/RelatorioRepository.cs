using InfoDengueAPP.Domain.Entities;
using InfoDengueAPP.INFRASTRUCTURE.DbContexts;
using InfoDengueAPP.INFRASTRUCTURE.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoDengueAPP.INFRASTRUCTURE.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Relatorio>> GetAllEpidemiologicalDataForRJAndSPAsync()
        {
            return await _context.Relatorios
                .Where(r => r.Municipio == "Rio de Janeiro" || r.Municipio == "São Paulo")
                .ToListAsync();
        }

        public async Task<List<Relatorio>> GetByIbgeCodeAsync(string codigoIbge)
        {
            return await _context.Relatorios.Where(r => r.CodigoIbge == codigoIbge).ToListAsync();
        }

        public async Task<List<Relatorio>> GetByArboviroseAsync(string arbovirose)
        {
            return await _context.Relatorios.Where(r => r.Arbovirose == arbovirose).ToListAsync();
        }

        public async Task AddAsync(Relatorio relatorio)
        {
            _context.Relatorios.Add(relatorio);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Relatorio>> GetAllAsync()
        {
            return await _context.Relatorios.ToListAsync();
        }

    }

}
