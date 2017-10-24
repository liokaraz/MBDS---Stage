using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class PointDeVente
    {
        private int id;
        private ZoneDeTravail zoneDeTravail;
        private string libelle;
        private string latitude;
        private string longitude;
        private Employe responsable;

        public PointDeVente(int id)
        {
            this.Id = id;
        }

        public PointDeVente(int id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        public PointDeVente(int id, ZoneDeTravail zoneDeTravail, string libelle, 
            string latitude, string longitude, Employe responsable)
        {
            this.Id = id;
            this.ZoneDeTravail = zoneDeTravail;
            this.Libelle = libelle;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Responsable = responsable;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public ZoneDeTravail ZoneDeTravail
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

        public Employe Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }
    }
}