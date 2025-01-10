using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoDengueAPP.Domain.Entities
{
    public class Relatorio
    {
        public int Id { get; set; }
        public string Municipio { get; set; }
        public string CodigoIbge { get; set; }
        public string Arbovirose { get; set; }
        public int TotalCasos { get; set; }
        public DateTime DataSolicitacao { get; set; }

        public int SolicitanteId { get; set; }
        public Solicitante Solicitante { get; set; }
    }
}
