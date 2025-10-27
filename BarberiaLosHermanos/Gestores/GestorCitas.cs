using System;
using System.Collections.Generic;
using System.Linq;
using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Gestores
    {
    public class GestorCitas
        {
        private List<Cita> listaCitas;

        public GestorCitas()
            {
            listaCitas = new List<Cita>();
            }

        public void AgregarCita(Cita cita)
            {
            listaCitas.Add(cita);
            Console.WriteLine("Cita registrada exitosamente.");
            }

        public void MostrarTodas()
            {
            if (listaCitas.Count == 0)
                {
                Console.WriteLine("No hay citas registradas.");
                return;
                }

            Console.WriteLine("=== CITAS REGISTRADAS ===");
            foreach (var c in listaCitas)
                {
                Console.WriteLine($"ID: {c.IdCita} | Cliente: {c.Cliente.Nombre} | Empleado: {c.Empleado.Nombre} | Fecha: {c.FechaHoraCita:dddd dd/MM/yyyy HH:mm} | Estado: {c.Estado}");
                }
            }

        public void BuscarPorFecha(DateTime fecha)
            {
            var citas = listaCitas.Where(c => c.FechaHoraCita.Date == fecha.Date).ToList();
            if (citas.Count == 0)
                {
                Console.WriteLine("No hay citas en esa fecha.");
                return;
                }

            foreach (var c in citas)
                {
                Console.WriteLine($"ID: {c.IdCita} | Cliente: {c.Cliente.Nombre} | Empleado: {c.Empleado.Nombre} | Hora: {c.FechaHoraCita:HH:mm}");
                }
            }

        public void CancelarCita(int id)
            {
            var cita = listaCitas.FirstOrDefault(c => c.IdCita == id);
            if (cita == null)
                {
                Console.WriteLine("Cita no encontrada.");
                return;
                }

            cita.Estado = Cita.EstadoCita.Cancelada;
            Console.WriteLine("Cita cancelada correctamente.");
            }

        public void ConfirmarCita(int id)
            {
            var cita = listaCitas.FirstOrDefault(c => c.IdCita == id);
            if (cita == null)
                {
                Console.WriteLine("Cita no encontrada.");
                return;
                }

            cita.Estado = Cita.EstadoCita.Confirmada;
            Console.WriteLine("Cita confirmada correctamente.");
            }

        public bool ExisteCitaEnHorario(Empleado empleado, DateTime fechaHora)
            {
            return listaCitas.Any(c =>
                c.Empleado.IdEmpleado == empleado.IdEmpleado &&
                c.FechaHoraCita == fechaHora &&
                c.Estado != Cita.EstadoCita.Cancelada);
            }

        public void MostrarPorCliente(int idCliente)
            {
            var citas = listaCitas.Where(c => c.Cliente.IdCliente == idCliente).ToList();
            if (citas.Count == 0)
                {
                Console.WriteLine("El cliente no tiene citas registradas.");
                return;
                }

            Console.WriteLine($"=== HISTORIAL DE CITAS DEL CLIENTE {idCliente} ===");
            foreach (var c in citas)
                {
                Console.WriteLine($"ID: {c.IdCita} | Fecha: {c.FechaHoraCita:dd/MM/yyyy HH:mm} | Estado: {c.Estado}");
                }
            }
        }
    }
