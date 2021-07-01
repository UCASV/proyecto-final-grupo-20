﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Model.SQLSERVERContext
{
    public partial class CronicDesease
    {
        public CronicDesease()
        {
            Citizens = new HashSet<Citizen>();
        }

        public int Id { get; set; }
        public string CronicDesease1 { get; set; }
        public int? IdCitizen { get; set; }

        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
