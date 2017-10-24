using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class LivraisonCartePVVueDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<LivraisonCartePVVue> search(LivraisonCartePVVue carte)
        {
            conn = new DB().getConn();
            List<LivraisonCartePVVue> listAll = new List<LivraisonCartePVVue>();
            try
            {
                string query = "select * from livraison_carte_pv where 1<2 ";
                if (carte.EmployeStock != 0)
                    query += " and employe_stock =" + carte.EmployeStock;
                if (carte.Carte != null)
                    query += " and carte ='" + carte.Carte + "'";
                if (carte.Coursier != null)
                    query += " and coursier ='" + carte.Coursier + "'";
                if (carte.Quantite != 0)
                    query += " and quantite =" + carte.Quantite;
                if (carte.ResteNonVendu != 0)
                    query += " and reste_non_vendu =" + carte.ResteNonVendu;
                //if (carte.Date != null)
                // query += " and date_livraison =" + carte.Date;
                if (carte.PointDeVente != null)
                    query += " and point_de_vente = '" + carte.PointDeVente + "'";
                query += " order by id DESC";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    LivraisonCartePVVue c = new LivraisonCartePVVue(reader.GetInt32(0),
                        reader.GetInt16(1), reader.GetString(2), reader.GetString(3), 
                        reader.GetInt32(4), reader.GetInt32(5), reader.GetDateTime(6),
                        reader.GetString(7));
                    listAll.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCartePVVueDAO=>search " + e.Message + e.StackTrace);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }


        public LivraisonCartePVVue findById(int id)
        {
            conn = new DB().getConn();
            LivraisonCartePVVue carte = null;
            try
            {
                string query = "select * from livraison_carte_pv where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    LivraisonCartePVVue c = new LivraisonCartePVVue(reader.GetInt32(0),
                        reader.GetInt16(1), reader.GetString(2), reader.GetString(3),
                        reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(5),
                        reader.GetString(6));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCartePVVueDAO=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return carte;
        }

        public List<LivraisonCartePVVue> getAll()
        {
            List<LivraisonCartePVVue> listAll = new List<LivraisonCartePVVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from livraison_carte_pv";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    LivraisonCartePVVue carte = new LivraisonCartePVVue(reader.GetInt32(0),
                        reader.GetInt16(1), reader.GetString(2), reader.GetString(3),
                        reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(5),
                        reader.GetString(6));
                    listAll.Add(carte);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCartePVVueDAO->getAll" + e.Message);
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