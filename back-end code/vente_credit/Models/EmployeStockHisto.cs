using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class EmployeStockHisto : EmployeStock
    {

        public EmployeStockHisto(int id)
        {
            this.Id = id;
        }

        public EmployeStockHisto(int id, int employe, int stock, int carte)
        {
            this.Id = id;
            this.Employe = employe;
            this.Stock = stock;
            this.Carte = carte;
        }

        public EmployeStockHisto(int employe, int stock, int carte)
        {
            this.Employe = employe;
            this.Stock = stock;
            this.Carte = carte;
        }
    }
}