using System;

namespace BarberiaLosHermanos.Clases
    {
    public class Servicio
        {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public Empleado.PuestoEmpleado TipoEmpleado { get; set; }

        private static int contadorServicio = 1;

        // Constructor
        public Servicio(string nombre, double precio, Empleado.PuestoEmpleado tipoEmpleado)
            {
            IdServicio = contadorServicio++;
            Nombre = nombre;
            Precio = precio;
            TipoEmpleado = tipoEmpleado;
            }

        // Mostrar información del servicio
        public void MostrarServicio()
            {
            Console.WriteLine($"{IdServicio}. {Nombre} - ₡{Precio:N0} - Realizado por: {TipoEmpleado}");
            }
        }
    }
