using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class DistributionCarte
    {
        private int id;
        private Carte carte;
        private Employe employe;
        private int quantite;
        private DateTime date;

        public DistributionCarte(int id)
        {
            this.Id = id;
        }

        public DistributionCarte(int id, Carte carte, Employe employe, int quantite, DateTime date)
        {
            this.Id = id;
            this.Carte = carte;
            this.Employe = employe;
            this.Quantite = quantite;
            this.Date = date;
        }

        public DistributionCarte(Carte carte, Employe employe, int quantite, DateTime date)
        {
            this.Carte = carte;
            this.Employe = employe;
            this.Quantite = quantite;
            this.Date = date;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Carte Carte
        {
            get { return carte; }
            set { carte = value; }
        }

        public Employe Employe
        {
            get { return employe; }
            set { employe = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}