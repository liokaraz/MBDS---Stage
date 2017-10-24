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
    public class EmployeStockHistoDAO 
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand cmd;
        private NpgsqlDataReader reader;

        public void update(EmployeStockHisto empStock)
        {
            conn = new DB().getConn();
            try
            {
                string query = "update  employe_stock_histo set";
                if (empStock.Stock != null)
                    query += " stock = " + empStock.Stock;
                query += " where employe = " + empStock.Employe + " and carte = " + empStock.Carte;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoDAO=>update " + e.Message);
            }
        }

        public List<EmployeStockHistoVue> search(EmployeStockHistoVue empStock)
        {
            conn = new DB().getConn();
            List<EmployeStockHistoVue> listAll = new List<EmployeStockHistoVue>();
            try
            {
                string query = "select * from employe_stock_histo_vue where  1<2";
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
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeStockHistoVue empS = new EmployeStockHistoVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetString(9));
                    listAll.Add(empS);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoDAO=>search " + e.Message);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return listAll;
        }

        public void remove(EmployeStockHisto empStock)
        {
            conn = new DB().getConn();
            try
            {
                string query = "delete * from employe_stock_histo where id = " + empStock.Id;
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoDAO=>remove " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public EmployeStockHistoVue findById(int id)
        {
            conn = new DB().getConn();
            EmployeStockHistoVue empStock = null;
            try
            {
                string query = "select * from employe_stock_histo_vue where id=" + id;
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read() == true)
                {
                    empStock = new EmployeStockHistoVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetString(9));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoDAO=>findBydId " + e.Message + e.StackTrace);
            }
            finally
            {
                conn.Close();
                reader.Close();
            }
            return empStock;
        }

        public void insert(EmployeStockHisto empStock)
        {
            conn = new DB().getConn();
            try
            {
                string query = "insert into employe_stock_histo (id, employe, stock, carte) "
                + " values (nextval('seq_employe_stock_histo')," + empStock.Employe + "," + empStock.Stock + "," 
                + empStock.Carte + ")";
                Debug.WriteLine("insert" + query);
                cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoDAO=>insert" + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<EmployeStockHistoVue> getAll()
        {
            List<EmployeStockHistoVue> listAll = new List<EmployeStockHistoVue>();
            conn = new DB().getConn();
            try
            {
                string query = "select * from employe_stock_histo_vue";
                cmd = new NpgsqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    EmployeStockHistoVue empStock = new EmployeStockHistoVue(reader.GetInt16(0), reader.GetString(1),
                        reader.GetString(2), reader.GetInt16(3), reader.GetString(4), reader.GetString(5),
                        reader.GetString(6), reader.GetString(7), reader.GetInt32(8), reader.GetString(9));
                    listAll.Add(empStock);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoDAO->getAll" + e.Message);
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