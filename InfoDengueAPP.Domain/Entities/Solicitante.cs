using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoDengueAPP.Domain.Entities
{
    public class Solicitante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public ICollection<Relatorio> Relatorios { get; set; }
    }
}
