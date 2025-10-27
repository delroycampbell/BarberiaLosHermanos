using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Interfaces
    {
    // Define las acciones básicas de gestión de citas
    public interface IGestionCitas
        {
        void CrearCita(Cita cita);
        Cita BuscarCitaPorId(int idCita);
        void CancelarCita(int idCita);
        }
    }
