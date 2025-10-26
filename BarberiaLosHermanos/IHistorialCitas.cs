using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos
    {
    public interface IHistorialCitas
        {
        // Mostrar citas completadas
        List<Cita> ObtenerHistorialPorCliente(int idCliente);

        // Mostrar historial por empleado
        List<Cita> ObtenerHistorialPorEmpleado(int idEmpleado);
        }
    }
    
