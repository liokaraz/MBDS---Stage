using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class StatistiqueLivraisonCarteDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<StatistiqueLivraisonCarte> search(StatistiqueLivraisonCarte stat)
        {
            conn = new DB().getConn();
            List<StatistiqueLivraisonCarte> listAll = new List<StatistiqueLivraisonCarte>();
            try
            {
                string query = "select * from statistique_livraison_carte where 1<2 ";
                if (stat.Carte != null)
                    query += " and carte =" + stat.Carte;
                if (stat.Quantite != 0)
                    query += " and quantite =" + stat.Quantite;

                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    StatistiqueLivraisonCarte statTotal = new StatistiqueLivraisonCarte(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2));
                    listAll.Add(statTotal);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueLivraisonCarteDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public StatistiqueLivraisonCarte findById(int id)
        {
            conn = new DB().getConn();
            StatistiqueLivraisonCarte stat = null;
            try
            {
                string query = "select * from statistique_livraison_carte where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    stat = new StatistiqueLivraisonCarte(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueLivraisonCarteDAO=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return stat;
        }

        public List<StatistiqueLivraisonCarte> getAll()
        {
            List<StatistiqueLivraisonCarte> listAll = new List<StatistiqueLivraisonCarte>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from statistique_livraison_carte";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    StatistiqueLivraisonCarte stat = new StatistiqueLivraisonCarte(reader.GetInt16(0), reader.GetString(1), reader.GetInt64(2));
                    listAll.Add(stat);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueLivraisonCarteDAO->getAll" + e.Message + e.StackTrace);
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