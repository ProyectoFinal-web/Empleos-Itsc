using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EmpleoITSC.Models
{
    public class Pagination
    {
        public int PaginaActual { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int cantidadRegistrosPorPagina { get; set; } = 10; // Registro a mostrar

        public string cadenaM(string v)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(v);
        }

    }
}
