using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.utilities;
using vente_credit.Models;

namespace vente_credit.DAO
{
    public class UserDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlDataReader reader;
        private NpgsqlCommand cmd;


        public List<UtilisateurVue> search(UtilisateurVue user)
        {
            conn = new DB().getConn();
            List<UtilisateurVue> listAll = new List<UtilisateurVue>();
            try
            {
                Console.Write("lioka");
                string query = "select * from user_vue where ";
                Console.Write("1"+query);
                if (user.TypeUtilisateur != null)
                    query += "type_utilisateur =" + user.TypeUtilisateur + " and ";
                Console.Write("2"+query);
                if (user.Login != null)
                    query += " login = '" + user.Login + "' and ";
                Console.Write("3"+query);
                if (user.Password != null)
                    query += " password = '" + user.Password +"'";
                Console.Write(query);
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    UtilisateurVue utilisateur = new UtilisateurVue(reader.GetInt16(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4));
                    listAll.Add(utilisateur);
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erreur dans UserDao=>search "+e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(Utilisateur user)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from utilisateur where id = "+user.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                throw new Exception("Erreur dans UserDao=>remove "+e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public UtilisateurVue findById(int id)
        {
            conn = new DB().getConn();
            UtilisateurVue utilisateur=null;
            try
            {
                string query = "select * from user_vue where id="+id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    utilisateur = new UtilisateurVue(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), 
                        reader.GetString(3), reader.GetString(4));
                }
            }
            catch(Exception e)
            {
                throw new Exception("Erreur dans UserDao=>findBydId "+e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return utilisateur;
        }

        public void insert(Utilisateur user)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into utilisateur (id,type_utilisateur,login,password) values (nextval('seq_user'),"+user.TypeUtilisateur.Id+","
                + user.Login + "," +user.Password +")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();  
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans UserDao=>insert"+e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<UtilisateurVue> getAll()
        {
            List<UtilisateurVue> listAll = new List<UtilisateurVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from user_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    UtilisateurVue utilisateur = new UtilisateurVue(reader.GetInt16(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4));
                    listAll.Add(utilisateur);
                }
            }
            catch(Exception e) 
            {
                throw new Exception("Erreur dans User->getAll" + e.Message);
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