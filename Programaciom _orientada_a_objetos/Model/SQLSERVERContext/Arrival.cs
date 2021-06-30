using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class Arrival
    {
        public int Id { get; set; }
        public int? IdCabin { get; set; }
        public int? IdCitizen { get; set; }

        public virtual Cabin IdCabinNavigation { get; set; }
        public virtual Citizen IdCitizenNavigation { get; set; }
    }
}
