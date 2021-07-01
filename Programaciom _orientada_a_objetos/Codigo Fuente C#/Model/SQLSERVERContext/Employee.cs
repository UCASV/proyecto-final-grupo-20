using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string InstitutionalEmail { get; set; }
        public string AddressEmployee { get; set; }
        public int? IdTypeEmployee { get; set; }
        public int? IdAdministrator { get; set; }

        public virtual Administrator IdAdministratorNavigation { get; set; }
        public virtual TypeEmployee IdTypeEmployeeNavigation { get; set; }
    }
}
