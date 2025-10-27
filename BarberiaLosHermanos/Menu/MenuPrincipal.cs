using System;
using BarberiaLosHermanos.Clases;
using BarberiaLosHermanos.Gestores;

namespace BarberiaLosHermanos.Menu
    {
    public class MenuPrincipal
        {
        private readonly GestorClientes gestorClientes;
        private readonly GestorEmpleados gestorEmpleados;
        private readonly GestorCitas gestorCitas;
        private readonly GestorServicios gestorServicios;
        private readonly GestorHorarios gestorHorarios;

        public MenuPrincipal()
            {
            gestorClientes = new GestorClientes();
            gestorEmpleados = new GestorEmpleados();
            gestorCitas = new GestorCitas();
            gestorServicios = new GestorServicios();
            gestorHorarios = new GestorHorarios();
            }

        public void MostrarMenu()
            {
            int opcion = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine("     SISTEMA BARBERÍA LOS HERMANOS");
                Console.WriteLine("===============================================");
                Console.WriteLine("1. Control de Clientes");
                Console.WriteLine("2. Gestión de Citas");
                Console.WriteLine("3. Gestión de Servicios");
                Console.WriteLine("4. Gestión de Empleados");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    {
                    Console.WriteLine("Entrada inválida. Intente nuevamente.");
                    Console.ReadKey();
                    continue;
                    }

                switch (opcion)
                    {
                    case 1: MenuClientes(); break;
                    case 2: MenuCitas(); break;
                    case 3: MenuServicios(); break;
                    case 4: MenuEmpleados(); break;
                    case 5: Console.WriteLine("Saliendo del sistema..."); break;
                    default: Console.WriteLine("Opción no válida."); break;
                    }

                if (opcion != 5)
                    {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    }

                } while (opcion != 5);
            }

        // === CLIENTES ===
        private void MenuClientes()
            {
            int opcion = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== CONTROL DE CLIENTES ===");
                Console.WriteLine("1. Registrar nuevo cliente");
                Console.WriteLine("2. Buscar cliente por nombre");
                Console.WriteLine("3. Mostrar todos los clientes");
                Console.WriteLine("4. Ver historial de citas de un cliente");
                Console.WriteLine("5. Regresar");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    continue;

                switch (opcion)
                    {
                    case 1: RegistrarCliente(); break;
                    case 2:
                        Console.Write("Nombre: ");
                        gestorClientes.BuscarPorNombre(Console.ReadLine()!);
                        break;
                    case 3: gestorClientes.MostrarClientes(); break;
                    case 4:
                        Console.Write("ID Cliente: ");
                        if (int.TryParse(Console.ReadLine(), out int idC))
                            gestorCitas.MostrarPorCliente(idC);
                        break;
                    }
                } while (opcion != 5);
            }

        private void RegistrarCliente()
            {
            try
                {
                Console.Clear();
                Console.WriteLine("=== REGISTRO DE CLIENTE ===");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine()!;

                Console.Write("Primer apellido: ");
                string apellido1 = Console.ReadLine()!;

                Console.Write("Segundo apellido: ");
                string apellido2 = Console.ReadLine()!;

                Console.Write("Teléfono: ");
                string telefono = Console.ReadLine()!;

                Console.Write("Correo: ");
                string correo = Console.ReadLine()!;

                Cliente nuevoCliente = new Cliente(nombre, apellido1, apellido2, telefono, correo);
                gestorClientes.RegistrarCliente(nuevoCliente);

                Console.WriteLine($"\nCliente registrado correctamente con ID asignado: {nuevoCliente.IdCliente}");
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error: {ex.Message}");
                }
            }


        // === EMPLEADOS ===
        private void MenuEmpleados()
            {
            int opcion = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE EMPLEADOS ===");
                Console.WriteLine("1. Mostrar empleados");
                Console.WriteLine("2. Agregar empleado");
                Console.WriteLine("3. Regresar");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    continue;

                switch (opcion)
                    {
                    case 1: gestorEmpleados.MostrarEmpleados(); break;
                    case 2: RegistrarEmpleado(); break;
                    }

                } while (opcion != 3);
            }

        private void RegistrarEmpleado()
            {
            try
                {
                Console.Clear();
                Console.WriteLine("=== NUEVO EMPLEADO ===");
                Console.Write("Nombre: "); string nombre = Console.ReadLine()!;
                Console.Write("Primer apellido: "); string apellido1 = Console.ReadLine()!;
                Console.Write("Segundo apellido: "); string apellido2 = Console.ReadLine()!;
                Console.Write("Teléfono: "); string telefono = Console.ReadLine()!;
                Console.Write("Correo: "); string correo = Console.ReadLine()!;
                Console.Write("Salario: "); double salario = double.Parse(Console.ReadLine()!);

                Console.Write("Puesto (0=Barbero,1=Estilista,2=Asistente,3=Administrativo): ");
                int puesto = int.Parse(Console.ReadLine()!);

                var empleado = new Empleado(nombre, apellido1, apellido2, telefono, correo, (Empleado.PuestoEmpleado)puesto, salario);
                gestorEmpleados.AgregarEmpleado(empleado);
                Console.WriteLine($"Empleado creado con ID: {empleado.IdEmpleado}");
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error: {ex.Message}");
                }
            }

        // === SERVICIOS ===
        private void MenuServicios()
            {
            int opcion = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE SERVICIOS ===");
                Console.WriteLine("1. Mostrar servicios");
                Console.WriteLine("2. Agregar servicio");
                Console.WriteLine("3. Modificar servicio");
                Console.WriteLine("4. Eliminar servicio");
                Console.WriteLine("5. Restaurar base");
                Console.WriteLine("6. Regresar");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    continue;

                switch (opcion)
                    {
                    case 1: gestorServicios.MostrarServicios(); break;
                    case 2: RegistrarServicio(); break;
                    case 3: ModificarServicio(); break;
                    case 4: EliminarServicio(); break;
                    case 5: gestorServicios.InicializarServiciosBase(); break;
                    }
                } while (opcion != 6);
            }

        private void RegistrarServicio()
            {
            Console.Clear();
            Console.WriteLine("=== NUEVO SERVICIO ===");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine()!;

            Console.Write("Precio: ");
            if (!double.TryParse(Console.ReadLine(), out double precio))
                {
                Console.WriteLine("Precio inválido.");
                return;
                }

            Console.Write("Tipo de empleado (0=Barbero,1=Estilista,2=Asistente,3=Administrativo): ");
            if (!int.TryParse(Console.ReadLine(), out int tipo))
                {
                Console.WriteLine("Tipo inválido.");
                return;
                }

            var servicio = new Servicio(nombre, precio, (Empleado.PuestoEmpleado)tipo);
            gestorServicios.AgregarServicio(servicio);
            Console.WriteLine($"\nServicio creado correctamente con ID: {servicio.IdServicio}");
            }


        private void ModificarServicio()
            {
            Console.Write("ID del servicio a modificar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Console.Write("Nuevo nombre: "); string nombre = Console.ReadLine()!;
            Console.Write("Nuevo precio: "); double precio = double.Parse(Console.ReadLine()!);
            Console.Write("Nuevo tipo (0=Barbero,1=Estilista,2=Asistente,3=Administrativo): ");
            int tipo = int.Parse(Console.ReadLine()!);

            gestorServicios.ModificarServicio(id, nombre, precio, (Empleado.PuestoEmpleado)tipo);
            }

        private void EliminarServicio()
            {
            Console.Write("ID del servicio a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;
            gestorServicios.EliminarServicio(id);
            }

        // === CITAS ===
        private void MenuCitas()
            {
            int opcion = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE CITAS ===");
                Console.WriteLine("1. Agendar nueva cita");
                Console.WriteLine("2. Mostrar todas las citas");
                Console.WriteLine("3. Buscar cita por fecha");
                Console.WriteLine("4. Cancelar cita");
                Console.WriteLine("5. Confirmar cita");
                Console.WriteLine("6. Regresar");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    continue;

                switch (opcion)
                    {
                    case 1: AgendarCita(); break;
                    case 2: gestorCitas.MostrarTodas(); break;
                    case 3:
                        Console.Write("Fecha (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
                            gestorCitas.BuscarPorFecha(fecha);
                        break;
                    case 4:
                        Console.Write("ID cita a cancelar: ");
                        if (int.TryParse(Console.ReadLine(), out int idCancelar)) gestorCitas.CancelarCita(idCancelar);
                        break;
                    case 5:
                        Console.Write("ID cita a confirmar: ");
                        if (int.TryParse(Console.ReadLine(), out int idConfirmar)) gestorCitas.ConfirmarCita(idConfirmar);
                        break;
                    }
                } while (opcion != 6);
            }

        private void AgendarCita()
            {
            try
                {
                Console.Clear();
                Console.WriteLine("=== AGENDAR NUEVA CITA ===");

                // Registrar cliente
                Console.Write("Nombre cliente: "); string nombreCliente = Console.ReadLine()!;
                Console.Write("Primer apellido: "); string apellido1 = Console.ReadLine()!;
                Console.Write("Segundo apellido: "); string apellido2 = Console.ReadLine()!;
                Console.Write("Teléfono: "); string telefono = Console.ReadLine()!;
                Console.Write("Correo: "); string correo = Console.ReadLine()!;
                var cliente = new Cliente(nombreCliente, apellido1, apellido2, telefono, correo);
                gestorClientes.RegistrarCliente(cliente);
                Console.WriteLine($"Cliente ID: {cliente.IdCliente}");

                // Elegir empleado existente
                Console.WriteLine("\nSeleccione empleado:");
                gestorEmpleados.MostrarEmpleados();
                Console.Write("ID empleado: ");
                if (!int.TryParse(Console.ReadLine(), out int idEmp))
                    {
                    Console.WriteLine("Empleado inválido.");
                    return;
                    }
                var empleado = gestorEmpleados.BuscarPorId(idEmp);
                if (empleado == null)
                    {
                    Console.WriteLine("Empleado no encontrado.");
                    return;
                    }

                // Elegir servicio
                Console.WriteLine("\nSeleccione servicio:");
                gestorServicios.MostrarServicios();
                Console.Write("ID servicio: ");
                if (!int.TryParse(Console.ReadLine(), out int idServ))
                    {
                    Console.WriteLine("Servicio inválido.");
                    return;
                    }
                var servicio = gestorServicios.BuscarServicioPorId(idServ);
                if (servicio == null)
                    {
                    Console.WriteLine("Servicio no encontrado.");
                    return;
                    }

                // Mostrar horarios disponibles
                gestorHorarios.MostrarDisponibles(15);
                Console.Write("\nSeleccione un número de horario (1–15): ");
                if (!int.TryParse(Console.ReadLine(), out int indice))
                    {
                    Console.WriteLine("Selección inválida.");
                    return;
                    }

                int total;
                var slot = gestorHorarios.ReservarPorIndice(indice, out total);
                if (slot == null)
                    {
                    Console.WriteLine("No se pudo reservar el horario.");
                    return;
                    }

                var cita = new Cita(cliente, empleado, servicio, slot.Inicio);
                gestorCitas.AgregarCita(cita);
                Console.WriteLine($"\nCita creada: ID {cita.IdCita} | {slot.Inicio:dddd dd/MM/yyyy HH:mm}");
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
