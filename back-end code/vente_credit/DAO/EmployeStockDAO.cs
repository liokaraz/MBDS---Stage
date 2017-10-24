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
    public class EmployeStockDAO
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public void update(EmployeStock empStock)
        {
            conn = new DB().getConn();
            try
            {
                string query = "update  employe_stock set";
                if (empStock.Stock != null)
                    query += " stock = " + empStock.Stock + " where 1<2";
                if (empStock.Id != 0)
                    query += " and id = " + empStock.Id;
                if (empStock.Employe != 0)
                    query += " and employe = " + empStock.Employe;
                if (empStock.Carte != 0)
                    query += " and carte = " + empStock.Carte;
                Debug.WriteLine(query);
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockDAO=>update " + e.Message);
            }
        }

        public List<EmployeStockVue> search(EmployeStockVue empStock)
        {
            conn = new DB().getConn();
            List<EmployeStockVue> listAll = new List<EmployeStockVue>();
            try
            {
                string query = "select * from employe_stock_vue where  1<2";
                if (empStock.Nom != null)
                    query += " and nom = '" + empStock.Nom + "'";
                if (empStock.Prenom != null)
                    query += " and prenom = '" + empStock.Prenom + "'";
                if (empStock.Age != 0)
                    query += " and age = " + empStock.Age;
                if (empStock.Sexe != null)
                    query += " and sexe = '" + empStock.Sexe + "'";
                if (empStock.Email != null)
                    query += " and email = '" + empStock.Email + "'";
                if (empStock.Contact != null)
                    query += " and contact = '" + empStock.Contact + "'";
                if (empStock.TypeEmploye != null)
                    query += " and type_employe = '" + empStock.TypeEmploye + "'";
                if (empStock.Stock != 0)
                    query += " and stock = " + empStock.Stock;
                if (empStock.Carte != null)
                    query += " and carte = '" + empStock.Carte + "'";
                Debug.WriteLine(query);
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeStockVue empS = new EmployeStockVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetString(9));
                    listAll.Add(empS);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(EmployeStock empStock)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from employe_stock where id = " + empStock.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockDAO=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public EmployeStockVue findById(int id)
        {
            conn = new DB().getConn();
            EmployeStockVue empStock = null;
            try
            {
                string query = "select * from employe_stock_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    empStock = new EmployeStockVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetString(9));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockDAO=>findBydId " + e.Message + e.StackTrace);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return empStock;
        }

        public void insert(EmployeStock empStock)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into employe_stock (id, employe, stock, carte) "
                + " values (nextval('seq_employe_stock')," + empStock.Employe + "," 
                + empStock.Stock + empStock.Carte + ")";
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockDAO=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<EmployeStockVue> getAll()
        {
            List<EmployeStockVue> listAll = new List<EmployeStockVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from employe_stock_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeStockVue carte = new EmployeStockVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetString(9));
                    listAll.Add(carte);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockDAO->getAll" + e.Message);
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