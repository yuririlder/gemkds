using GEMEscolar.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMEscolar.Infra.Interface
{
    public interface IHomeService
    {
        Task<InformacoesDePainelModelo> CarregarInformacoesDePainel();
    }
}
