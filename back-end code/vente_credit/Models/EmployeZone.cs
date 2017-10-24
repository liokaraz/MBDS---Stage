using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class EmployeZone
    {
        private int id;
        private Employe employe;
        private ZoneDeTravail zoneTravail;

        public EmployeZone(int id, Employe employe, ZoneDeTravail zoneTravail)
        {
            this.Id = id;
            this.Employe = employe;
            this.ZoneTravail = zoneTravail;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Employe Employe
        {
            get { return employe; }
            set { employe = value; }
        }

        public ZoneDeTravail ZoneTravail
        {
            get { return zoneTravail; }
            set { zoneTravail = value; }
        }
    }
}