using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vente_credit.Service;
using vente_credit.Models;
using vente_credit.DAO;
using System.Diagnostics;

namespace vente_credit.Controllers
{
    public class CoursierController : Controller
    {
        //
        // GET: /Coursier/
        EmployeStockService empStockService;
        EmployeService empService;
        LivraisonCarteService livraisonCarteService;
        PointDeVenteService pointDeVenteService;
        PointDeVenteStockService pointDeVenteStockService;

        public ActionResult Index(int id)
        {
            empStockService = new EmployeStockService();
            empService = new EmployeService();
            pointDeVenteService = new PointDeVenteService();

            List<EmployeVue> listEmploye = empService.getAll();
            List<PointDeVenteVue> listPointDeVente = pointDeVenteService.getAll();
            ViewBag.listEmploye = listEmploye;
            ViewBag.listPointVente = listPointDeVente;

            EmployeVue emp = empService.findById(id);
            List<EmployeStockVue> listAll = empStockService.search(new EmployeStockVue(emp.Nom, emp.Prenom));

            ViewBag.listStock = listAll;
            return View();
        }

        //Detail livraison
        public ActionResult DetailLivraison(int employeStock) {
            Debug.WriteLine(employeStock);
            livraisonCarteService = new LivraisonCarteService();
            LivraisonCarteVue livraisonCarte = new LivraisonCarteVue(employeStock);
            List<LivraisonCarteVue> listDetailCarte = new LivraisonCarteDAO().search(livraisonCarte);
            ViewBag.listeDetailCarte = listDetailCarte;
            return View();
        }

        // GET Point de vente
        public ActionResult PointDeVente()
        {
            pointDeVenteStockService = new PointDeVenteStockService();
            List<PointDeVenteStockVue> listAll = new PointDeVenteStockDAO().getAll();
            ViewBag.listPointDeVenteStock = listAll;
            return View();
        }

        //GET Budget
        public ActionResult Budget()
        {
            return View();
        }

        //INSERT LIVRAISON
        public ActionResult Livraison(int empStock, int employe, int quantite,
            int resteNonVendu, string dateLivraison, int pointDeVente)
        {
            //Insertion livraison

            livraisonCarteService = new LivraisonCarteService();
            empStockService = new EmployeStockService();
            empService = new EmployeService();

            Employe emp = new Employe(employe);
            PointDeVente pointVente = new PointDeVente(pointDeVente);
            EmployeStock employeStock = new EmployeStock(empStock);
            DateTime date = DateTime.Parse(dateLivraison);
            LivraisonCarte livCarte = new LivraisonCarte(employeStock, quantite, resteNonVendu,
                date, pointVente);
            livraisonCarteService.insert(livCarte);

            //Update stock
            EmployeStockVue emplStock = empStockService.findById(empStock);
            Debug.WriteLine("Emp stock update " + emplStock.Stock + "-" +empStock);
            int stockUpdate = emplStock.Stock - quantite;
            EmployeStock empStockUpdate = new EmployeStock(emplStock.Id, stockUpdate);
            empStockService.update(empStockUpdate);

            //GET ALL STOCK

            EmployeVue empl = empService.findById(employe);
            List<EmployeStockVue> listAll = empStockService.search(new EmployeStockVue(empl.Nom, emp.Prenom));

            ViewBag.listStock = listAll;
            return View();
        }

        //Point de vente de map
        public ActionResult PointDeVenteMap()
        {
            return View();
        }
    }
}
