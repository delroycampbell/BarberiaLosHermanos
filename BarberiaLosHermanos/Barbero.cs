using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarberiaLosHermanos
    {
    internal class Barbero : Empleado
        {
        // Atributos específicos de Barbero
        private int añosExperiencia;
        private List<string>? especialidades = new List<string>();
        private double horasTrabajadas;
        private double comisionPorCorte;

        // Propiedades
        public int AñosExperiencia
            {
            get => añosExperiencia;
            set
                {
                if (ValidarAñosExperiencia(value))
                    añosExperiencia = value;
                else
                    throw new ArgumentException("Años de experiencia inválidos.");
                }
            }

        public List<string>? Especialidades
            {
            get => especialidades;
            set => especialidades = value ?? new List<string>();
            }

        public double HorasTrabajadas
            {
            get => horasTrabajadas;
            set
                {
                if (value < 0)
                    throw new ArgumentException("Las horas trabajadas no pueden ser negativas.");
                horasTrabajadas = value;
                }
            }

        public double ComisionPorCorte
            {
            get => comisionPorCorte;
            set
                {
                if (value < 0)
                    throw new ArgumentException("La comisión no puede ser negativa.");
                comisionPorCorte = value;
                }
            }

        // Constructor
        public Barbero(string nombre, string apellido1, string apellido2, string telefono, string correo,
                       double salario, DateTime fechaContratacion,
                       int añosExperiencia, List<string>? especialidades = null)
            : base(nombre, apellido1, apellido2, telefono, correo, ePuestos.Barbero, salario, fechaContratacion)
            {
            this.AñosExperiencia = añosExperiencia;
            this.Especialidades = especialidades ?? new List<string>();
            this.horasTrabajadas = 0;
            this.comisionPorCorte = 0;
            }

        // Validaciones
        private bool ValidarAñosExperiencia(int años)
            {
            return años >= 0 && años <= 60; // rango razonable
            }

        // Métodos específicos de Barbero
        public void MostrarEspecialidades()
            {
            Console.WriteLine($"Especialidades de {Nombre} {Apellido1}:");
            if (especialidades == null || especialidades.Count == 0)
                {
                Console.WriteLine("- Sin especialidades registradas.");
                return;
                }

            foreach (var esp in especialidades)
                Console.WriteLine($"- {esp}");
            }

        public override string MostrarDatos()
            {
            var sb = new StringBuilder(base.MostrarDatos());
            sb.AppendLine($"Años de Experiencia: {añosExperiencia}");
            sb.AppendLine($"Especialidades: {(especialidades != null && especialidades.Any() ? string.Join(", ", especialidades) : "Sin especialidades")}");
            sb.AppendLine($"Horas Trabajadas: {horasTrabajadas}");
            sb.AppendLine($"Comisión por Corte: {comisionPorCorte:C}");
            return sb.ToString();
            }
        }
    }
