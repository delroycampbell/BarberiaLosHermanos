using System;
using System.Collections.Generic;
using System.Text;

namespace BarberiaLosHermanos.Clases
    {
    public class Barbero : Empleado
        {
        private int anosExperiencia;
        private List<string> especialidades;
        private double horasTrabajadas;
        private double comisionPorCorte;

        public int AnosExperiencia
            {
            get => anosExperiencia;
            set
                {
                if (value < 0 || value > 60)
                    throw new ArgumentException("Años de experiencia inválidos.");
                anosExperiencia = value;
                }
            }

        public List<string> Especialidades
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

        public Barbero(string nombre, string apellido1, string apellido2, string telefono, string correo,
                       double salario, DateTime fechaContratacion,
                       int anosExperiencia, List<string>? especialidades = null)
            : base(nombre, apellido1, apellido2, telefono, correo, PuestoEmpleado.Barbero, salario)
            {
            AnosExperiencia = anosExperiencia;
            Especialidades = especialidades ?? new List<string>();
            horasTrabajadas = 0;
            comisionPorCorte = 0;
            }

        public void MostrarEspecialidades()
            {
            Console.WriteLine($"Especialidades de {Nombre} {Apellido1}:");
            if (especialidades.Count == 0)
                {
                Console.WriteLine("- Sin especialidades registradas.");
                return;
                }

            foreach (var esp in especialidades)
                Console.WriteLine($"- {esp}");
            }

        public override void MostrarInfo()
            {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID: {IdEmpleado}");
            sb.AppendLine($"Nombre: {Nombre} {Apellido1} {Apellido2}");
            sb.AppendLine($"Teléfono: {Telefono}");
            sb.AppendLine($"Correo: {Correo}");
            sb.AppendLine($"Puesto: {Puesto}");
            sb.AppendLine($"Salario base: {Salario:N2} colones");
            sb.AppendLine($"Años de experiencia: {anosExperiencia}");
            sb.AppendLine($"Horas trabajadas: {horasTrabajadas}");
            sb.AppendLine($"Comisión por corte: {comisionPorCorte:N2} colones");
            sb.AppendLine($"Salario total (con comisión): {Salario + comisionPorCorte:N2} colones");

            Console.WriteLine(sb.ToString());
            }
        }
    }
