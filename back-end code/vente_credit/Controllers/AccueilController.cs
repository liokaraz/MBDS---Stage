using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vente_credit.Models;
using vente_credit.Service;
using vente_credit.DAO;
using System.Diagnostics;

namespace vente_credit.Controllers
{
    public class AccueilController : Controller
    {
        //VAR
        DistributionCarteService distribCarteService;
        CarteService carteService;
        EmployeService empService;
        PointDeVenteStockService pointDeVenteStockService;
        EmployeStockService empStockService;
        TypeEmployeService typeEmployeService;
        EmployeStockHistoService employeStockHistoService;

        //
        // GET: /Accueil/


        public ActionResult Index(string id, string utilisateur)
        {
            distribCarteService = new DistributionCarteService();
            carteService = new CarteService();
            empService = new EmployeService();
            typeEmployeService = new TypeEmployeService();
            List<DistributionCarteVue> listCarteDistribue = distribCarteService.getAll();
            List<Carte> listCarte = carteService.getAll();
            TypeEmploye typEmp = typeEmployeService.findById(3);
            Employe emp = new Employe(typEmp);
            List<EmployeVue> listEmp = new EmployeDAO().search(emp);
            ViewBag.ListeCarteDistr = listCarteDistribue;
            ViewBag.ListeCarte = listCarte;
            ViewBag.ListEmp = listEmp;
            return View();
        }
        // Add card
        public ActionResult InsertCard(int carte,int employe, int quantite, string date)
        {
            //instanciation des services
            distribCarteService = new DistributionCarteService();
            empStockService = new EmployeStockService();
            empService = new EmployeService();
            carteService = new CarteService();
            employeStockHistoService = new EmployeStockHistoService();

            //instanciation objet depuis argument
            Carte c = new Carte(carte);
            Employe emp = new Employe(employe);
            DateTime dateTime = DateTime.Parse(date);
            EmployeVue employee = empService.findById(employe);
            Carte cartee = carteService.findById(carte);

            //instanciation distribution carte
            DistributionCarte carteDist = new DistributionCarte(c, emp, quantite, dateTime);

            //Recherche du stock de l'employe actuelle
            EmployeStockVue empStockActu = new EmployeStockVue();
            empStockActu.Carte = cartee.Libelle;
            empStockActu.Nom = employee.Nom;
            List<EmployeStockVue> listEmpStockActu = empStockService.search(empStockActu);

            //insertion de la distribution
            distribCarteService.insert(carteDist);

            //mise a jour du stock du coursier
            int stock = listEmpStockActu[0].Stock + quantite;
            empStockService.update(new EmployeStock(employe, stock, carte));

            //insertion du nouveau stock du coursier
            employeStockHistoService.insert(new EmployeStockHisto(employe, quantite, carte));

            //Recherche liste carte distribue
            List<DistributionCarteVue> listCarteDistr = distribCarteService.getAll();
            ViewBag.ListCarteDistr = listCarteDistr;
            return View();  
        }

        // GET ID Distribution carte
        public ActionResult DetailDistribution(int id)
        {
            distribCarteService = new DistributionCarteService();
            DistributionCarteVue distCarteId = distribCarteService.findById(id);
            ViewBag.DetailCarte = distCarteId.Carte;
            ViewBag.DetailQuantite = distCarteId.Quantite;
            ViewBag.DetailEmploye = distCarteId.Employe;
            ViewBag.DetailDate = distCarteId.Date;
            return View();
        }

        //GET point de vente
        public ActionResult PointDeVente()
        {
            pointDeVenteStockService = new PointDeVenteStockService();
            List<PointDeVenteStockVue> listAll = new PointDeVenteStockDAO().getAll();
            ViewBag.listPointDeVenteStock = listAll;
            return View();
        }

        //GET BUDGET
        public ActionResult Budget()
        {
            return View();
        }

        //GET POINT DE VENTE MAP
        public ActionResult PointDeVenteMap() 
        {
            return View();
        }
    }
}
