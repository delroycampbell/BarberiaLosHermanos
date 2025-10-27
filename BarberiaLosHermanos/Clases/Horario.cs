using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos.Clases
    {
    public class Horario
        {
        public DateTime Inicio { get; set; }
        public bool Disponible { get; set; }

        public Horario(DateTime inicio)
            {
            Inicio = inicio;
            Disponible = true;
            }
        }
    }
