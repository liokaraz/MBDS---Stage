using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vente_credit.Models;
using vente_credit.DAO;

namespace vente_credit.Service
{
    public class UserService
    {
        private UserDAO userDao;

        public UserService()
        {
            userDao = new UserDAO();
        }

        public List<UtilisateurVue> search(UtilisateurVue user)
        {
            List<UtilisateurVue> listUser = new List<UtilisateurVue>();
            try
            {
                listUser = userDao.search(user);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans UserService => search:" + e.Message);
            }
            return listUser;
        }

        public void remove(Utilisateur user)
        {
            try
            {
                userDao.remove(user);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans UserService => remove:" + e.Message);
            }
        }

        public UtilisateurVue findById(int id)
        {
            UtilisateurVue user;
            try
            {
                user = userDao.findById(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans UserService => findById:" + e.Message);
            }
            return user;
        }

        public void insert(Utilisateur user)
        {
            try
            {
                userDao.insert(user);
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans UserService => insert:" + e.Message);
            }
        }

        public List<UtilisateurVue> getAll()
        {
            List<UtilisateurVue> listUser;
            try
            {
                listUser = userDao.getAll();
            }
            catch (Exception e)
            {
                throw new Exception("Erreur dans UserService => getAll:" + e.Message);
            }
            return listUser;
        }
    }
}