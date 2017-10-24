using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class LivraisonCarte
    {
        private int id;
        private EmployeStock employeStock;
        private int quantite;
        private int resteNonVendu;
        private DateTime date;
        private PointDeVente pointDeVente;
        private DistributionCarte idDistribution;

        public LivraisonCarte(EmployeStock employeStock, int quantite,
            int resteNonVendu, DateTime date, PointDeVente pointDeVente)
        {
            this.EmployeStock = employeStock;
            this.Quantite = quantite;
            this.ResteNonVendu = resteNonVendu;
            this.Date = date;
            this.PointDeVente = pointDeVente;
        }

        public LivraisonCarte(EmployeStock employeStock, int quantite,
            int resteNonVendu, DateTime date, PointDeVente pointDeVente, DistributionCarte idDistribution)
        {
            this.EmployeStock = employeStock;
            this.Quantite = quantite;
            this.ResteNonVendu = resteNonVendu;
            this.Date = date;
            this.PointDeVente = pointDeVente;
            this.IdDistribution = idDistribution;
        }

        public LivraisonCarte(int id, EmployeStock employeStock, int quantite,
            int resteNonVendu, DateTime date, PointDeVente pointDeVente, DistributionCarte idDistribution)
        {
            this.Id = id;
            this.EmployeStock = employeStock;
            this.Quantite = quantite;
            this.ResteNonVendu = resteNonVendu;
            this.Date = date;
            this.PointDeVente = pointDeVente;
            this.IdDistribution = idDistribution;
        }

        public LivraisonCarte(EmployeStock employeStock)
        {
            this.EmployeStock = employeStock;
        }

        public LivraisonCarte(int id)
        {
            this.Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public EmployeStock EmployeStock
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

        public PointDeVente PointDeVente
        {
            get { return pointDeVente; }
            set { pointDeVente = value; }
        }

        public DistributionCarte IdDistribution
        {
            get { return idDistribution; }
            set { idDistribution = value; }
        }
    }
}