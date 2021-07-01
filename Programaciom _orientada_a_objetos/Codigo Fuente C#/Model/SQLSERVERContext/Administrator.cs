using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class Administrator
    {
        public Administrator()
        {
            Employees = new HashSet<Employee>();
            LoginTimes = new HashSet<LoginTime>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordAdmin { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<LoginTime> LoginTimes { get; set; }
    }
}
