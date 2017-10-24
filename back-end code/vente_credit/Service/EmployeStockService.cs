using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.Models;
using vente_credit.DAO;


namespace vente_credit.Service
{
    public class EmployeStockService
    {
        private EmployeStockDAO empStockDAO;

        public EmployeStockService()
        {
            empStockDAO = new EmployeStockDAO();
        }

        public void update(EmployeStock empStock)
        {
            try
            {
                empStockDAO.update(empStock);
            }
            catch(Exception e){
                throw new Exception("Erreur dans EmployeStockService => update:" + e.Message);
            }
        }

        public List<EmployeStockVue> search(EmployeStockVue empStock)
        {
            List<EmployeStockVue> listAll;
            try
            {
                listAll = empStockDAO.search(empStock);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockService => search:" + e.Message);
            }
            return listAll;
        }

        public void remove(EmployeStock empStock)
        {
            try
            {
                empStockDAO.remove(empStock);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockService => remove:" + e.Message);
            }
        }

        public EmployeStockVue findById(int id)
        {
            EmployeStockVue empStock;
            try
            {
                empStock = empStockDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockService => findById:" + e.Message);
            }
            return empStock;
        }

        public void insert(EmployeStock empStock)
        {
            try
            {
                empStockDAO.insert(empStock);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockService => insert:" + e.Message);
            }
        }

        public List<EmployeStockVue> getAll()
        {
            List<EmployeStockVue> listAll;
            try
            {
                listAll = empStockDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockService => getAll:" + e.Message);
            }
            return listAll;
        }
    }
}