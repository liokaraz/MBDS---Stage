using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models; 

namespace vente_credit.Service
{
    public class PointDeVenteStockService
    {
        private PointDeVenteStockDAO pointDeVenteStockDAO;

        public PointDeVenteStockService()
        {
            pointDeVenteStockDAO = new PointDeVenteStockDAO();
        }
        public List<PointDeVenteStockVue> search(PointDeVenteStockVue pv)
        {
            List<PointDeVenteStockVue> listAll;
            try
            {
                listAll = pointDeVenteStockDAO.search(pv);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockService => search:" + e.Message);
            }
            return listAll;
        }

        public void remove(PointDeVenteStock pv)
        {
            try
            {
                pointDeVenteStockDAO.remove(pv);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockService => remove:" + e.Message);
            }
        }

        public PointDeVenteStockVue findById(int id)
        {
            PointDeVenteStockVue pv;
            try
            {
                pv = pointDeVenteStockDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockService => findById:" + e.Message);
            }
            return pv;
        }

        public void insert(PointDeVenteStock pv)
        {
            try
            {
                pointDeVenteStockDAO.insert(pv);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockService => insert:" + e.Message);
            }
        }

        public List<PointDeVenteStockVue> getAll()
        {
            List<PointDeVenteStockVue> listAll;
            try{
                listAll = pointDeVenteStockDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteStockService => getAll:" + e.Message);
            }
            return listAll;
        }

    }
}