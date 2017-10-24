using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class DistributionCarteVue
    {
        private int id;
        private string carte;
        private string employe;
        private int quantite;
        private DateTime date;

        public DistributionCarteVue(int id, string carte, string employe, int quantite, DateTime date)
        {
            this.Id = id;
            this.Carte = carte;
            this.Employe = employe;
            this.Quantite = quantite;
            this.Date =date;
        }

        public DistributionCarteVue(int id)
        {
            this.Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Carte
        {
            get { return carte; }
            set { carte = value; }
        }

        public String Employe
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