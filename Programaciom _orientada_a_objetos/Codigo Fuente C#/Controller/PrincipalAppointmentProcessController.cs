using Model.SQLSERVERContext;

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
