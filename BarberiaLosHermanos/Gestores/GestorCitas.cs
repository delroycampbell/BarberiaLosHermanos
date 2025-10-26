using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberiaLosHermanos
    {
    public class GestorCitas : IGestionCitas
        {
        // Atributos privados
        private readonly List<Cita> listaCitas;

        // Constructor
        public GestorCitas()
            {
            listaCitas = new List<Cita>();
            }

        // =======================================================
        // Métodos Globales (uso compartido entre Cliente y Empleado)
        // =======================================================

        // Agregar una nueva cita (valida anticipación mínima de 7 días)
        public void AgregarCita(Cita cita)
            {
            if (cita == null)
                throw new ArgumentNullException(nameof(cita), "La cita no puede ser nula.");

            if (listaCitas.Any(c => c.IdCita == cita.IdCita))
                throw new InvalidOperationException("Ya existe una cita con el mismo ID.");

            if (cita.FechaHoraCita < DateTime.Now.AddDays(7))
                throw new InvalidOperationException("Las citas deben agendarse con al menos 7 días de anticipación.");

            if (cita.Cliente == null || cita.Empleado == null)
                throw new ArgumentException("La cita debe tener asignado un cliente y un empleado válidos.");

            // Validar que el empleado tenga disponibilidad en esa fecha
            if (!ValidarDisponibilidadEmpleado(cita.Empleado.IdEmpleado, cita.FechaHoraCita))
                throw new InvalidOperationException($"El empleado {cita.Empleado.Nombre} ya tiene una cita en esa fecha y hora.");

            listaCitas.Add(cita);
            Console.WriteLine($"Cita ID {cita.IdCita} agendada correctamente para {cita.Cliente.Nombre} el {cita.FechaHoraCita:g}.");
            }

        // =======================================================
        // Métodos de consulta
        // =======================================================

        // Obtener todas las citas de un cliente (por ID)
        public List<Cita> ObtenerCitasPorIdCliente(int idCliente)
            {
            if (idCliente <= 0)
                throw new ArgumentException("El ID del cliente no es válido.");

            var citasCliente = listaCitas
                .Where(c => c.Cliente.IdCliente == idCliente)
                .OrderBy(c => c.FechaHoraCita)
                .ToList();

            if (citasCliente.Count == 0)
                Console.WriteLine($"El cliente con ID {idCliente} no tiene citas registradas.");

            return citasCliente;
            }

        // Obtener todas las citas de un empleado (por ID)
        public List<Cita> ObtenerCitasPorIdEmpleado(int idEmpleado)
            {
            if (idEmpleado <= 0)
                throw new ArgumentException("El ID del empleado no es válido.");

            var citasEmpleado = listaCitas
                .Where(c => c.Empleado.IdEmpleado == idEmpleado)
                .OrderBy(c => c.FechaHoraCita)
                .ToList();

            if (citasEmpleado.Count == 0)
                Console.WriteLine($"El empleado con ID {idEmpleado} no tiene citas asignadas.");

            return citasEmpleado;
            }

        // =======================================================
        // Métodos de modificación de estado
        // =======================================================

        // Cancelar cita por ID (solo si está pendiente o confirmada)
        public bool CancelarCita(int idCita)
            {
            var cita = listaCitas.FirstOrDefault(c => c.IdCita == idCita);
            if (cita == null)
                {
                Console.WriteLine($"No existe una cita con ID {idCita}.");
                return false;
                }

            if (cita.Estado == Cita.eEstadoCita.Cancelada || cita.Estado == Cita.eEstadoCita.Completada)
                {
                Console.WriteLine("No se puede cancelar una cita ya completada o previamente cancelada.");
                return false;
                }

            cita.Estado = Cita.eEstadoCita.Cancelada;
            Console.WriteLine($"Cita ID {idCita} cancelada correctamente.");
            return true;
            }

        // Confirmar cita (solo el empleado puede hacerlo)
        public bool ConfirmarCita(int idCita)
            {
            var cita = listaCitas.FirstOrDefault(c => c.IdCita == idCita);
            if (cita == null)
                {
                Console.WriteLine($"No existe una cita con ID {idCita}.");
                return false;
                }

            if (cita.Estado != Cita.eEstadoCita.Pendiente)
                {
                Console.WriteLine("Solo las citas pendientes pueden ser confirmadas.");
                return false;
                }

            cita.Estado = Cita.eEstadoCita.Confirmada;
            Console.WriteLine($"Cita ID {idCita} confirmada correctamente.");
            return true;
            }

        // =======================================================
        // Métodos auxiliares
        // =======================================================

        // Validar si un empleado tiene disponibilidad en una fecha/hora
        private bool ValidarDisponibilidadEmpleado(int idEmpleado, DateTime fecha)
            {
            return !listaCitas.Any(c =>
                c.Empleado.IdEmpleado == idEmpleado &&
                c.FechaHoraCita.Date == fecha.Date &&
                Math.Abs((c.FechaHoraCita - fecha).TotalMinutes) < c.Duracion.TotalMinutes);
            }

        // Mostrar todas las citas registradas
        public void MostrarTodasLasCitas()
            {
            if (listaCitas.Count == 0)
                {
                Console.WriteLine("No hay citas registradas en el sistema.");
                return;
                }

            Console.WriteLine("Listado general de citas:");
            foreach (var cita in listaCitas.OrderBy(c => c.FechaHoraCita))
                cita.MostrarCita();
            }
        }
    }
