using System;
using BarberiaLosHermanos;

Console.WriteLine("Hello, World!");

Barbero barbero1 = new Barbero("Delroy","Campbell","Thomas","70725850","TEST@EMAIL.COM",350000, DateTime.Now, 2);

barbero1.HorasTrabajadas = 160;
barbero1.ComisionPorCorte = 1500;
barbero1.Especialidades = new List<string> { "Cortes Clásicos", "Afeitado Tradicional" };

Console.WriteLine(barbero1.MostrarDatos());







