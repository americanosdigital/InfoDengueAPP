using InfoDengueAPP.Domain.Entities;
using InfoDengueAPP.INFRASTRUCTURE.Repositories.Interfaces;
using InfoDengueAPP.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoDengueAPP.SERVICES
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitanteRepository _solicitanteRepository;

        public SolicitanteService(ISolicitanteRepository solicitanteRepository)
        {
            _solicitanteRepository = solicitanteRepository;
        }

        public async Task<Solicitante> GetByCpfAsync(string cpf)
        {
            return await _solicitanteRepository.GetByCpfAsync(cpf);
        }

        public async Task AddAsync(Solicitante solicitante)
        {
            await _solicitanteRepository.AddAsync(solicitante);
        }

        public async Task<List<Solicitante>> GetAllAsync()
        {
            return await _solicitanteRepository.GetAllAsync();
        }
    }

}
