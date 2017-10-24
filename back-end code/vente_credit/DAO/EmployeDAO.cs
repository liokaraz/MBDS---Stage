using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using vente_credit.Models;
using vente_credit.utilities;

namespace vente_credit.DAO
{
    public class EmployeDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public List<EmployeVue> search(Employe employe)
        {
            conn = new DB().getConn();
            List<EmployeVue> listAll = new List<EmployeVue>();
            try
            {
                string query = "select * from employe_vue where 1<2 ";
                if (employe.Nom != null)
                    query += " and nom =" + employe.Nom;
                if (employe.Prenom != null)
                    query += " and prenom =" + employe.Prenom;
                if (employe.Age != 0)
                    query += " and age =" + employe.Age;
                if (employe.Sexe != null)
                    query += " and sexe =" + employe.Sexe;
                if (employe.Email != null)
                    query += " and email =" + employe.Email;
                if (employe.Contact != null)
                    query += " and contact =" + employe.Contact;
                if (employe.TypeEmploye != null)
                    query += " and type_employe = '" + employe.TypeEmploye.Libelle + "'";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeVue c = new EmployeVue(reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7));
                    listAll.Add(c);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeDao=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(Employe employe)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from employe where id = " + employe.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeDao=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public EmployeVue findById(int id)
        {
            conn = new DB().getConn();
            EmployeVue employe = null;
            try
            {
                string query = "select * from employe_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    employe = new EmployeVue(reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeDao=>findBydId " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return employe;
        }

        public void insert(Employe employe)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into employe (id, nom, prenom, age, sexe, email, contact, type_employe) values"
                + " (nextval('seq_employe')," + employe.Nom + "," + employe.Prenom + "," + employe.Email + ","
                + employe.Contact + "," + employe.TypeEmploye.Id + ")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployDao=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<EmployeVue> getAll()
        {
            List<EmployeVue> listAll = new List<EmployeVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from employe_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeVue employe = new EmployeVue(reader.GetInt32(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7));
                    listAll.Add(employe);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeDao->getAll" + e.Message);
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