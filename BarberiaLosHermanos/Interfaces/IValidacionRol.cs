using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos
    {
    public interface IValidacionRol
        {
        // Validar si el empleado puede ofrecer un servicio específico
        bool ValidarServicioPorRol(Servicio servicio);
        }
    }
