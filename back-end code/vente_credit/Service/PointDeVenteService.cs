using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.Models;
using vente_credit.DAO;

namespace vente_credit.Service
{
    public class PointDeVenteService
    {
        private PointDeVenteDAO pointDeVenteDAO;

        public PointDeVenteService()
        {
            pointDeVenteDAO = new PointDeVenteDAO();
        }

        public List<PointDeVenteVue> search(PointDeVenteVue pointVente)
        {
            List<PointDeVenteVue> listPointDeVente;
            try
            {
                listPointDeVente = pointDeVenteDAO.search(pointVente);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteService => search:" + e.Message +e.StackTrace);
            }
            return listPointDeVente;
        }

        public void remove(PointDeVente pointVente)
        {
            try
            {
                pointDeVenteDAO.remove(pointVente);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteService => remove:" + e.Message);
            }
        }

        public PointDeVenteVue findById(int id)
        {
            PointDeVenteVue pointVente;
            try
            {
                pointVente = pointDeVenteDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteService => findById:" + e.Message);
            }
            return pointVente;
        }

        public void insert(PointDeVente pointVente)
        {
            try
            {
                pointDeVenteDAO.insert(pointVente);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteService => insert:" + e.Message);
            }
        }

        public List<PointDeVenteVue> getAll()
        {
            List<PointDeVenteVue> listVente;
            try
            {
                listVente = pointDeVenteDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans PointDeVenteService => getAll:" + e.Message +e.StackTrace);
            }
            return listVente;
        }
    
    }
}