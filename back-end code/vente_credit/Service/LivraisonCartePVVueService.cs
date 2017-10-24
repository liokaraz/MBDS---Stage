using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class LivraisonCartePVVueService
    {
        private LivraisonCartePVVueDAO livraisonCartePVVueDAO;

        public LivraisonCartePVVueService()
        {
            livraisonCartePVVueDAO = new LivraisonCartePVVueDAO();
        }

        public List<LivraisonCartePVVue> search(LivraisonCartePVVue livCarte)
        {
            List<LivraisonCartePVVue> listCarte;
            try
            {
                listCarte = this.livraisonCartePVVueDAO.search(livCarte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCartePVVueService => search:" + e.Message + e.StackTrace);
            }
            return listCarte;
        }



        public LivraisonCartePVVue findById(int id)
        {
            LivraisonCartePVVue carte;
            try
            {
                carte = livraisonCartePVVueDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCartePVVueService => findById:" + e.Message);
            }
            return carte;
        }

        public List<LivraisonCartePVVue> getAll()
        {
            List<LivraisonCartePVVue> listCarte;
            try
            {
                listCarte = livraisonCartePVVueDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans LivraisonCartePVVueService => getAll:" + e.Message);
            }
            return listCarte;
        }
    }
}