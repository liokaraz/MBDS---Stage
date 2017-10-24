using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class LivraisonCartePVVue
    {
        private int id;
        private int employeStock;
        private string carte;
        private string coursier;
        private int quantite;
        private int resteNonVendu;
        private DateTime date;
        private string pointDeVente;

        public LivraisonCartePVVue(int id, int employeStock, string carte, string coursier,
            int quantite, int resteNonVendu, DateTime date, string pointDeVente)
        {
            this.Id = id;
            this.EmployeStock = employeStock;
            this.Carte = carte;
            this.Coursier = coursier;
            this.Quantite = quantite;
            this.ResteNonVendu = resteNonVendu;
            this.Date = date;
            this.PointDeVente = pointDeVente;
        }

        public LivraisonCartePVVue(string pointDeVente)
        {
            this.PointDeVente = pointDeVente;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int EmployeStock
        {
            get { return employeStock; }
            set { employeStock = value; }
        }

        public string Carte
        {
            get { return carte; }
            set { carte = value; }
        }

        public string Coursier
        {
            get { return coursier; }
            set { coursier = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public int ResteNonVendu
        {
            get { return resteNonVendu; }
            set { resteNonVendu = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string PointDeVente
        {
            get { return pointDeVente; }
            set { pointDeVente = value; }
        }
    }
}