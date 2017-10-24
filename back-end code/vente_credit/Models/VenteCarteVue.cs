using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class VenteCarteVue
    {
        private int id;
        private int livraison;
        private int quantite;
        private string point_de_vente;
        private DateTime date_vente;

        public VenteCarteVue()
        {

        }

        public VenteCarteVue(int id, int livraison, int quantite, string point_de_vente, DateTime date_vente)
        {
            this.Id = id;
            this.Quantite = quantite;
            this.Point_de_vente = point_de_vente;
            this.Date_vente = date_vente;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Livraison
        {
            get { return livraison; }
            set { livraison = value; }
        }

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }

        public string Point_de_vente
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