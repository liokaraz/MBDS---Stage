using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class StatistiqueLivraisonCarteService
    {
        private StatistiqueLivraisonCarteDAO statistiqueLivraisonDAO;

        public StatistiqueLivraisonCarteService()
        {
            statistiqueLivraisonDAO = new StatistiqueLivraisonCarteDAO();
        }

        public List<StatistiqueLivraisonCarte> search(StatistiqueLivraisonCarte stat)
        {
            List<StatistiqueLivraisonCarte> listStat;
            try
            {
                listStat = statistiqueLivraisonDAO.search(stat);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueLivraisonCarteService => search:" + e.Message);
            }
            return listStat;
        }

        public StatistiqueLivraisonCarte findById(int id)
        {
            StatistiqueLivraisonCarte stat;
            try
            {
                stat = statistiqueLivraisonDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueLivraisonCarteService => findById:" + e.Message);
            }
            return stat;
        }

        public List<StatistiqueLivraisonCarte> getAll()
        {
            List<StatistiqueLivraisonCarte> listAll;
            try
            {
                listAll = statistiqueLivraisonDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueLivraisonCarteService => getAll:" + e.Message + e.StackTrace);
            }
            return listAll;
        }
    }
}