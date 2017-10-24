using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class PourcentageVenteCarte
    {
        private int id;
        private string carte;
        private double pourcentageVente;

        public PourcentageVenteCarte(int id, string carte, double pourcentageVente)
        {
            this.Id = id;
            this.Carte = carte;
            this.PourcentageVente = pourcentageVente;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Carte
        {
            get { return carte; }
            set { carte = value; }
        }

        public double PourcentageVente
        {
            get { return pourcentageVente; }
            set { pourcentageVente = value; }
        }
    }
}