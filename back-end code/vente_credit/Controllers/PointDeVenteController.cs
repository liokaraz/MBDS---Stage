using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vente_credit.Service;
using vente_credit.Models;
using vente_credit.DAO;
using vente_credit.Utilities;
using System.Diagnostics;

namespace vente_credit.Controllers
{
    public class PointDeVenteController : Controller
    {
        //Services
        PointDeVenteService pointVenteService;
        LivraisonCartePVVueService livraisonCarteVueService;
        VenteCarteService venteCarteService;
        StatistiqueTotalService statistiqueTotalService;
        StatistiqueLivraisonCarteService statistiqueLivraisonCarteService;

        //
        // GET: /PointDeVente/

        public ActionResult Index(int id, string utilisateur)
        {
            //Initiation service
            pointVenteService = new PointDeVenteService();
            livraisonCarteVueService = new LivraisonCartePVVueService();

            PointDeVenteVue pointDeVente = new PointDeVenteVue(utilisateur);

            List<PointDeVenteVue> listPointDeVente = pointVenteService.search(pointDeVente);
            LivraisonCartePVVue livraison = new LivraisonCartePVVue(listPointDeVente[0].Libelle);

            List<LivraisonCartePVVue> listLivraison = new LivraisonCartePVVueDAO().search(livraison);

            ViewBag.ListeLivraison = listLivraison;

            return View();
        }

        public ActionResult VenteCarte(int livraison, int quantite, string pointDeVente, string date_vente)
        {
            //insertion vente carte
            venteCarteService = new VenteCarteService();
            pointVenteService = new PointDeVenteService();

            LivraisonCarte liv = new LivraisonCarte(livraison);
            PointDeVenteVue pv = new PointDeVenteVue(0, pointDeVente);
            List<PointDeVenteVue> listPV = new PointDeVenteDAO().search(pv);
            PointDeVente pointVente = new PointDeVente(listPV[0].Id);

            DateTime date = DateTime.Parse(date_vente);
            VenteCarte vente = new VenteCarte(liv, quantite, pointVente, date);
            venteCarteService.insert(vente);

            return new EmptyResult();
        }

        public ActionResult DetailVente(int idLivraison)
        {
            venteCarteService = new VenteCarteService();
            VenteCarteVue venteCarte = new VenteCarteVue();
            venteCarte.Livraison = idLivraison;
            List<VenteCarteVue> listVente = venteCarteService.search(venteCarte);
            ViewBag.listVenteCarte = listVente;
            return View();
        }

        public ActionResult Budget()
        {
            statistiqueTotalService = new StatistiqueTotalService();
            statistiqueLivraisonCarteService = new StatistiqueLivraisonCarteService();
            List<StatistiqueTotal> listStatistique = statistiqueTotalService.getAll();
            List<StatistiqueLivraisonCarte> listStatistiqueLivraison = statistiqueLivraisonCarteService.getAll();
            List<PourcentageVenteCarte> listPourcenteCarte = new Statistique().getPourcentageVenteCarte(listStatistique,
                listStatistiqueLivraison);
            ViewBag.ListStatistique = listStatistique;
            ViewBag.ListPourcentage = listPourcenteCarte;
            return View();
        }
    }
}
