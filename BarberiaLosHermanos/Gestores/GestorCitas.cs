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
            if (cita == null)
                throw new ArgumentNullException(nameof(cita), "La cita no puede ser nula.");

            if (listaCitas.Any(c => c.FechaHoraCita == cita.FechaHoraCita))
                throw new InvalidOperationException("Ya existe una cita en ese horario.");

            listaCitas.Add(cita);
            Console.WriteLine($"Cita creada correctamente con ID: {cita.IdCita}");
            }

        public void MostrarTodas()
            {
            if (listaCitas.Count == 0)
                {
                Console.WriteLine("No hay citas registradas.");
                return;
                }

            foreach (var cita in listaCitas)
                cita.MostrarCita();
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
                c.MostrarCita();
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
            Console.WriteLine($"Cita {id} cancelada correctamente.");
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
            Console.WriteLine($"Cita {id} confirmada correctamente.");
            }

        public void MostrarPorCliente(int idCliente)
            {
            var citasCliente = listaCitas.Where(c => c.Cliente.IdCliente == idCliente).ToList();
            if (citasCliente.Count == 0)
                {
                Console.WriteLine("Este cliente no tiene citas registradas.");
                return;
                }

            foreach (var c in citasCliente)
                c.MostrarCita();
            }

        public bool ExisteCitaEnHorario(DateTime fechaHora)
            {
            return listaCitas.Any(c => c.FechaHoraCita == fechaHora);
            }
        }
    }
