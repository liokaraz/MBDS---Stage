using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class LivraisonCarteVue
    {
        private int id;
        private int employeStock;
        private int quantite;
        private int resteNonVendu;
        private DateTime date;
        private string pointDeVente;
        private int idDistribution;

        public LivraisonCarteVue(int id, int employeStock, int quantite, int resteNonVendu,
            DateTime date, string pointDeVente, int idDistribution)
        {
            this.Id = id;
            this.EmployeStock = employeStock;
            this.Quantite = quantite;
            this.ResteNonVendu = resteNonVendu;
            this.Date = date;
            this.PointDeVente = pointDeVente;
            this.IdDistribution = idDistribution;
        }

        public LivraisonCarteVue(int employeStock)
        {
            this.EmployeStock = employeStock;
            //this.Date = null;
        }

        public LivraisonCarteVue(string poinDeVente)
        {
            this.PointDeVente = poinDeVente;
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

        public int IdDistribution
        {
            get { return idDistribution; }
            set { idDistribution = value; }
        }
    }
}