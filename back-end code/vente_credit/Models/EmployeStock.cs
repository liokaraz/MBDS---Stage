using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class EmployeStock
    {
        private int id;
        private int employe;
        private int stock;
        private int carte;

        public EmployeStock()
        {

        }

        public EmployeStock(int id)
        {
            this.Id = id;
        }

        public EmployeStock(int id, int stock)
        {
            this.Id = id;
            this.Stock = stock;
        }

        public EmployeStock(int id, int employe, int stock, int carte)
        {
            this.Id = id;
            this.Employe = employe;
            this.Stock = stock;
            this.Carte = carte;
        }

        public EmployeStock(int employe, int stock, int carte)
        {
            this.Employe = employe;
            this.Stock = stock;
            this.Carte = carte;
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Employe
        {
            get { return employe; }
            set { employe = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public int Carte
        {
            get { return carte; }
            set { carte = value; }
        }
    }
}