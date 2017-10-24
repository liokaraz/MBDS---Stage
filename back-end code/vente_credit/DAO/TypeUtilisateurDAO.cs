using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class TypeUtilisateurDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<TypeUtilisateur> search(TypeUtilisateur typeUser)
        {
            conn = new DB().getConn();
            List<TypeUtilisateur> listAll = new List<TypeUtilisateur>();
            try
            {
                string query = "select * from type_user when ";
                if (typeUser.Libelle != null)
                    query += "libelle =" + typeUser.Libelle;


                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    TypeUtilisateur tUser = new TypeUtilisateur(reader.GetInt16(0), reader.GetString(1));
                    listAll.Add(tUser);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(TypeUtilisateur typeUser)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from type_user where id = " + typeUser.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeUtilisateurDAO=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public TypeUtilisateur findById(int id)
        {
            conn = new DB().getConn();
            TypeUtilisateur typeUser = null;
            try
            {
                string query = "select * from type_user where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    typeUser = new TypeUtilisateur(reader.GetInt16(0), reader.GetString(1));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeUserDAO=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return typeUser;
        }

        public void insert(TypeUtilisateur typeUser)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into type_user (id,libelle) values (nextval('seq_type_user')," + typeUser.Libelle + ")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeUtilisateur=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<TypeUtilisateur> getAll()
        {
            List<TypeUtilisateur> listAll = new List<TypeUtilisateur>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from type_user";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    TypeUtilisateur typeUser = new TypeUtilisateur(reader.GetInt16(0), reader.GetString(1));
                    listAll.Add(typeUser);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeUtilisateurDAO->getAll" + e.Message);
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