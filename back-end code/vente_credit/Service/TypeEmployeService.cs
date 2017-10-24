using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class TypeEmployeService
    {
        private TypeEmployeDAO typeEmployeDAO;

        public TypeEmployeService()
        {
            typeEmployeDAO = new TypeEmployeDAO();
        }

        public List<TypeEmploye> search(TypeEmploye typeEmp)
        {
            List<TypeEmploye> listAll;
            try
            {
                listAll = typeEmployeDAO.search(typeEmp);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeService => search:" + e.Message);
            }
            return listAll;
        }

        public void remove(TypeEmploye typeEmp)
        {
            try
            {
                typeEmployeDAO.remove(typeEmp);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeService => remove:" + e.Message);
            }
        }

        public TypeEmploye findById(int id)
        {
            TypeEmploye typeEmp;
            try
            {
                typeEmp = typeEmployeDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeService => findById:" + e.Message);
            }
            return typeEmp;
        }

        public void insert(TypeEmploye typeEmp)
        {
            try
            {
                typeEmployeDAO.insert(typeEmp);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeService => insert:" + e.Message);
            }
        }

        public List<TypeEmploye> getAll()
        {
            List<TypeEmploye> listAll;
            try
            {
                listAll = typeEmployeDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans TypeEmployeService => getAll:" + e.Message);
            }
            return listAll;
        }
    }
}