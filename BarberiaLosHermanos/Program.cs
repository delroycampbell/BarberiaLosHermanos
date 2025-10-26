using System;
using BarberiaLosHermanos;


Console.WriteLine("Bienvenido a la Barbería Los Hermanos!");
// Crear un cliente de ejemplo
// Menu de opciones para manejar los servicios
var s1 = new Servicio(1, "Corte Clásico", 5000, "Corte de cabello tradicional", Servicio.eCategoriaServicio.Barbero);
var s2 = new Servicio(2, "Manicure Básico", 4000, "Limpieza y esmaltado", Servicio.eCategoriaServicio.Manicure);

Console.WriteLine(s1);
Console.WriteLine(s2);






