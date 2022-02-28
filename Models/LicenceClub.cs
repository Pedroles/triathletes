using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class LicenceClub
    {
        public int LicId { get; set; }
        public int? ClubId { get; set; }
        public int ClubIdAdherer { get; set; }
        public DateTime? LicDatePremiereLice { get; set; }

        public virtual Club Club { get; set; }
        public virtual Club ClubIdAdhererNavigation { get; set; }
        public virtual Licence Lic { get; set; }
    }
}
