using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class ProduitDopant
    {
        public ProduitDopant()
        {
            Controlers = new HashSet<Controler>();
        }

        public int DopId { get; set; }
        public string DopLibelle { get; set; }
        public decimal? DopTauxMax { get; set; }

        public virtual ICollection<Controler> Controlers { get; set; }
    }
}
