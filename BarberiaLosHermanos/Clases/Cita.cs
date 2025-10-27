using BarberiaLosHermanos.Clases;

public class Cita
    {
    public int IdCita { get; set; }
    public Cliente Cliente { get; set; }
    public Empleado Empleado { get; set; }
    public Servicio Servicio { get; set; }

    private static int contadorCitas = 1;


    public DateTime FechaHoraCita { get; set; }

    public EstadoCita Estado { get; set; }

    public enum EstadoCita
        {
        Pendiente,
        Confirmada,
        Cancelada
        }

    // Constructor
    public Cita(Cliente cliente, Empleado empleado, Servicio servicio, DateTime fechaHora)
        {
        IdCita = contadorCitas++;
        Cliente = cliente;
        Empleado = empleado;
        Servicio = servicio;
        FechaHoraCita = fechaHora;
        Estado = EstadoCita.Pendiente;
        }

    public void MostrarCita()
        {
        Console.WriteLine($"[{IdCita}] {Cliente.Nombre} - {Empleado.Nombre} - {Servicio.Nombre} ({FechaHoraCita:dd/MM/yyyy HH:mm}) Estado: {Estado}");
        }
    }
