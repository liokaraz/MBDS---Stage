using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class VenteCarteService
    {
        private VenteCarteDAO venteCarteDAO;

        public VenteCarteService()
        {
            venteCarteDAO = new VenteCarteDAO();
        }

        public List<VenteCarteVue> search(VenteCarteVue livCarte)
        {
            List<VenteCarteVue> listCarte;
            try
            {
                listCarte = this.venteCarteDAO.search(livCarte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteService => search:" + e.Message + e.StackTrace);
            }
            return listCarte;
        }

        public void remove(VenteCarte carte)
        {
            try
            {
                venteCarteDAO.remove(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteService => remove:" + e.Message);
            }
        }


        public VenteCarteVue findById(int id)
        {
            VenteCarteVue carte;
            try
            {
                carte = venteCarteDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteService => findById:" + e.Message);
            }
            return carte;
        }

        public void insert(VenteCarte carte)
        {
            try
            {
                venteCarteDAO.insert(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteService => insert:" + e.Message + e.StackTrace);
            }
        }

        public List<VenteCarteVue> getAll()
        {
            List<VenteCarteVue> listCarte;
            try
            {
                listCarte = venteCarteDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans VenteCarteService => getAll:" + e.Message);
            }
            return listCarte;
        }
    }
}