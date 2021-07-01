using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class Cabin
    {
        public Cabin()
        {
            Arrivals = new HashSet<Arrival>();
            LoginTimes = new HashSet<LoginTime>();
        }

        public int Id { get; set; }
        public string AddressCabin { get; set; }
        public int? Phone { get; set; }
        public string Manager { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Arrival> Arrivals { get; set; }
        public virtual ICollection<LoginTime> LoginTimes { get; set; }
    }
}
