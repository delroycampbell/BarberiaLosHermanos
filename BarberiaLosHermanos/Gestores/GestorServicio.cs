using System;
using System.Collections.Generic;
using System.Linq;
using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Gestores
    {
    public class GestorServicios
        {
        private readonly List<Servicio> _servicios;

        public GestorServicios()
            {
            _servicios = new List<Servicio>();
            InicializarServiciosBase();
            }

        public void InicializarServiciosBase()
            {
            _servicios.Clear();
            _servicios.Add(new Servicio("Corte de Caballero", 5000, Empleado.PuestoEmpleado.Barbero));
            _servicios.Add(new Servicio("Afeitado Clásico", 3500, Empleado.PuestoEmpleado.Barbero));
            _servicios.Add(new Servicio("Tinte de Cabello", 7000, Empleado.PuestoEmpleado.Estilista));
            _servicios.Add(new Servicio("Lavado de Cabello", 2000, Empleado.PuestoEmpleado.Asistente));
            Console.WriteLine("Servicios base inicializados correctamente.");
            }

        public void MostrarServicios()
            {
            if (_servicios.Count == 0)
                {
                Console.WriteLine("No hay servicios registrados.");
                return;
                }
            Console.WriteLine("=== Lista de Servicios ===");
            foreach (var s in _servicios) s.MostrarServicio();
            }

        public void AgregarServicio(Servicio nuevo)
            {
            if (nuevo == null)
                {
                Console.WriteLine("Servicio inválido.");
                return;
                }
            _servicios.Add(nuevo);
            Console.WriteLine($"Servicio '{nuevo.Nombre}' agregado. ID: {nuevo.IdServicio}");
            }

        public void ModificarServicio(int idServicio, string nuevoNombre, double nuevoPrecio, Empleado.PuestoEmpleado nuevoTipo)
            {
            var s = _servicios.FirstOrDefault(x => x.IdServicio == idServicio);
            if (s == null)
                {
                Console.WriteLine($"No se encontró el servicio con ID {idServicio}.");
                return;
                }

            s.Nombre = nuevoNombre;
            s.Precio = nuevoPrecio;
            s.TipoEmpleado = nuevoTipo;
            Console.WriteLine($"Servicio {idServicio} modificado.");
            }

        public void EliminarServicio(int idServicio)
            {
            var s = _servicios.FirstOrDefault(x => x.IdServicio == idServicio);
            if (s == null)
                {
                Console.WriteLine($"No se encontró el servicio con ID {idServicio}.");
                return;
                }
            _servicios.Remove(s);
            Console.WriteLine($"Servicio {idServicio} eliminado.");
            }

        public Servicio BuscarServicioPorId(int idServicio)
            {
            return _servicios.FirstOrDefault(s => s.IdServicio == idServicio);
            }

        public List<Servicio> ObtenerTodos()
            {
            return _servicios.ToList();
            }
        }
    }
