using System;
using System.Collections.Generic;
using System.Linq;
using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Gestores
    {
    public class GestorClientes
        {
        private readonly List<Cliente> _clientes;

        public GestorClientes()
            {
            _clientes = new List<Cliente>();
            }

        public void RegistrarCliente(Cliente nuevo)
            {
            if (nuevo == null)
                {
                Console.WriteLine("Cliente inválido.");
                return;
                }
            _clientes.Add(nuevo);
            Console.WriteLine($"Cliente agregado: ID {nuevo.IdCliente}");
            }

        public Cliente BuscarPorNombre(string nombre)
            {
            var c = _clientes.FirstOrDefault(x =>
                x.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)
            );

            if (c == null) Console.WriteLine($"No se encontró cliente con nombre '{nombre}'.");
            else c.MostrarInfo();

            return c;
            }

        public Cliente BuscarPorId(int id)
            {
            return _clientes.FirstOrDefault(x => x.IdCliente == id);
            }

        public void MostrarClientes()
            {
            if (_clientes.Count == 0)
                {
                Console.WriteLine("No hay clientes registrados.");
                return;
                }
            Console.WriteLine("=== Lista de Clientes ===");
            foreach (var c in _clientes) c.MostrarInfo();
            }

        public List<Cliente> ObtenerTodos()
            {
            return _clientes.ToList();
            }
        }
    }
