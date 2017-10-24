using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class Carte
    {
        private int id;
        private string libelle;
        private int valeur;

        public Carte(int id, string libelle, int valeur)
        {
            this.Id = id;
            this.Libelle = libelle;
            this.Valeur = valeur;
        }

        public Carte(int id)
        {
            this.Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        public int Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }
    }
}