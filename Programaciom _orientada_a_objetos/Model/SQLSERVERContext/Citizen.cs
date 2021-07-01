using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class Citizen
    {
        public Citizen()
        {
            Arrivals = new HashSet<Arrival>();
        }

        public int Dui { get; set; }
        public string NameCitizen { get; set; }
        public string Email { get; set; }
        public string AddressCitizen { get; set; }
        public int? Phone { get; set; }
        public int? IdPriorityGroup { get; set; }
        public int? IdInstitution { get; set; }
        public int? IdAppointment { get; set; }
        public int? IdCronicDesease { get; set; }

        public virtual Appointment IdAppointmentNavigation { get; set; }
        public virtual CronicDesease IdCronicDeseaseNavigation { get; set; }
        public virtual Institution IdInstitutionNavigation { get; set; }
        public virtual PriorityGroup IdPriorityGroupNavigation { get; set; }
        public virtual ICollection<Arrival> Arrivals { get; set; }
    }
}
