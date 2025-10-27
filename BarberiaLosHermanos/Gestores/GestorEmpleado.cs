using System;
using System.Collections.Generic;
using System.Linq;
using BarberiaLosHermanos.Clases;

namespace BarberiaLosHermanos.Gestores
    {
    public class GestorEmpleados
        {
        private readonly List<Empleado> _empleados;

        public GestorEmpleados()
            {
            _empleados = new List<Empleado>();
            InicializarEmpleadosBase();
            }

        private void InicializarEmpleadosBase()
            {
            _empleados.Add(new Empleado("Luis", "García", "Mora", "8888-1111", "luis@barberia.com", Empleado.PuestoEmpleado.Barbero, 550000));
            _empleados.Add(new Empleado("Ana", "Rojas", "Vega", "8888-2222", "ana@barberia.com", Empleado.PuestoEmpleado.Estilista, 520000));
            _empleados.Add(new Empleado("Carlos", "Soto", "León", "8888-3333", "carlos@barberia.com", Empleado.PuestoEmpleado.Barbero, 560000));
            }

        public void MostrarEmpleados()
            {
            if (_empleados.Count == 0)
                {
                Console.WriteLine("No hay empleados registrados.");
                return;
                }
            Console.WriteLine("=== Empleados Disponibles ===");
            foreach (var e in _empleados) e.MostrarInfo();
            }

        public void MostrarEmpleadosParaCita()
            {
            if (_empleados.Count == 0)
                {
                Console.WriteLine("No hay empleados registrados.");
                return;
                }

            Console.WriteLine("=== EMPLEADOS DISPONIBLES ===");
            foreach (var e in _empleados)
                Console.WriteLine($"ID: {e.IdEmpleado} | {e.Nombre} {e.Apellido1} ({e.Puesto})");
            }


        public Empleado BuscarPorId(int id)
            {
            return _empleados.FirstOrDefault(e => e.IdEmpleado == id);
            }

        public List<Empleado> ObtenerTodos()
            {
            return _empleados.ToList();
            }

        public void AgregarEmpleado(Empleado e)
            {
            if (e == null)
                {
                Console.WriteLine("Empleado inválido.");
                return;
                }
            _empleados.Add(e);
            Console.WriteLine($"Empleado agregado: ID {e.IdEmpleado}");
            }
        }
    }
