using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberiaLosHermanos
    {
    public class GestorServicio
        {
        // Atributos privados
        private List<Servicio> listaServicios;

        // Constructor
        public GestorServicio()
            {
            listaServicios = new List<Servicio>();
            }

        //Metodos de la clase

        // Agregar un nuevo servicio y su precio
        public void AgregarServicio(string nombreServicio, double precio, string descripcion)
            {
            if (string.IsNullOrWhiteSpace(nombreServicio))
                throw new ArgumentException("El nombre del servicio no puede estar vacío.");

            if (precio < 0)
                throw new ArgumentException("El precio del servicio no puede ser negativo.");

            int nuevoId = listaServicios.Count > 0 ? listaServicios.Max(s => s.IdServicio) + 1 : 1;
            var nuevoServicio = new Servicio(nuevoId, nombreServicio.Trim(), precio, descripcion.Trim());
            listaServicios.Add(nuevoServicio);
            }

        // Sobrecarga: agregar un objeto Servicio completo
        public void AgregarServicio(Servicio nuevoServicio)
            {
            if (nuevoServicio == null)
                throw new ArgumentNullException(nameof(nuevoServicio), "El servicio no puede ser nulo.");

            if (listaServicios.Any(s => s.IdServicio == nuevoServicio.IdServicio))
                throw new InvalidOperationException("Ya existe un servicio con el mismo ID.");

            if (nuevoServicio.Precio < 0)
                throw new ArgumentException("El precio del servicio no puede ser negativo.");

            listaServicios.Add(nuevoServicio);
            }

        // Listar todos los servicios (copia segura)
        public List<Servicio> ObtenerTodosServicios()
            {
            return new List<Servicio>(listaServicios);
            }

        // Buscar por nombre
        public List<Servicio> BuscarServicioPorNombre(string nombreServicio)
            {
            if (string.IsNullOrWhiteSpace(nombreServicio))
                {
                Console.WriteLine("Debe ingresar un nombre de servicio válido.");
                return new List<Servicio>();
                }

            string nombreLimpio = nombreServicio.Trim();

            var resultados = listaServicios
                .Where(s => s.NombreServicio.Equals(nombreLimpio, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (resultados.Count == 0)
                Console.WriteLine($"No se encontró ningún servicio con el nombre '{nombreLimpio}'.");

            return resultados;
            }

        // Buscar por ID (devuelve solo uno)
        public Servicio BuscarServicioPorID(int idServicio)
            {
            if (idServicio <= 0)
                {
                Console.WriteLine("El ID ingresado no es válido.");
                return null;
                }

            var servicio = listaServicios.FirstOrDefault(s => s.IdServicio == idServicio);

            if (servicio == null)
                {
                Console.WriteLine($"No se encontró ningún servicio con el ID '{idServicio}'.");
                return null;
                }

            return servicio;
            }

        // Actualizar precio de un servicio existente por ID
        public bool ActualizarPrecioPorId(int idServicio, double nuevoPrecio)
            {
            if (nuevoPrecio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");

            var servicio = BuscarServicioPorID(idServicio);
            if (servicio == null)
                return false;

            servicio.Precio = nuevoPrecio;
            Console.WriteLine($"Precio del servicio con ID {idServicio} actualizado a ₡{nuevoPrecio:0.00}.");
            return true;
            }

        // Actualizar precio de un servicio existente por nombre
        public bool ActualizarPrecioPorNombre(string nombreServicio, double nuevoPrecio)
            {
            if (string.IsNullOrWhiteSpace(nombreServicio))
                throw new ArgumentException("El nombre del servicio no puede estar vacío.");

            if (nuevoPrecio < 0)
                throw new ArgumentException("El precio no puede ser negativo.");

            var servicios = BuscarServicioPorNombre(nombreServicio);
            if (servicios.Count == 0)
                return false;

            foreach (var servicio in servicios)
                servicio.Precio = nuevoPrecio;

            Console.WriteLine($"Se actualizó el precio de {servicios.Count} servicio(s) a ₡{nuevoPrecio:0.00}.");
            return true;
            }

        // Eliminar servicio por ID
        public bool EliminarServicio(int idServicio)
            {
            var servicio = BuscarServicioPorID(idServicio);
            if (servicio == null)
                return false;

            listaServicios.Remove(servicio);
            Console.WriteLine($"Servicio con ID {idServicio} eliminado correctamente.");
            return true;
            }
        }

    } //fin de la clase GestorServicio

