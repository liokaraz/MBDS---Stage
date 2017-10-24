using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class DistributionCarteDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<DistributionCarteVue> search(DistributionCarteVue dcarte)
        {
            conn = new DB().getConn();
            List<DistributionCarteVue> listAll = new List<DistributionCarteVue>();
            try
            {
                string query = "select * from distribution_carte_vue where ";
                if (dcarte.Carte != null)
                    query += "carte =" + dcarte.Carte;
                if (dcarte.Employe != null)
                    query += " and employe =" + dcarte.Employe;
                if (dcarte.Quantite != null)
                    query += " and quantite =" + dcarte.Quantite;
                if (dcarte.Date != null)
                    query += " and date =" + dcarte.Date;

                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    DistributionCarteVue c = new DistributionCarteVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4));
                    listAll.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributinDao=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(DistributionCarte dcarte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from distribution_carte where id = " + dcarte.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans distributionCarte=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public DistributionCarteVue findById(int id)
        {
            conn = new DB().getConn();
            DistributionCarteVue dcarte = null;
            try
            {
                string query = "select * from distribution_carte_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    dcarte = new DistributionCarteVue(reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteDao=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return dcarte;
        }

        public void insert(DistributionCarte dcarte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into distribution_carte (id, carte, employe, quantite, date) values"
                +" (nextval('seq_distribution_carte')," + dcarte.Carte.Id + "," + dcarte.Employe.Id + "," 
                + dcarte.Quantite + ",'" + dcarte.Date + "')";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteDao=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<DistributionCarteVue> getAll()
        {
            List<DistributionCarteVue> listAll = new List<DistributionCarteVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from distribution_carte_vue order by id DESC";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    DistributionCarteVue dcarte = new DistributionCarteVue(reader.GetInt32(0), reader.GetString(1), 
                        reader.GetString(2),reader.GetInt32(3), reader.GetDateTime(4));
                    listAll.Add(dcarte);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteVue->getAll" + e.Message);
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