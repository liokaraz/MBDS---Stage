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
    public class VenteCarteDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<VenteCarteVue> search(VenteCarteVue carte)
        {
            conn = new DB().getConn();
            List<VenteCarteVue> listAll = new List<VenteCarteVue>();
            try
            {
                string query = "select * from vente_carte_vue where 1<2 ";
                if (carte.Livraison != 0)
                    query += " and livraison =" + carte.Livraison;
                if (carte.Quantite != 0)
                    query += " and quantite =" + carte.Quantite;
                if (carte.Point_de_vente != null)
                    query += " and point_de_vente ='" + carte.Point_de_vente + "'";

                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    VenteCarteVue c = new VenteCarteVue(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                        reader.GetString(3), reader.GetDateTime(4));
                    listAll.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(VenteCarte carte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from vente_carte where id = " + carte.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteDAO=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public VenteCarteVue findById(int id)
        {
            conn = new DB().getConn();
            VenteCarteVue carte = null;
            try
            {
                string query = "select * from vente_carte_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    carte = new VenteCarteVue(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                        reader.GetString(3), reader.GetDateTime(4));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteDAO=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return carte;
        }

        public void insert(VenteCarte carte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into vente_carte (id,livraison,quantite,point_de_vente,date_vente) values (nextval('seq_carte_vente')," + carte.Livraison.Id + ","
                + carte.Quantite + "," + carte.Point_de_vente.Id + ",'" + carte.Date_vente + "')";
                Debug.WriteLine(query);
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteDAO=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<VenteCarteVue> getAll()
        {
            List<VenteCarteVue> listAll = new List<VenteCarteVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from vente_carte_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    VenteCarteVue carte = new VenteCarteVue(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),
                        reader.GetString(3), reader.GetDateTime(4));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteDAO->getAll" + e.Message);
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