using Model;
using Model.SQLSERVERContext;
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

        public Employee GetEmployee(Administrator administrator)
        {
            List<Employee> employees = db.Employees.ToList();
            //List<TypeEmployee> typeEmployees = db.TypeEmployees.ToList();
            Employee employeeSend = employees.Find(e => e.IdAdministrator == administrator.Id);
            /*List<Employee> typeEmployees = db.typeEmployees.ToList();
            TypeEmployee typeEmployeeSend = typeEmployees.Find(t => t.);*/
            return employeeSend;
        }

        public string GetTypeEmployee(Employee employee)
        {
            List<TypeEmployee> typeEmployees = db.TypeEmployees.ToList();
            TypeEmployee typeEmployeeSend = typeEmployees.Find(t => t.Id == employee.IdTypeEmployee);

            return typeEmployeeSend.TypeEmployee1;
        }

        public Cabin GetCabin(Administrator administrator)
        {
            List<Cabin> cabins = db.Cabins.ToList();
            Cabin cabinSend = cabins.Find(c => c.Manager == administrator.Username);


            /*List<TypeEmployee> typeEmployees = db.TypeEmployees.ToList();
            TypeEmployee typeEmployeeSend = typeEmployees.Find(t => t.Id == Employee.IdTypeEmployee);
            */
            return cabinSend;
        }

        public List<AddressCabins> GetAddressCabin()
        {
            List<Cabin> cabins = db.Cabins.ToList();
            List<AddressCabins> addressCabins = new List<AddressCabins>();
            //AddressCabins addressCabinTemp;
            AddressCabins addressCabinTemp = new AddressCabins();
            for (int i = 0; i < cabins.Count(); i++)
            {
                addressCabinTemp.Id = cabins[i].Id;
                addressCabinTemp.AddressCabin = cabins[i].AddressCabin;

                addressCabins.Add(addressCabinTemp);
            }


            /*List<TypeEmployee> typeEmployees = db.TypeEmployees.ToList();
            TypeEmployee typeEmployeeSend = typeEmployees.Find(t => t.Id == Employee.IdTypeEmployee);
            */
            return addressCabins;
        }

        public void SetLoginTime(LoginTime loginTime)
        {

            db.Add(loginTime);
            db.SaveChanges();
        }

    }
}
