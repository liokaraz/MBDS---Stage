using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class Utilisateur
    {
        private int id;
        private TypeUtilisateur typeUtilisateur;
        private Employe employe;
        private string login;
        private string password;

        public Utilisateur(int id, TypeUtilisateur typeUtilisateur, Employe employe, string login, string password)
        {
            this.Id = id;
            this.TypeUtilisateur = typeUtilisateur;
            this.Employe = employe;
            this.Login = login;
            this.Password = password;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public TypeUtilisateur TypeUtilisateur
        {
            get { return typeUtilisateur; }
            set { typeUtilisateur = value; }
        }

        public Employe Employe
        {
            get { return employe; }
            set { employe = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}