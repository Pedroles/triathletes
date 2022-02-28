using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Licences = new HashSet<Licence>();
        }

        public int CatId { get; set; }
        public string CatLibelle { get; set; }
        public int? CatAgeDébut { get; set; }
        public int? CatAgeFin { get; set; }

        public virtual ICollection<Licence> Licences { get; set; }
    }
}
