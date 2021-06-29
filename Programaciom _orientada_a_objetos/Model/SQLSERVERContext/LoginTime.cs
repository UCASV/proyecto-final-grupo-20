using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class LoginTime
    {
        public int Id { get; set; }
        public DateTime? DateTimeLogin { get; set; }
        public int? IdAdministrator { get; set; }
        public int? IdCabin { get; set; }

        public virtual Administrator IdAdministratorNavigation { get; set; }
        public virtual Cabin IdCabinNavigation { get; set; }
    }
}
