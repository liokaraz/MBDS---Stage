using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class StatistiqueTotal
    {
        private int id;
        private string carte;
        private Int64 quantite;

        public StatistiqueTotal(int id, string carte, Int64 quantite)
        {
            this.Id = id;
            this.Carte = carte;
            this.Quantite = quantite;
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

        public Int64 Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }


    }
}