using InfoDengueAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoDengueAPP.SERVICES.Interfaces
{
    public interface ISolicitanteService
    {
        Task<Solicitante> GetByCpfAsync(string cpf);
        Task AddAsync(Solicitante solicitante);
        Task<List<Solicitante>> GetAllAsync();
    }
}
