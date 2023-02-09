using System.Collections.Generic;

namespace GEMEscolar.Core.Models
{
    public class InformacoesDePainelModelo
    {
        public List<InadiplentesModel> Inadiplentes { get; set; } = new List<InadiplentesModel>();
        public List<AlunoCriadoRecenteModel> AlunoCriadoRecenteModels { get; set; } = new List<AlunoCriadoRecenteModel>();
        
    }
}
