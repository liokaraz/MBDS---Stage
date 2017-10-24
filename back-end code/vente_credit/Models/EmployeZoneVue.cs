using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vente_credit.Models
{
    public class EmployeZoneVue
    {
        private int id;
        private string employe;
        private string zoneTravail;

        public EmployeZoneVue(int id, string employe, string zoneTravail)
        {
            this.Id = id;
            this.Employe = employe;
            this.ZoneTravail = ZoneTravail;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Employe
        {
            get { return employe; }
            set { employe = value; }
        }

        public string ZoneTravail
        {
            get { return zoneTravail; }
            set { zoneTravail = value; }
        }
    }
}