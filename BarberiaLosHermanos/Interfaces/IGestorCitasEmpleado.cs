using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos
    {
    public interface IGestionCitasEmpleado
        {
        // Confirmar una cita asignada
        bool ConfirmarCita(int idCita);

        // Cancelar una cita (si el cliente lo solicita o hay cambios)
        bool CancelarCita(int idCita);

        // Ver todas las citas asignadas al empleado
        List<Cita> ObtenerCitasAsignadas(int idEmpleado);
        }
    }
