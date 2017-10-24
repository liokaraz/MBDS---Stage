using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vente_credit.Models;
using vente_credit.Service;
using vente_credit.DAO;
using System.Web.Routing;

namespace vente_credit.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        UserService userService;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Authentification(string typeUtilisateur, string login, string password)
        {
            if(typeUtilisateur == "-1")
                return RedirectToAction("Index", "Login", null);

            UtilisateurVue user = new UtilisateurVue(login, password);
            userService = new UserService();
            UserDAO userDao = new UserDAO();
            List<UtilisateurVue> listUser = userService.search(user);
            if (listUser.Count > 0)
            {
                Session["Utilisateur"] = listUser[0].Employe;
                Session["UtilisateurId"] = listUser[0].Id;
                if (typeUtilisateur == "0")
                {
                    return RedirectToAction("Index", "Admin", new RouteValueDictionary(new
                    {
                        id = listUser[0].Id,
                        utilisateur = listUser[0].Employe
                    }));
                }
                if (typeUtilisateur == "1") {
                    return RedirectToAction("Index", "Accueil", new RouteValueDictionary(new
                    {
                        id = listUser[0].Id,
                        utilisateur = listUser[0].Employe
                    }));
                }
                if (typeUtilisateur == "2")
                {
                    return RedirectToAction("Index", "Coursier", new RouteValueDictionary(new
                    {
                        id = listUser[0].Id
                    }));
                }
                if (typeUtilisateur == "3")
                {
                    return RedirectToAction("Index", "PointDeVente", new RouteValueDictionary(new
                    {
                        id = listUser[0].Id,
                        utilisateur = listUser[0].Employe
                    }));
                }

            }
            else
                return RedirectToAction("Index", "Login", null);
            return View();
        }


    }
}
