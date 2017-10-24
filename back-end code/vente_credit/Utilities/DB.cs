using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace vente_credit.utilities
{
    public class DB
    {
        public NpgsqlConnection getConn() 
        {
            NpgsqlConnection conn;
            try 
            {
                conn = new NpgsqlConnection("Host=localhost;port=5433;Username=postgres;Password=123456;Database=vente_carte");
                conn.Open();
            }
            catch(Exception e)
            {
                throw new Exception("Erreur dans DB->getConn()" + e.Message);
            }
            return conn;
        }
    }
}