using System;
using System.Collections.Generic;

#nullable disable

namespace triathletes.Models
{
    public partial class Controler
    {
        public int TriId { get; set; }
        public int InscDossard { get; set; }
        public int DopId { get; set; }
        public decimal? ControleRésultat { get; set; }

        public virtual ProduitDopant Dop { get; set; }
        public virtual Inscription Inscription { get; set; }
    }
}
