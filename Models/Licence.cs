using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class Licence
    {
        public Licence()
        {
            Inscriptions = new HashSet<Inscription>();
        }

        public int LicId { get; set; }
        public int CatId { get; set; }
        public byte[] LicPhoto { get; set; }
        public string LicNom { get; set; }
        public string LicPrenom { get; set; }
        public string LicSexe { get; set; }
        public string LicEmail { get; set; }
        public string LicRue { get; set; }
        public string LicCodePostal { get; set; }
        public string LicVille { get; set; }
        public DateTime? LicDateNaissance { get; set; }

        public virtual Categorie Cat { get; set; }
        public virtual LicenceClub LicenceClub { get; set; }
        public virtual ICollection<Inscription> Inscriptions { get; set; }
    }
}
