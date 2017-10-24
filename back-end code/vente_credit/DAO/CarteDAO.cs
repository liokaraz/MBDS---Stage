using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class CarteDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<Carte> search(Carte carte)
        {
            conn = new DB().getConn();
            List<Carte> listAll = new List<Carte>();
            try
            {
                string query = "select * from carte when ";
                if (carte.Libelle != null)
                    query += "libelel =" + carte.Libelle;
                if (carte.Valeur != null)
                    query += " and valeur =" + carte.Valeur;

                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    Carte c = new Carte(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2));
                    listAll.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteDao=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(Carte carte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from carte where id = " + carte.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteDao=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public Carte findById(int id)
        {
            conn = new DB().getConn();
            Carte carte = null;
            try
            {
                string query = "select * from carte where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    carte = new Carte(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteDao=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return carte;
        }

        public void insert(Carte carte)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into cartes (id,libelle,valeur) values (nextval('seq_carte')," + carte.Libelle + ","
                + carte.Valeur + ")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteDao=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Carte> getAll()
        {
            List<Carte> listAll = new List<Carte>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from carte";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    Carte carte = new Carte(reader.GetInt16(0), reader.GetString(1), reader.GetInt32(2));
                    listAll.Add(carte);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteDao->getAll" + e.Message);
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