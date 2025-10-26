using System.Text;
using System;
using System.Collections.Generic;

namespace BarberiaLosHermanos
    {
    public class Cita
        {
        private int idCita;
        private DateTime fechaHoraCita;
        private Cliente cliente;
        private Empleado empleado;
        private List<Servicio> servicios;
        private double costoTotal;
        private eEstadoCita estado;
        private static int contadorIDCita = 0;
        private TimeSpan duracion;
        private eTipoCita tipoCita;

        public enum eEstadoCita
            {
            Pendiente,
            Confirmada,
            Cancelada,
            Completada
            }

        public enum eTipoCita
            {
            Barberia,
            Spa,
            Masaje,
            Facial,
            Depilacion,
            Otro
            }

        // Propiedades
        public int IdCita
            {
            get => idCita;
            set
                {
                if (value > 0)
                    idCita = value;
                else
                    throw new ArgumentException("ID de cita inválido.");
                }
            }

        public DateTime FechaHoraCita
            {
            get => fechaHoraCita;
            set
                {
                if (ValidarFechaCita(value) && ValidarNoDomingo(value) && ValidarHoraCita(value))
                    fechaHoraCita = value;
                else
                    throw new ArgumentException("Fecha u hora de cita inválida.");
                }
            }

        public Cliente Cliente
            {
            get => cliente;
            set
                {
                if (value != null)
                    cliente = value;
                else
                    throw new ArgumentException("Cliente no puede ser nulo."); // corregido
                }
            }

        public Empleado Empleado
            {
            get => empleado;
            set
                {
                if (value != null)
                    empleado = value;
                else
                    throw new ArgumentException("Empleado no puede ser nulo.");
                }
            }

        public List<Servicio> Servicios
            {
            get => servicios;
            set
                {
                if (value != null && value.Count > 0)
                    servicios = value;
                else
                    throw new ArgumentException("La lista de servicios no puede estar vacía.");
                }
            }

        public double CostoTotal
            {
            get => costoTotal;
            set
                {
                if (value >= 0)
                    costoTotal = value;
                else
                    throw new ArgumentException("Costo total inválido.");
                }
            }

        public eEstadoCita Estado
            {
            get => estado;
            set
                {
                if (Enum.IsDefined(typeof(eEstadoCita), value))
                    estado = value;
                else
                    throw new ArgumentException("Estado de cita inválido.");
                }
            }

        public TimeSpan Duracion
            {
            get => duracion;
            set
                {
                if (value.TotalMinutes > 0)
                    duracion = value;
                else
                    throw new ArgumentException("Duración inválida.");
                }
            }

        public eTipoCita TipoCitaAsignada
            {
            get => tipoCita;
            set
                {
                if (Enum.IsDefined(typeof(eTipoCita), value))
                    tipoCita = value;
                else
                    throw new ArgumentException("Tipo de cita inválido.");
                }
            }

        // Constructor
        public Cita(DateTime inputFecha, Cliente inputCliente, Empleado inputEmpleado,
                    List<Servicio> inputServicios, eEstadoCita inputEstado,
                    TimeSpan inputDuracion, eTipoCita inputTipoCita)
            {
            this.IdCita = GenerarIDCita();
            this.FechaHoraCita = inputFecha;
            this.Cliente = inputCliente;
            this.Empleado = inputEmpleado;
            this.Servicios = inputServicios;
            this.CostoTotal = CalcularCostoTotal(inputServicios);
            this.Estado = inputEstado;
            this.Duracion = inputDuracion;
            this.TipoCitaAsignada = inputTipoCita;
            }

        // Métodos
        private int GenerarIDCita() => ++contadorIDCita;

        private double CalcularCostoTotal(List<Servicio> servicios)
            {
            double total = 0;
            foreach (var servicio in servicios)
                total += servicio.Precio;
            return total;
            }

        public override string ToString()
            {
            var sb = new StringBuilder();
            sb.AppendLine($"ID Cita: {idCita}");
            sb.AppendLine($"Fecha y Hora: {fechaHoraCita}");
            sb.AppendLine($"Cliente: {cliente.Nombre} {cliente.Apellido1} {cliente.Apellido2}");
            sb.AppendLine($"Empleado: {empleado.Nombre} {empleado.Apellido1} {empleado.Apellido2}");
            sb.AppendLine("Servicios:");
            foreach (var servicio in servicios)
                sb.AppendLine($"\t- {servicio.NombreServicio}: {servicio.Precio:C}");
            sb.AppendLine($"Costo Total: {costoTotal:C}");
            sb.AppendLine($"Estado: {estado}");
            sb.AppendLine($"Duración: {duracion}");
            sb.AppendLine($"Tipo de Cita: {tipoCita}");
            return sb.ToString();
            }

        public void MostrarCita() => Console.WriteLine(this);

        public TimeSpan CalcularDuracionTotal(List<Servicio> servicios)
            {
            TimeSpan duracionTotal = TimeSpan.Zero;
            foreach (var servicio in servicios)
                duracionTotal += TimeSpan.FromMinutes(30);
            return duracionTotal;
            }

        private protected bool ValidarFechaCita(DateTime fechaCita) => fechaCita >= DateTime.Now.AddDays(7);
        private protected bool ValidarNoDomingo(DateTime fechaCita) => fechaCita.DayOfWeek != DayOfWeek.Sunday;
        private protected bool ValidarHoraCita(DateTime fechaCita)
            {
            var hora = fechaCita.TimeOfDay;
            var inicio = new TimeSpan(9, 0, 0);
            var fin = new TimeSpan(19, 0, 0);
            return hora >= inicio && hora <= fin;
            }
        }
    }
