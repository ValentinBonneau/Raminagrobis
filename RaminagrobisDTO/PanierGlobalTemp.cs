﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RaminagrobisDTO
{
    public class PanierGlobalTemp
    {
        public int? ID { get; set; }
        public DateTimeOffset Date { get; set; }
        public IEnumerable<LignePanierGlobalTemp> LignesG { get; set; }
    }
}
