using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;



namespace BarberiaLosHermanos
    {
    public class Empleado : Persona, IGestionServicioEmpleado, IGestorCitasEmpleado
        {
        // Atributos
        private int idEmpleado;
        private ePuestos puesto;
        private double salario;
        private DateTime fechaContratacion;
        private List<Servicio> servicioOfrecido;
        private List<int> clientesAsignados; // IDs de clientes asignados
        private static int contadorID = 0;

        // Enum de puestos
        public enum ePuestos
            {
            Asistente,
            Barbero,
            Estilista,
            SoporteTecnico,
            Administrativo
            }

        // Propiedades
        public int IdEmpleado { get => idEmpleado; set => idEmpleado = value; }
        public ePuestos Puesto { get => puesto; set => puesto = value; }
        public double Salario { get => salario; set => salario = value; }
        public DateTime FechaContratacion { get => fechaContratacion; set => fechaContratacion = value; }
        public List<Servicio> ServicioOfrecido { get => servicioOfrecido; set => servicioOfrecido = value; }
        public List<int> ClientesAsignados { get => clientesAsignados; set => clientesAsignados = value; }
        public List<Cita> CitasAsignadas { get => citasAsignadas; set => citasAsignadas = value; }


        // Constructor con ID automático
        public Empleado(string nombre, string apellido1, string apellido2, string telefono, string correo,
                        ePuestos puesto, double salario, DateTime fechaContratacion)
            : base(nombre, apellido1, apellido2, telefono, correo)
            {
            this.idEmpleado = GenerarIdEmpleado();
            this.puesto = puesto;
            this.salario = salario;
            this.fechaContratacion = fechaContratacion;
            this.servicioOfrecido = new List<Servicio>();
            this.clientesAsignados = new List<int>();
            }

        public Empleado() { }


        // Generar ID único
        private int GenerarIdEmpleado()
            {
            return ++contadorID;
            }

        // Mostrar datos del empleado
        public override string MostrarDatos()
            {
            var sb = new StringBuilder();
            sb.AppendLine($"ID Empleado: {idEmpleado}");
            sb.AppendLine($"Nombre: {Nombre} {Apellido1} {Apellido2}");
            sb.AppendLine($"Teléfono: {Telefono}");
            sb.AppendLine($"Correo: {Correo}");
            sb.AppendLine($"Puesto: {puesto}");
            sb.AppendLine($"Salario: {salario:N2} colones");
            sb.AppendLine($"Fecha de Contratación: {fechaContratacion:d}");
            sb.AppendLine($"Servicios Ofrecidos: {string.Join(", ", servicioOfrecido)}");
            sb.AppendLine($"Clientes Asignados: {string.Join(", ", clientesAsignados)}");
            return sb.ToString();
            }
        // Calcular antigüedad en años
        public int CalcularAntiguedad()
            {
            var hoy = DateTime.Today;
            int antiguedad = hoy.Year - fechaContratacion.Year;
            if (fechaContratacion.Date > hoy.AddYears(-antiguedad)) antiguedad--;
            return antiguedad;
            }

        //calcular salario anual
        public double CalcularSalarioAnual()
            {
            return salario * 12;
            }

        //Validaciones #

        // Validación interna del rol del empleado
        private bool ValidarServicioPorRol(Servicio servicio)
            {
            switch (puesto)
                {
                case ePuestos.Barbero:
                    return servicio.Categoria == Servicio.eCategoriaServicio.Barbero;
                case ePuestos.Estilista:
                    return servicio.Categoria == Servicio.eCategoriaServicio.Estilista;
                case ePuestos.Asistente:
                case ePuestos.Administrativo:
                    return true; // Pueden ofrecer servicios varios
                default:
                    return false;
                }
            }
        //Implementacion de las interfaces
        //IGestionServicioEmpleado
        private GestorServicio gestorServicio = new GestorServicio();
        public void AgregarServicio(Servicio nuevoServicio)
            {
            if (nuevoServicio == null)
                throw new ArgumentException("El servicio no puede ser nulo.");

            // Validación principal de rol
            if (!ValidarServicioPorRol(nuevoServicio))
                throw new InvalidOperationException($"El empleado {Puesto} no puede ofrecer el servicio '{nuevoServicio.NombreServicio}'.");

            servicioOfrecido.Add(nuevoServicio);
            }

        public List<Servicio> ObtenerTodosServicios()
            {
            return gestorServicio.ObtenerTodosServicios();
            }
        //IGestorCitasEmpleado

        } // fin de la clase Empleado
    }