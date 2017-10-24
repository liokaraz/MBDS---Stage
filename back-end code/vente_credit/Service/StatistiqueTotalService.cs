using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class StatistiqueTotalService
    {
        private StatistiqueTotalDAO statistiqueDAO;

        public StatistiqueTotalService() 
        {
            statistiqueDAO = new StatistiqueTotalDAO();
        }

        public List<StatistiqueTotal> search(StatistiqueTotal stat)
        {
            List<StatistiqueTotal> listStat;
            try
            {
                listStat = statistiqueDAO.search(stat);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueTotalService => search:" + e.Message);
            }
            return listStat;
        }

        public StatistiqueTotal findById(int id)
        {
            StatistiqueTotal stat;
            try
            {
                stat = statistiqueDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueTotalService => findById:" + e.Message);
            }
            return stat;
        }

        public List<StatistiqueTotal> getAll()
        {
            List<StatistiqueTotal> listAll;
            try
            {
                listAll = statistiqueDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans StatistiqueTotalService => getAll:" + e.Message + e.StackTrace);
            }
            return listAll;
        }
    }
}