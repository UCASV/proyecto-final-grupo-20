using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class Vaccination
    {
        public Vaccination()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public DateTime? VaccinationTime { get; set; }
        public string SecondaryEffect { get; set; }
        public int? TimeEffect { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
