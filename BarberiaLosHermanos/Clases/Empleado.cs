using System;
using System.Collections.Generic;
using BarberiaLosHermanos.Interfaces;

namespace BarberiaLosHermanos.Clases
    {
    public class Empleado : Persona, IGestionCitas
        {
        public int IdEmpleado { get; set; }
        public PuestoEmpleado Puesto { get; set; }
        public double Salario { get; set; }
        protected List<Cita> citasAsignadas;
        private static int contadorEmpleados = 1;


        // Enum para tipo de puesto
        public enum PuestoEmpleado
            {
            Barbero,
            Estilista,
            Asistente,
            Administrativo
            }

        // Constructor
        public Empleado(string nombre, string apellido1, string apellido2, string telefono, string correo, PuestoEmpleado puesto, double salario) : base(nombre, apellido1, apellido2, telefono, correo)
            {
            IdEmpleado = contadorEmpleados++;
            Puesto = puesto;
            Salario = salario;
            citasAsignadas = new List<Cita>();
            }

        // Métodos de gestión de citas
        public void CrearCita(Cita cita)
            {
            citasAsignadas.Add(cita);
            Console.WriteLine($"El empleado {Nombre} ({Puesto}) agendó una cita para {cita.Cliente.Nombre}.");
            }

        public Cita BuscarCitaPorId(int idCita)
            {
            return citasAsignadas.Find(c => c.IdCita == idCita);
            }

        public void CancelarCita(int idCita)
            {
            var cita = BuscarCitaPorId(idCita);
            if (cita != null)
                {
                cita.Estado = Cita.EstadoCita.Cancelada;
                Console.WriteLine($"El empleado {Nombre} canceló la cita #{idCita}.");
                }
            else
                {
                Console.WriteLine($"No se encontró la cita con ID {idCita} para este empleado.");
                }
            }

        public void MostrarCitasEmpleado()
            {
            if (citasAsignadas.Count == 0)
                Console.WriteLine($"{Nombre} no tiene citas asignadas.");
            else
                citasAsignadas.ForEach(c => c.MostrarCita());
            }

        // Mostrar información completa del empleado
        public override void MostrarInfo()
            {
            Console.WriteLine($"ID Empleado: {IdEmpleado} - Puesto: {Puesto} - Salario: {Salario:0.00} colones");
            }
        }
    }
