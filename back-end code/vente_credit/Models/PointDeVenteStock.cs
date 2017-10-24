using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class PointDeVenteStock
    {
        private int id;
        private int pointDeVente;
        private int stock;

        public PointDeVenteStock(int id)
        {
            this.Id = id;
        }

        public PointDeVenteStock(int id, int poinDeVente, int stock)
        {
            this.Id = id;
            this.PointDeVente = poinDeVente;
            this.Stock = stock;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int PointDeVente
        {
            get { return pointDeVente; }
            set { pointDeVente = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }


    }
}