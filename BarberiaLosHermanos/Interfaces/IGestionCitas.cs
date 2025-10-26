using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos
    {
    public interface IGestionCitas
        {
        // Agregar una nueva cita
        void AgregarCita(Cita cita);

        // Cancelar una cita existente
        bool CancelarCita(int idCita);

        // Confirmar cita (solo por el empleado)
        bool ConfirmarCita(int idCita);

        // Mostrar todas las citas (puede ser solo para administración)
        void MostrarTodasLasCitas();

        // Obtener citas por cliente o empleado
        List<Cita> ObtenerCitasPorIdCliente(int idCliente);
        List<Cita> ObtenerCitasPorIdEmpleado(int idEmpleado);
        }
    }
