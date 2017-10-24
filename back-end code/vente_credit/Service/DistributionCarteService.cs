using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;


namespace vente_credit.Service
{
    public class DistributionCarteService
    {
        private DistributionCarteDAO distributionDAO;

        public DistributionCarteService()
        {
            distributionDAO = new DistributionCarteDAO();
        }

        public List<DistributionCarteVue> search(DistributionCarteVue carte)
        {
            List<DistributionCarteVue> listDistribCarte;
            try
            {
                listDistribCarte = distributionDAO.search(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteService => search:" + e.Message);
            }
            return listDistribCarte;
        }

        public void remove(DistributionCarte carte)
        {
            try
            {
                distributionDAO.remove(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteService => remove:" + e.Message);
            }
        }

        public DistributionCarteVue findById(int id)
        {
            DistributionCarteVue distribCarte;
            try
            {
                distribCarte = distributionDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteService => findById:" + e.Message);
            }
            return distribCarte;
        }

        public void insert(DistributionCarte distribCarte)
        {
            try
            {
                distributionDAO.insert(distribCarte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteService => insert:" + e.Message);
            }
        }

        public List<DistributionCarteVue> getAll()
        {
            List<DistributionCarteVue> listDistribCarte;
            try
            {
                listDistribCarte = distributionDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans DistributionCarteService => getAll:" + e.Message);
            }
            return listDistribCarte;
        }
    }
}