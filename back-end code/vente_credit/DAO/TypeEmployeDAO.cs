using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class TypeEmployeDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<TypeEmploye> search(TypeEmploye typEmp)
        {
            conn = new DB().getConn();
            List<TypeEmploye> listAll = new List<TypeEmploye>();
            try
            {
                string query = "select * from type_employe where ";
                if (typEmp.Libelle != null)
                    query += "libelle =" + typEmp.Libelle;


                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    TypeEmploye tEmp = new TypeEmploye(reader.GetInt16(0), reader.GetString(1));
                    listAll.Add(tEmp);
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

        public void remove(TypeEmploye typeEmp)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from type_employe where id = " + typeEmp.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeDAO=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public TypeEmploye findById(int id)
        {
            conn = new DB().getConn();
            TypeEmploye typeEmp = null;
            try
            {
                string query = "select * from type_employe where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    typeEmp = new TypeEmploye(reader.GetInt16(0), reader.GetString(1));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeDAO=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return typeEmp;
        }

        public void insert(TypeEmploye typeEmp)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into type_employe (id,libelle) values (nextval('seq_type_employe')," + typeEmp.Libelle + ")";
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

        public List<TypeEmploye> getAll()
        {
            List<TypeEmploye> listAll = new List<TypeEmploye>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from type_employe";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    TypeEmploye typeEmp = new TypeEmploye(reader.GetInt16(0), reader.GetString(1));
                    listAll.Add(typeEmp);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeDAO->getAll" + e.Message);
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