using System;

namespace GEMEscolar.Core.Entities
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    
    }
}
