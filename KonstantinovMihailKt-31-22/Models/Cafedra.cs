﻿using Microsoft.VisualBasic;

namespace KonstantinovMihailKt_31_22.Models
{
    public class Cafedra
    {
        public int CafedraId { get; set; }

        public string CafedraName { get; set; }
        public int AdminId { get; set; }

        public int totalPrerods { get; set; }
        public DateTime dataosnovania { get; set; }
        public Prepods Admin { get; set; } //internal
    }

}
