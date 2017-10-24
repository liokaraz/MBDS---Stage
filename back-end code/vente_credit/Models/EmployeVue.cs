using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class EmployeVue
    {
        private int id;
        private string nom;
        private string prenom;
        private int age;
        private string sexe;
        private string email;
        private string contact;
        private string typeEmploye;

        public EmployeVue(int id, string nom, string prenom, int age, string sexe, string email,
            string concat, string typeEmploye)
        {
            this.Id = id;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Age = age;
            this.Sexe = sexe;
            this.Email = email;
            this.Contact = contact;
            this.TypeEmploye = typeEmploye;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public string TypeEmploye
        {
            get { return typeEmploye; }
            set { typeEmploye = value; }
        }
    }
}