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
    public class SolicitanteRepository : ISolicitanteRepository
    {
        private readonly AppDbContext _context;

        public SolicitanteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Solicitante> GetByCpfAsync(string cpf)
        {
            return await _context.Solicitantes.FirstOrDefaultAsync(s => s.Cpf == cpf);
        }

        public async Task AddAsync(Solicitante solicitante)
        {
            _context.Solicitantes.Add(solicitante);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Solicitante>> GetAllAsync()
        {
            return await _context.Solicitantes.ToListAsync();
        }
    }
}
