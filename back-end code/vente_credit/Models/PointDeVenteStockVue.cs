using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class PointDeVenteStockVue
    {
        private int id;
        private string pointDeVente;
        private string zoneTravail;
        private string latitude;
        private string longitude;
        private int stock;

        public PointDeVenteStockVue(int id)
        {
            this.Id = id;
        }

        public PointDeVenteStockVue(int id, string pointDeVente, string zoneTravail, 
            string latitude, string longitude, int stock)
        {
            this.Id = id;
            this.PointDeVente = pointDeVente;
            this.ZoneTravail = zoneTravail;
            this.Latitude = latitude;
            this.Longitude = Longitude;
            this.Stock = stock;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PointDeVente
        {
            get { return pointDeVente; }
            set { pointDeVente = value; }
        }

        public string ZoneTravail
        {
            get { return zoneTravail; }
            set { zoneTravail = value; }
        }

        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        
    }
}