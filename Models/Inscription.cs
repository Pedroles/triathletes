using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class Inscription
    {
        public Inscription()
        {
            Controlers = new HashSet<Controler>();
        }

        public int TriId { get; set; }
        public int InscDossard { get; set; }
        public int LicId { get; set; }
        public int? InscClassement { get; set; }
        public DateTime? InscDateInscription { get; set; }
        public decimal? InscTempsNatation { get; set; }
        public decimal? InscTempsVelo { get; set; }
        public decimal? InscTempsCourse { get; set; }
        public bool? InscForfait { get; set; }

        public virtual Licence Lic { get; set; }
        public virtual Triathlon Tri { get; set; }
        public virtual ICollection<Controler> Controlers { get; set; }
    }
}
