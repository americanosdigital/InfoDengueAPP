using InfoDengueAPP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoDengueAPP.SERVICES.Interfaces
{
    public interface IRelatorioService
    {
        Task<List<Relatorio>> GetAllEpidemiologicalDataForRJAndSPAsync();
        Task<List<Relatorio>> GetByIbgeCodeAsync(string codigoIbge);
        Task<List<Relatorio>> GetByArboviroseAsync(string arbovirose);
        Task AddAsync(Relatorio relatorio);
        Task<List<Relatorio>> GetAllAsync();

    }
}
