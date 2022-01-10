﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kondominium.Models
{
    public class jsModel
    {
        public string JsFuntion { get; set; }

        public int ClienteId { get; set; }

        public int ClienteDocId { get; set; }

        public string  DocumentType { get; set; }

        public Kondominium_Entities.Resultado mensaje {get; set;}
    }

    public class jsModelPC
    {
        public string JsFuntion { get; set; }

        public int ClienteId { get; set; }

        public int PropiedadId { get; set; }

        public int ClienteDocId { get; set; }

        public string DocumentType { get; set; }

        public string TipoClienteId { get; set; }

        public Kondominium_Entities.Resultado mensaje { get; set; }
    }


    public class jsModelCXC
    {
        public string JsFuntion { get; set; }
        public string VaucherNumber { get; set; }
        public int  ProductoId { get; set; }
        public decimal Monto { get; set; }
        public Kondominium_Entities.Resultado mensaje { get; set; }
    }

    public class jsModelCalendar
    {
        public string JsFuntion { get; set; }
        public string Inicio { get; set; }
        public string Final { get; set; }
        public Kondominium_Entities.Resultado mensaje { get; set; }

        public List<Kondominium_Entities.CalendarioEntity> LCal { get; set; }
    }

}

