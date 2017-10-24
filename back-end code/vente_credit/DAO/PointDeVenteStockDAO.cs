using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class PointDeVenteStockDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<PointDeVenteStockVue> search(PointDeVenteStockVue pv)
        {
            conn = new DB().getConn();
            List<PointDeVenteStockVue> listAll = new List<PointDeVenteStockVue>();
            try
            {
                string query = "select * from point_de_stock_vue where ";
                if (pv.PointDeVente != null)
                    query += " point_de_vente = " + pv.PointDeVente;
                if (pv.ZoneTravail != null)
                    query += " and zone_travail = " + pv.ZoneTravail;
                if (pv.Latitude != null)
                    query += " and latitude = " + pv.Latitude;
                if(pv.Longitude != null)
                    query += " and longitude = " +pv.Longitude;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    PointDeVenteStockVue pvs = new PointDeVenteStockVue(reader.GetInt16(0), reader.GetString(1), reader.GetString(2),
                       reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                    listAll.Add(pvs);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(PointDeVenteStock pv)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from point_de_vente_stock where id = " + pv.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockDAO=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public PointDeVenteStockVue findById(int id)
        {
            conn = new DB().getConn();
            PointDeVenteStockVue pv = null;
            try
            {
                string query = "select * from point_de_vente_stock_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    pv = new PointDeVenteStockVue(reader.GetInt16(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockDAO=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return pv;
        }

        public void insert(PointDeVenteStock pv)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into point_de_vente (id,point_de_vente,stock) values (nextval('sq_pv_stock')," 
                    + pv.PointDeVente + "," + pv.Stock + ")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockDAO=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<PointDeVenteStockVue> getAll()
        {
            List<PointDeVenteStockVue> listAll = new List<PointDeVenteStockVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from point_de_vente_stock_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    PointDeVenteStockVue pv = new PointDeVenteStockVue(reader.GetInt16(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                    listAll.Add(pv);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockDAO->getAll" + e.Message + e.StackTrace);
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