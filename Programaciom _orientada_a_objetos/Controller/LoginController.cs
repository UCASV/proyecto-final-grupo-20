using MaterialSkin;
using MaterialSkin.Controls;
using Model.SQLSERVERContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class LoginController
    {
        ProyectDBContext db = new ProyectDBContext();
        public bool GetAdministratorExists(string txtUser, string txtPassword)
        {
            List<Administrator> administrators = db.Administrators.ToList();
            bool exists = administrators.Where(a => a.Username == txtUser && a.PasswordAdmin == txtPassword).ToList().Any();

            return exists;
        }
        public Administrator GetAdministrator(string txtUser, string txtPassword) 
        {
            List<Administrator> administrators = db.Administrators.ToList();
            Administrator administratorSend = administrators.Find(a => a.Username == txtUser && a.PasswordAdmin == txtPassword);

            return administratorSend;
        }
    }
}
