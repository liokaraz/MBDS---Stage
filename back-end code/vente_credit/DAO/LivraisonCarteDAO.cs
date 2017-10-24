using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;
using System.Diagnostics;

namespace vente_credit.DAO
{
    public class LivraisonCarteDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<LivraisonCarteVue> search(LivraisonCarteVue carte)
        {
            Debug.WriteLine(carte.EmployeStock);
            conn = new DB().getConn();
            List<LivraisonCarteVue> listAll = new List<LivraisonCarteVue>();
            try
            {
                string query = "select * from livraison_carte_vue where 1<2 ";
                if (carte.EmployeStock != 0)
                    query += " and employe_stock ='" + carte.EmployeStock + "' ";
                if (carte.Quantite != 0)
                    query += " and quantite =" + carte.Quantite;
                if (carte.ResteNonVendu != 0)
                    query += " and reste_non_vendu =" + carte.ResteNonVendu;
                //if (carte.Date != null)
                   // query += " and date_livraison =" + carte.Date;
                if (carte.PointDeVente != null)
                    query += " and point_de_vente = '" + carte.PointDeVente + "'";
                if (carte.IdDistribution != 0)
                    query += " and id_distribution =" + carte.IdDistribution;
                query += " order by id DESC";
                Debug.WriteLine(query);
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    LivraisonCarteVue c = new LivraisonCarteVue(reader.GetInt32(0),
                        reader.GetInt16(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4),
                        reader.GetString(5), reader.GetInt32(6));
                    listAll.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteDao=>search " + e.Message +e.StackTrace);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(LivraisonCarte carte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from livraison_carte where id = " + carte.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteDao=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public LivraisonCarteVue findById(int id)
        {
            conn = new DB().getConn();
            LivraisonCarteVue carte = null;
            try
            {
                string query = "select * from livraison_carte_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    carte = new LivraisonCarteVue(reader.GetInt32(0),
                        reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(5),
                        reader.GetString(6), reader.GetInt32(7));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteDao=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return carte;
        }

        public void insert(LivraisonCarte carte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into livraison_carte (id,employe_stock,quantite,"
                +"reste,date_livraison,point_de_vente, id_distribution) values (nextval('seq_livraison_carte')," 
                + carte.EmployeStock.Id + "," + carte.Quantite + "," + carte.ResteNonVendu + ",'"
                + carte.Date + "'," + carte.PointDeVente.Id + ", nextval('seq_livraison_carte'))";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteDao=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<LivraisonCarteVue> getAll()
        {
            List<LivraisonCarteVue> listAll = new List<LivraisonCarteVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from livraison_carte_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    LivraisonCarteVue carte = new LivraisonCarteVue(reader.GetInt32(0),
                        reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(5),
                        reader.GetString(6), reader.GetInt32(7));
                    listAll.Add(carte);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteDao->getAll" + e.Message);
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