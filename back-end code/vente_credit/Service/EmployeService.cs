using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class EmployeService
    {
        private EmployeDAO employeDAO;

        public EmployeService()
        {
            employeDAO = new EmployeDAO();
        }

        public List<EmployeVue> search(Employe emp)
        {
            List<EmployeVue> listEmp;
            try
            {
                listEmp = employeDAO.search(emp);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeService => search:" + e.Message);
            }
            return listEmp;
        }

        public void remove(Employe emp)
        {
            try
            {
                employeDAO.remove(emp);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeService => remove:" + e.Message);
            }
        }

        public EmployeVue findById(int id)
        {
            EmployeVue emp;
            try
            {
                emp = employeDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeService => findById:" + e.Message +e.StackTrace);
            }
            return emp;
        }

        public void insert(Employe emp)
        {
            try
            {
                employeDAO.insert(emp);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeService => insert:" + e.Message);
            }
        }

        public List<EmployeVue> getAll()
        {
            List<EmployeVue> listEmp;
            try
            {
                listEmp = employeDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans EmployeService => getAll:" + e.Message);
            }
            return listEmp;
        }
    }
}