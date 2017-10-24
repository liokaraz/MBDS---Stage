using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class VenteCarte
    {
        private int id;
        private LivraisonCarte livraison;
        private int quantite;
        private PointDeVente point_de_vente;
        private DateTime date_vente;

        public VenteCarte(int id, LivraisonCarte livraison, int quantite, PointDeVente point_de_vente, DateTime date_vente)
        {
            this.Id = id;
            this.Livraison = livraison;
            this.Quantite = quantite;
            this.Point_de_vente = point_de_vente;
            this.Date_vente = date_vente;
        }

        public VenteCarte(LivraisonCarte livraison, int quantite, PointDeVente point_de_vente, DateTime date_vente)
        {
            this.Livraison = livraison;
            this.Quantite = quantite;
            this.Point_de_vente = point_de_vente;
            this.Date_vente = date_vente;
        }

        public LivraisonCarte Livraison
        {
            get { return livraison; }
            set { livraison = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public PointDeVente Point_de_vente
        {
            get { return point_de_vente; }
            set { point_de_vente = value; }
        }

        public DateTime Date_vente
        {
            get { return date_vente; }
            set { date_vente = value; }
        }


    }
}