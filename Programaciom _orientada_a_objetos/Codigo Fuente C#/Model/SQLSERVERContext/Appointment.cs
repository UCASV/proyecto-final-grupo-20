using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class Appointment
    {
        public Appointment()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string Place { get; set; }
        public int? Number { get; set; }
        public int? IdVaccination { get; set; }

        public virtual Vaccination IdVaccinationNavigation { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
