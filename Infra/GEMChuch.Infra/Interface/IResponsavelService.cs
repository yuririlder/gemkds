using GEMEscolar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Interface
{
    public interface IResponsavelService
    {
        Responsavel GetResponsavelPeloCPF(string documento);
        List<Responsavel> GetTodosResponsaveis();
    }
}
