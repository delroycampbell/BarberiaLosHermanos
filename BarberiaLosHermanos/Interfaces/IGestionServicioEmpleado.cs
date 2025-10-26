using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos
    {
    public interface IGestionServicioEmpleado
        {
        // Agregar un servicio nuevo ofrecido por el empleado
        void AgregarServicio(Servicio nuevoServicio);

        // Eliminar un servicio que ya no se ofrece
        void EliminarServicio(string nombreServicio);

        // Mostrar los servicios que ofrece el empleado
        List<Servicio> MostrarServicios();

        // Validar disponibilidad para un servicio en una fecha determinada
        bool ValidarDisponibilidad(DateTime fecha);
        }
    }
