using System;

namespace BarberiaLosHermanos.Clases
    {
    public class TimeSlot
        {
        public DateTime Inicio { get; private set; }
        public DateTime Fin { get; private set; }
        public bool Disponible { get; set; }

        public TimeSlot(DateTime inicio, DateTime fin)
            {
            Inicio = inicio;
            Fin = fin;
            Disponible = true; // por defecto está libre
            }

        public void Mostrar()
            {
            string estado = Disponible ? "Disponible" : "Ocupado";
            Console.WriteLine($"{Inicio:dddd dd/MM/yyyy HH:mm} - {Fin:HH:mm}  |  {estado}");
            }
        }
    }
