using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.Models;
using vente_credit.DAO;

namespace vente_credit.Service
{
    public class EmployeStockHistoService
    {
        private EmployeStockHistoDAO empStockHistoDAO;

        public EmployeStockHistoService()
        {
            empStockHistoDAO = new EmployeStockHistoDAO();
        }

        public void update(EmployeStockHisto empStock)
        {
            try
            {
                empStockHistoDAO.update(empStock);
            }
            catch(Exception e){
                throw new Exception("Erreur dans EmployeStockHistoService => update:" + e.Message);
            }
        }

        public List<EmployeStockHistoVue> search(EmployeStockHistoVue empStock)
        {
            List<EmployeStockHistoVue> listAll;
            try
            {
                listAll = empStockHistoDAO.search(empStock);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoService => search:" + e.Message);
            }
            return listAll;
        }

        public void remove(EmployeStockHisto empStock)
        {
            try
            {
                empStockHistoDAO.remove(empStock);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoService => remove:" + e.Message);
            }
        }

        public EmployeStockHistoVue findById(int id)
        {
            EmployeStockHistoVue empStock;
            try
            {
                empStock = empStockHistoDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoService => findById:" + e.Message);
            }
            return empStock;
        }

        public void insert(EmployeStockHisto empStock)
        {
            try
            {
                empStockHistoDAO.insert(empStock);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoService => insert:" + e.Message);
            }
        }

        public List<EmployeStockHistoVue> getAll()
        {
            List<EmployeStockHistoVue> listAll;
            try
            {
                listAll = empStockHistoDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeStockHistoService => getAll:" + e.Message);
            }
            return listAll;
        }
    }
}