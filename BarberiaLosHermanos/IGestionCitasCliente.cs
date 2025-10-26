using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos
    {
    public interface IGestionCitasCliente
        {
        // Solicitar una nueva cita
        void SolicitarCita(List<Servicio> servicios, DateTime fechaCita, Empleado empleadoAsignado);

        // Cancelar una cita (si está pendiente o confirmada)
        bool CancelarCita(int idCita);

        // Consultar citas futuras y pasadas
        List<Cita> ConsultarCitas(int idCliente);
        }
    }
