using System;
using System.Collections.Generic;
using System.Linq;
using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Gestores
    {
    public class GestorServicios
        {
        private List<Servicio> servicios;

        // Constructor
        public GestorServicios()
            {
            servicios = new List<Servicio>();
            InicializarServiciosBase();
            }

        // Cargar servicios iniciales (sin ID manual)
        public void InicializarServiciosBase()
            {
            servicios.Clear();

            servicios.Add(new Servicio("Corte de Caballero", 5000, Empleado.PuestoEmpleado.Barbero));
            servicios.Add(new Servicio("Afeitado Clásico", 3500, Empleado.PuestoEmpleado.Barbero));
            servicios.Add(new Servicio("Tinte de Cabello", 7000, Empleado.PuestoEmpleado.Estilista));
            servicios.Add(new Servicio("Lavado de Cabello", 2000, Empleado.PuestoEmpleado.Asistente));

            Console.WriteLine("Servicios base inicializados correctamente.");
            }

        // Mostrar servicios
        public void MostrarServicios()
            {
            if (servicios.Count == 0)
                {
                Console.WriteLine("No hay servicios registrados.");
                return;
                }

            Console.WriteLine("=== LISTA DE SERVICIOS ===");
            foreach (var servicio in servicios)
                servicio.MostrarServicio();
            }

        // Agregar servicio
        public void AgregarServicio(Servicio nuevo)
            {
            if (servicios.Any(s => s.IdServicio == nuevo.IdServicio))
                {
                Console.WriteLine($"Ya existe un servicio con el ID {nuevo.IdServicio}.");
                return;
                }

            servicios.Add(nuevo);
            Console.WriteLine($"Servicio '{nuevo.Nombre}' agregado correctamente con ID {nuevo.IdServicio}.");
            }

        // Modificar servicio
        public void ModificarServicio(int idServicio, string nuevoNombre, double nuevoPrecio, Empleado.PuestoEmpleado nuevoTipo)
            {
            var servicio = servicios.FirstOrDefault(s => s.IdServicio == idServicio);
            if (servicio == null)
                {
                Console.WriteLine($"No se encontró el servicio con ID {idServicio}.");
                return;
                }

            servicio.Nombre = nuevoNombre;
            servicio.Precio = nuevoPrecio;
            servicio.TipoEmpleado = nuevoTipo;

            Console.WriteLine($"Servicio con ID {idServicio} modificado correctamente.");
            }

        // Eliminar servicio
        public void EliminarServicio(int idServicio)
            {
            var servicio = servicios.FirstOrDefault(s => s.IdServicio == idServicio);
            if (servicio == null)
                {
                Console.WriteLine($"No se encontró el servicio con ID {idServicio}.");
                return;
                }

            servicios.Remove(servicio);
            Console.WriteLine($"Servicio con ID {idServicio} eliminado correctamente.");
            }

        // Buscar servicio por ID
        public Servicio BuscarServicioPorId(int idServicio)
            {
            return servicios.FirstOrDefault(s => s.IdServicio == idServicio);
            }

        // Filtrar servicios según tipo de empleado
        public List<Servicio> ObtenerServiciosPorTipo(Empleado.PuestoEmpleado tipo)
            {
            return servicios.Where(s => s.TipoEmpleado == tipo).ToList();
            }
        }
    }
