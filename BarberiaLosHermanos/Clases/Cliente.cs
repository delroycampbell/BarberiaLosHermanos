using System;
using System.Collections.Generic;
using BarberiaLosHermanos.Interfaces;

namespace BarberiaLosHermanos.Clases
    {
    public class Cliente : Persona, IGestionCitas
        {

        public int IdCliente { get; set; }
        private List<Cita> citasCliente;
        private static int contadorClientes = 1; // contador global

        // Constructor
        public Cliente(string nombre, string apellido1, string apellido2, string telefono, string correo) : base(nombre, apellido1, apellido2, telefono, correo)
            {
            IdCliente = contadorClientes++;
            citasCliente = new List<Cita>();
            }

        // Crear una nueva cita
        public void CrearCita(Cita cita)
            {
            citasCliente.Add(cita);
            Console.WriteLine($"Cita registrada para el cliente {Nombre} (ID {IdCliente}).");
            }

        // Buscar una cita por ID
        public Cita BuscarCitaPorId(int idCita)
            {
            return citasCliente.Find(c => c.IdCita == idCita);
            }

        // Cancelar una cita existente
        public void CancelarCita(int idCita)
            {
            var cita = BuscarCitaPorId(idCita);
            if (cita != null)
                {
                cita.Estado = Cita.EstadoCita.Cancelada;
                Console.WriteLine($"El cliente {Nombre} canceló la cita #{idCita}.");
                }
            else
                {
                Console.WriteLine($"No se encontró la cita con ID {idCita} para este cliente.");
                }
            }

        // Mostrar todas las citas del cliente
        public void MostrarCitasCliente()
            {
            if (citasCliente.Count == 0)
                Console.WriteLine($"El cliente {Nombre} no tiene citas registradas.");
            else
                citasCliente.ForEach(c => c.MostrarCita());
            }

        // Mostrar información completa del cliente
        public override void MostrarInfo()
            {
            Console.WriteLine($"Nombre: {Nombre} {Apellido1} {Apellido2}");
            Console.WriteLine($"Teléfono: {Telefono}");
            Console.WriteLine($"Correo: {Correo}");
            Console.WriteLine($"ID Cliente: {IdCliente}");
            }

        }
    }
