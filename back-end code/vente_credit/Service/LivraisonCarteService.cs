using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class LivraisonCarteService
    {
        private LivraisonCarteDAO livraisonCarteDAO;

        public LivraisonCarteService()
        {
            this.LivraisonCarteDAO = new LivraisonCarteDAO();
        }

        public List<LivraisonCarteVue> search(LivraisonCarteVue livCarte)
        {
            List<LivraisonCarteVue> listCarte;
            try
            {
                listCarte = this.LivraisonCarteDAO.search(livCarte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteService => search:" + e.Message + e.StackTrace);
            }
            return listCarte;
        }

        public void remove(LivraisonCarte carte)
        {
            try
            {
                livraisonCarteDAO.remove(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteService => remove:" + e.Message);
            }
        }

        public LivraisonCarteVue findById(int id)
        {
            LivraisonCarteVue carte;
            try
            {
                carte = livraisonCarteDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteService => findById:" + e.Message);
            }
            return carte;
        }

        public void insert(LivraisonCarte carte)
        {
            try
            {
                livraisonCarteDAO.insert(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteService => insert:" + e.Message);
            }
        }

        public List<LivraisonCarteVue> getAll()
        {
            List<LivraisonCarteVue> listCarte;
            try
            {
                listCarte = livraisonCarteDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCarteService => getAll:" + e.Message);
            }
            return listCarte;
        }

        public LivraisonCarteDAO LivraisonCarteDAO
        {
            get { return livraisonCarteDAO; }
            set { livraisonCarteDAO = value; }
        }
    }
}