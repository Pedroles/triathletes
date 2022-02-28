using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class Triathlon
    {
        public Triathlon()
        {
            Inscriptions = new HashSet<Inscription>();
        }

        public int TriId { get; set; }
        public int TypeId { get; set; }
        public string TriNom { get; set; }
        public DateTime? TriDate { get; set; }
        public string TriLieu { get; set; }
        public string TriVille { get; set; }
        public string TriCp { get; set; }

        public virtual TypeTriathlon Type { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
