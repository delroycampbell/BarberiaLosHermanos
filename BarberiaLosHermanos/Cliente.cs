using System;
using System.Collections.Generic;

namespace BarberiaLosHermanos
    {
    public class Cliente : Persona
        {
        // Atributos
        private int idCliente;
        private DateTime fechaRegistro;
        private List<Cita> historialCitas;
        private double puntosAcumulados;
        private eTipoMembresia tipoMembresia;
        private static int contadorIDCliente = 0;

        // Enum de membresía
        public enum eTipoMembresia
            {
            Ninguna,
            Plata,
            Oro,
            Platino
            }

        // Constructor
        public Cliente(string nombre, string apellido1, string apellido2, string telefono, string correo)
            : base(nombre, apellido1, apellido2, telefono, correo)
            {
            this.idCliente = GenerarIdCliente(); // ID automático
            this.fechaRegistro = DateTime.Now;
            this.puntosAcumulados = 0;
            this.historialCitas = new List<Cita>();
            this.tipoMembresia = eTipoMembresia.Ninguna;
            }

        // Propiedades
        public int IdCliente
            {
            get => idCliente;
            set
                {
                if (ValidarIdCliente(value))
                    idCliente = value;
                else
                    throw new ArgumentException("ID de cliente inválido.");
                }
            }

        public DateTime FechaRegistro
            {
            get => fechaRegistro;
            set => fechaRegistro = value;
            }

        public List<Cita> HistorialCitas
            {
            get => historialCitas;
            set => historialCitas = value;
            }

        public double PuntosAcumulados
            {
            get => puntosAcumulados;
            set
                {
                if (value >= 0)
                    puntosAcumulados = value;
                else
                    throw new ArgumentException("Los puntos acumulados no pueden ser negativos.");
                }
            }

        public eTipoMembresia Membresia
            {
            get => tipoMembresia;
            set => tipoMembresia = value;
            }

        // Método heredado para mostrar datos
        public override string MostrarDatos()
            {
            return $"ID Cliente: {idCliente}\n" +
                   $"Nombre: {Nombre} {Apellido1} {Apellido2}\n" +
                   $"Teléfono: {Telefono}\n" +
                   $"Correo: {Correo}\n" +
                   $"Fecha de Registro: {fechaRegistro:d}\n" +
                   $"Puntos Acumulados: {puntosAcumulados}\n" +
                   $"Membresía: {tipoMembresia}";
            }

        // Mostrar información del cliente
        public void MostrarCliente()
            {
            Console.WriteLine(MostrarDatos());
            }

        // Validaciones
        private bool ValidarIdCliente(int id)
            {
            return id > 0;
            }

        // Generar ID único
        private int GenerarIdCliente()
            {
            return ++contadorIDCliente;
            }
        }
    }
