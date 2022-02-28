using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class Club
    {
        public Club()
        {
            LicenceClubClubIdAdhererNavigations = new HashSet<LicenceClub>();
            LicenceClubClubs = new HashSet<LicenceClub>();
        }

        public int ClubId { get; set; }
        public string ClubNom { get; set; }
        public string ClubRue { get; set; }
        public string ClubTel { get; set; }
        public string ClubVille { get; set; }
        public string ClubCp { get; set; }

        public virtual ICollection<LicenceClub> LicenceClubClubIdAdhererNavigations { get; set; }
        public virtual ICollection<LicenceClub> LicenceClubClubs { get; set; }
    }
}
