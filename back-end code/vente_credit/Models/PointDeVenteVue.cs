using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class PointDeVenteVue
    {
        private int id;
        private string zoneDeTravail;
        private string libelle;
        private string latitude;
        private string longitude;
        private string responsable;

        public PointDeVenteVue(int id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        public PointDeVenteVue(int id, string zoneDeTravail, string libelle, 
            string latitude, string longitude, string responsable)
        {
            this.Id = id;
            this.ZoneDeTravail = zoneDeTravail;
            this.Libelle = libelle;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Responsable = responsable;
        }

        public PointDeVenteVue(string responsable)
        {
            this.Responsable = responsable;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ZoneDeTravail
        {
            get { return zoneDeTravail; }
            set { zoneDeTravail = value; }
        }

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
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

        public string Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }
    }
}