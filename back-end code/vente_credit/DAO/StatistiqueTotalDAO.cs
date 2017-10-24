using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class StatistiqueTotalDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<StatistiqueTotal> search(StatistiqueTotal stat)
        {
            conn = new DB().getConn();
            List<StatistiqueTotal> listAll = new List<StatistiqueTotal>();
            try
            {
                string query = "select * from statistique_total where 1<2 ";
                if (stat.Carte != null)
                    query += " and carte =" + stat.Carte;   
                if (stat.Quantite != 0)
                    query += " and quantite =" + stat.Quantite;

                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    StatistiqueTotal statTotal = new StatistiqueTotal(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2));
                    listAll.Add(statTotal);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueTotalDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public StatistiqueTotal findById(int id)
        {
            conn = new DB().getConn();
            StatistiqueTotal stat = null;
            try
            {
                string query = "select * from statistique_total where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    stat = new StatistiqueTotal(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueTotalDAO=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return stat;
        }

        public List<StatistiqueTotal> getAll()
        {
            List<StatistiqueTotal> listAll = new List<StatistiqueTotal>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from statistique_total";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    StatistiqueTotal stat = new StatistiqueTotal(reader.GetInt16(0), reader.GetString(1), reader.GetInt64(2));
                    listAll.Add(stat);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueTotalDAO->getAll" + e.Message + e.StackTrace);
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