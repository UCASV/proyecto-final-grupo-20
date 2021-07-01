using Model.SQLSERVERContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PrincipalAppointmentProcessController
    {
        ProyectDBContext db = new ProyectDBContext();
        public void SetCitizen(Citizen citizen)
        {

            db.Add(citizen);
            db.SaveChanges();
        }
    }
}
