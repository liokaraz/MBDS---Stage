using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.DAO;
using vente_credit.Models;

namespace vente_credit.Service
{
    public class CarteService
    {
        private CarteDAO carteDAO;

        public CarteService()
        {
            carteDAO = new CarteDAO();
        }

        public List<Carte> search(Carte carte)
        {
            List<Carte> listCarte;
            try
            {
                listCarte = carteDAO.search(carte);
            }
            catch(Exception e)
            {
                throw new Exception("Erreur dans CarteService => search:" +e.Message);
            }
            return listCarte;
        }

        public void remove(Carte carte)
        {
            try
            {
                carteDAO.remove(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteService => remove:" + e.Message);
            }
        }

        public Carte findById(int id)
        {
            Carte carte;
            try
            {
                carte = carteDAO.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteService => findById:" + e.Message);
            }
            return carte;
        }

        public void insert(Carte carte)
        {
            try
            {
                carteDAO.insert(carte);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteService => insert:" + e.Message);
            }
        }

        public List<Carte> getAll()
        {
            List<Carte> listCarte;
            try
            {
                listCarte = carteDAO.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans CarteService => getAll:" + e.Message);
            }
            return listCarte;
        }

    }
}