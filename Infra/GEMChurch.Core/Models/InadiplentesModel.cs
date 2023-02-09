using GEMEscolar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMEscolar.Core.Models
{
    public class InadiplentesModel
    {
        public Guid Id { get; set; }
        public string NomeAluno { get; set; }
        public string NomeResponsavel { get; set; }
        public int QntidadeDeparcelas { get; set; }
        public double ValorTotal { get; set; }
        public string Telefone { get; set; }
    }
}
