using System;
using System.Collections.Generic;
using System.Linq;
using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Gestores
    {
    public class GestorHorarios
        {
        private readonly GestorCitas _gestorCitas;
        private List<Horario> _horariosDisponibles;

        public GestorHorarios(GestorCitas gestorCitas)
            {
            _gestorCitas = gestorCitas;
            _horariosDisponibles = new List<Horario>();
            }

        // Genera días válidos (desde 7 días adelante hasta 3 meses, sin domingos)
        public List<DateTime> ObtenerDiasDisponibles()
            {
            var dias = new List<DateTime>();
            DateTime inicio = DateTime.Now.Date.AddDays(7);
            DateTime limite = inicio.AddMonths(3);

            for (DateTime d = inicio; d <= limite; d = d.AddDays(1))
                {
                if (d.DayOfWeek != DayOfWeek.Sunday)
                    dias.Add(d);
                }

            return dias;
            }

        public void MostrarDiasDisponibles()
            {
            var dias = ObtenerDiasDisponibles();
            Console.WriteLine("=== DÍAS DISPONIBLES ===");
            for (int i = 0; i < dias.Count; i++)
                Console.WriteLine($"{i + 1}. {dias[i]:dddd dd/MM/yyyy}");
            }

        public List<Horario> ObtenerHorasDisponibles(DateTime dia, Empleado empleado)
            {
            var horas = new List<Horario>();

            for (int h = 9; h <= 17; h++) // 9 a 17 (8 horas)
                {
                DateTime hora = new DateTime(dia.Year, dia.Month, dia.Day, h, 0, 0);
                if (!_gestorCitas.ExisteCitaEnHorario(empleado, hora))
                    horas.Add(new Horario(hora));
                }

            _horariosDisponibles = horas;
            return horas;
            }

        public void MostrarHorasDisponibles(List<Horario> horas)
            {
            Console.WriteLine("\n=== HORARIOS DISPONIBLES ===");
            for (int i = 0; i < horas.Count; i++)
                Console.WriteLine($"{i + 1}. {horas[i].Inicio:HH:mm}");
            }

        public Horario ReservarPorIndice(int indice)
            {
            if (indice < 1 || indice > _horariosDisponibles.Count)
                return null;

            var horario = _horariosDisponibles[indice - 1];
            horario.Disponible = false;
            return horario;
            }
        }
    }
