using System;
using System.Collections.Generic;
using System.Linq;
using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Gestores
    {
    public class GestorHorarios
        {
        private readonly List<TimeSlot> _bloques;

        public GestorHorarios()
            {
            _bloques = new List<TimeSlot>();
            GenerarBloquesDisponibles();
            }

        private void GenerarBloquesDisponibles()
            {
            DateTime hoy = DateTime.Now.Date;
            DateTime inicio = hoy.AddDays(7);
            DateTime fin = hoy.AddMonths(3);

            for (DateTime fecha = inicio; fecha <= fin; fecha = fecha.AddDays(1))
                {
                if (fecha.DayOfWeek == DayOfWeek.Sunday) continue;

                for (int hora = 9; hora < 17; hora++)
                    {
                    var ini = new DateTime(fecha.Year, fecha.Month, fecha.Day, hora, 0, 0);
                    var finBloque = ini.AddHours(1);
                    _bloques.Add(new TimeSlot(ini, finBloque));
                    }
                }
            }

        public List<TimeSlot> ObtenerDisponibles()
            {
            return _bloques.Where(b => b.Disponible).ToList();
            }

        public void MostrarDisponibles(int max = 15)
            {
            var disp = ObtenerDisponibles().Take(max).ToList();
            if (disp.Count == 0)
                {
                Console.WriteLine("No hay horarios disponibles.");
                return;
                }

            Console.WriteLine("\n=== HORARIOS DISPONIBLES (siguientes) ===");
            for (int i = 0; i < disp.Count; i++)
                {
                Console.Write($"{i + 1}. ");
                disp[i].Mostrar();
                }
            }

        public TimeSlot ReservarPorIndice(int indiceBase1, out int totalMostrados)
            {
            var disp = ObtenerDisponibles().Take(15).ToList();
            totalMostrados = disp.Count;
            if (indiceBase1 < 1 || indiceBase1 > disp.Count) return null;

            var slot = disp[indiceBase1 - 1];
            slot.Disponible = false;
            return slot;
            }

        public bool MarcarOcupado(DateTime inicio)
            {
            var slot = _bloques.FirstOrDefault(b => b.Inicio == inicio);
            if (slot == null || !slot.Disponible) return false;
            slot.Disponible = false;
            return true;
            }

        public bool EstaDisponible(DateTime inicio)
            {
            var slot = _bloques.FirstOrDefault(b => b.Inicio == inicio);
            return slot != null && slot.Disponible;
            }
        }
    }
