using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using vente_credit.Models;

namespace vente_credit.Utilities
{
    public class Statistique
    {
        public List<PourcentageVenteCarte> getPourcentageVenteCarte(List<StatistiqueTotal> statTotal, 
            List<StatistiqueLivraisonCarte> statLivraisonCarte)
        {
            List<PourcentageVenteCarte> listPourcentage = new List<PourcentageVenteCarte>();
            PourcentageVenteCarte pourcentageCarte;
            double currentPourcent;
            foreach(var stat in statTotal) 
            {
                foreach (var statLivraison in statLivraisonCarte)
                {
                    Debug.WriteLine("if(" + stat.Id + "==" + statLivraison.Id + ")");
                    if(stat.Id == statLivraison.Id) 
                    {
                        Debug.WriteLine("Carte =" + stat.Carte);
                        currentPourcent =  (stat.Quantite * 100) / statLivraison.Quantite;
                        pourcentageCarte = new PourcentageVenteCarte(statLivraison.Id, stat.Carte, currentPourcent);
                        listPourcentage.Add(pourcentageCarte);
                    }
                }
            }
            return listPourcentage;
        }
    }
}