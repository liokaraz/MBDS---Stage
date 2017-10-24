using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class ZoneDeTravailDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<ZoneDeTravail> search(ZoneDeTravail zoneTrav)
        {
            conn = new DB().getConn();
            List<ZoneDeTravail> listAll = new List<ZoneDeTravail>();
            try
            {
                string query = "select * from zone_travail when ";
                if (zoneTrav.Libelle != null)
                    query += "libelle =" + zoneTrav.Libelle;


                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    ZoneDeTravail zTrav = new ZoneDeTravail(reader.GetInt16(0), reader.GetString(1));
                    listAll.Add(zTrav);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans ZoneDeTravailDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(ZoneDeTravail zoneTrav)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from zone_travail where id = " + zoneTrav.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans ZoneDeTravailDAO=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public ZoneDeTravail findById(int id)
        {
            conn = new DB().getConn();
            ZoneDeTravail zoneTrav = null;
            try
            {
                string query = "select * from zone_travail where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    zoneTrav = new ZoneDeTravail(reader.GetInt16(0), reader.GetString(1));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans ZoneTravail=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return zoneTrav;
        }

        public void insert(ZoneDeTravail zoneTrav)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into zone_travail (id,libelle) values (nextval('seq_zone_travail')," + zoneTrav.Libelle + ")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans ZoneDeTravailDAO=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<ZoneDeTravail> getAll()
        {
            List<ZoneDeTravail> listAll = new List<ZoneDeTravail>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from zone_travail";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    ZoneDeTravail zoneTrav = new ZoneDeTravail(reader.GetInt16(0), reader.GetString(1));
                    listAll.Add(zoneTrav);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans ZoneDeTravailDAO->getAll" + e.Message);
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