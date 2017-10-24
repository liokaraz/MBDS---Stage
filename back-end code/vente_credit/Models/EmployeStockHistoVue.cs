using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class EmployeStockHistoVue : EmployeStockVue
    {
        public EmployeStockHistoVue()
        {

        }

        public EmployeStockHistoVue(int id, string nom, string prenom, int age, string sexe,
            string email, string contact, string typeEmploye, int stock, string carte)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Sexe = sexe;
            this.Email = email;
            this.Contact = contact;
            this.TypeEmploye = typeEmploye;
            this.Stock = stock;
            this.Carte = carte;
        }

        public EmployeStockHistoVue(string nom, string prenom)
        {
            this.Nom = nom;
            this.Prenom = prenom;
        }
    }
}