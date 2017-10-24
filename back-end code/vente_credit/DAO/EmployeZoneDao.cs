using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class EmployeZoneDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<EmployeZoneVue> search(EmployeZoneVue empZone)
        {
            conn = new DB().getConn();
            List<EmployeZoneVue> listAll = new List<EmployeZoneVue>();
            try
            {
                string query = "select * from employe_zone_vue when ";
                if (empZone.Employe != null)
                    query += "employe =" + empZone.Employe;
                if (empZone.ZoneTravail != null)
                    query += " and zone_travail =" + empZone.ZoneTravail;

                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeZoneVue emp = new EmployeZoneVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2));
                    listAll.Add(emp);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeZoneDao=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(EmployeZone empZone)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from employe_zone where id = " + empZone.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeZoneDao=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public EmployeZoneVue findById(int id)
        {
            conn = new DB().getConn();
            EmployeZoneVue empZone = null;
            try
            {
                string query = "select * from employe_zone_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    empZone = new EmployeZoneVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeZoneDao=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return empZone;
        }

        public void insert(EmployeZone empZone)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into employe_zone (id, employe, zone_travail) values"
                + " (nextval('seq_zone_travail')," + empZone.Employe.Id + "," + empZone.ZoneTravail.Id + ")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeZoneDao=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<EmployeZoneVue> getAll()
        {
            List<EmployeZoneVue> listAll = new List<EmployeZoneVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from employe_zone_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeZoneVue employezone = new EmployeZoneVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2));
                    listAll.Add(employezone);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeZoneDao->getAll" + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }
    }
}