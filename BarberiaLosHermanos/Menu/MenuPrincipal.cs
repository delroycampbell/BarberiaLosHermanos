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
            gestorHorarios = new GestorHorarios(gestorCitas);
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
                    Console.WriteLine("Entrada inválida.");
                    Pausa();
                    continue;
                    }

                switch (opcion)
                    {
                    case 1: MenuClientes(); break;
                    case 2: MenuCitas(); break;
                    case 3: MenuServicios(); break;
                    case 4: MenuEmpleados(); break;
                    case 5: Console.WriteLine("Saliendo..."); break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Pausa();
                        break;
                    }
                } while (opcion != 5);
            }

        // ===================== CLIENTES =====================
        private void MenuClientes()
            {
            int op = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== CONTROL DE CLIENTES ===");
                Console.WriteLine("1. Registrar nuevo cliente");
                Console.WriteLine("2. Buscar por nombre");
                Console.WriteLine("3. Mostrar todos");
                Console.WriteLine("4. Historial de citas de un cliente");
                Console.WriteLine("5. Volver");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out op)) continue;

                switch (op)
                    {
                    case 1: RegistrarCliente(); break;
                    case 2:
                        Console.Write("Nombre: ");
                        gestorClientes.BuscarPorNombre(Console.ReadLine() ?? string.Empty);
                        Pausa();
                        break;
                    case 3:
                        gestorClientes.MostrarClientes();
                        Pausa();
                        break;
                    case 4:
                        Console.Write("ID cliente: ");
                        if (int.TryParse(Console.ReadLine(), out int idCli))
                            gestorCitas.MostrarPorCliente(idCli);
                        Pausa();
                        break;
                    }
                } while (op != 5);
            }

        private void RegistrarCliente()
            {
            try
                {
                Console.Clear();
                Console.WriteLine("=== REGISTRO DE CLIENTE ===");
                Console.Write("Nombre: "); string nombre = Console.ReadLine() ?? "";
                Console.Write("Primer apellido: "); string a1 = Console.ReadLine() ?? "";
                Console.Write("Segundo apellido: "); string a2 = Console.ReadLine() ?? "";
                Console.Write("Teléfono: "); string tel = Console.ReadLine() ?? "";
                Console.Write("Correo: "); string correo = Console.ReadLine() ?? "";

                var c = new Cliente(nombre, a1, a2, tel, correo);
                gestorClientes.RegistrarCliente(c);
                Console.WriteLine($"Cliente creado con ID: {c.IdCliente}");
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error: {ex.Message}");
                }
            Pausa();
            }

        // ===================== EMPLEADOS =====================
        private void MenuEmpleados()
            {
            int op = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE EMPLEADOS ===");
                Console.WriteLine("1. Mostrar empleados");
                Console.WriteLine("2. Agregar empleado");
                Console.WriteLine("3. Volver");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out op)) continue;

                switch (op)
                    {
                    case 1:
                        gestorEmpleados.MostrarEmpleados(); // versión interna (puede mostrar salario)
                        Pausa();
                        break;
                    case 2: RegistrarEmpleado(); break;
                    }
                } while (op != 3);
            }

        private void RegistrarEmpleado()
            {
            try
                {
                Console.Clear();
                Console.WriteLine("=== NUEVO EMPLEADO ===");
                Console.Write("Nombre: "); string n = Console.ReadLine() ?? "";
                Console.Write("Primer apellido: "); string a1 = Console.ReadLine() ?? "";
                Console.Write("Segundo apellido: "); string a2 = Console.ReadLine() ?? "";
                Console.Write("Teléfono: "); string t = Console.ReadLine() ?? "";
                Console.Write("Correo: "); string c = Console.ReadLine() ?? "";
                Console.Write("Salario: "); double salario = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Puesto (0=Barbero,1=Estilista,2=Asistente,3=Administrativo): ");
                int p = int.Parse(Console.ReadLine() ?? "0");

                var emp = new Empleado(n, a1, a2, t, c, (Empleado.PuestoEmpleado)p, salario);
                gestorEmpleados.AgregarEmpleado(emp);
                Console.WriteLine($"Empleado creado con ID: {emp.IdEmpleado}");
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error: {ex.Message}");
                }
            Pausa();
            }

        // ===================== SERVICIOS =====================
        private void MenuServicios()
            {
            int op = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE SERVICIOS ===");
                Console.WriteLine("1. Mostrar servicios");
                Console.WriteLine("2. Agregar servicio");
                Console.WriteLine("3. Modificar servicio");
                Console.WriteLine("4. Eliminar servicio");
                Console.WriteLine("5. Restaurar base");
                Console.WriteLine("6. Volver");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out op)) continue;

                switch (op)
                    {
                    case 1:
                        gestorServicios.MostrarServicios();
                        Pausa();
                        break;
                    case 2: RegistrarServicio(); break;
                    case 3: ModificarServicio(); break;
                    case 4: EliminarServicio(); break;
                    case 5:
                        gestorServicios.InicializarServiciosBase();
                        Pausa();
                        break;
                    }
                } while (op != 6);
            }

        private void RegistrarServicio()
            {
            Console.Clear();
            Console.WriteLine("=== NUEVO SERVICIO ===");
            Console.Write("Nombre: "); string n = Console.ReadLine() ?? "";
            Console.Write("Precio: "); double precio = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Tipo (0=Barbero,1=Estilista,2=Asistente,3=Administrativo): ");
            int t = int.Parse(Console.ReadLine() ?? "0");

            var s = new Servicio(n, precio, (Empleado.PuestoEmpleado)t);
            gestorServicios.AgregarServicio(s);
            Console.WriteLine($"Servicio creado con ID: {s.IdServicio}");
            Pausa();
            }

        private void ModificarServicio()
            {
            Console.Write("ID del servicio a modificar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            Console.Write("Nuevo nombre: "); string n = Console.ReadLine() ?? "";
            Console.Write("Nuevo precio: "); double p = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nuevo tipo (0=Barbero,1=Estilista,2=Asistente,3=Administrativo): ");
            int t = int.Parse(Console.ReadLine() ?? "0");

            gestorServicios.ModificarServicio(id, n, p, (Empleado.PuestoEmpleado)t);
            Pausa();
            }

        private void EliminarServicio()
            {
            Console.Write("ID del servicio a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) return;

            gestorServicios.EliminarServicio(id);
            Pausa();
            }

        // ===================== CITAS =====================
        private void MenuCitas()
            {
            int op = 0;
            do
                {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE CITAS ===");
                Console.WriteLine("1. Agendar nueva cita");
                Console.WriteLine("2. Mostrar todas las citas");
                Console.WriteLine("3. Buscar cita por fecha");
                Console.WriteLine("4. Cancelar cita");
                Console.WriteLine("5. Confirmar cita");
                Console.WriteLine("6. Volver");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out op)) continue;

                switch (op)
                    {
                    case 1: AgendarCita(); break;
                    case 2:
                        gestorCitas.MostrarTodas();
                        Pausa();
                        break;
                    case 3:
                        Console.Write("Fecha (yyyy-MM-dd): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime f))
                            gestorCitas.BuscarPorFecha(f);
                        Pausa();
                        break;
                    case 4:
                        Console.Write("ID cita a cancelar: ");
                        if (int.TryParse(Console.ReadLine(), out int idC)) gestorCitas.CancelarCita(idC);
                        Pausa();
                        break;
                    case 5:
                        Console.Write("ID cita a confirmar: ");
                        if (int.TryParse(Console.ReadLine(), out int idF)) gestorCitas.ConfirmarCita(idF);
                        Pausa();
                        break;
                    }
                } while (op != 6);
            }

        private void AgendarCita()
            {
            try
                {
                Console.Clear();
                Console.WriteLine("=== AGENDAR NUEVA CITA ===");

                // 1) Cliente
                Console.Write("Nombre cliente: "); string cn = Console.ReadLine() ?? "";
                Console.Write("Primer apellido: "); string ca1 = Console.ReadLine() ?? "";
                Console.Write("Segundo apellido: "); string ca2 = Console.ReadLine() ?? "";
                Console.Write("Teléfono: "); string ctel = Console.ReadLine() ?? "";
                Console.Write("Correo: "); string cem = Console.ReadLine() ?? "";
                var cliente = new Cliente(cn, ca1, ca2, ctel, cem);
                gestorClientes.RegistrarCliente(cliente);
                Console.WriteLine($"Cliente ID: {cliente.IdCliente}");
                Pausa();

                // 2) Empleado (vista sin salarios)
                Console.Clear();
                Console.WriteLine("Seleccione empleado:");
                gestorEmpleados.MostrarEmpleadosParaCita();
                Console.Write("ID empleado: ");
                if (!int.TryParse(Console.ReadLine(), out int idEmp))
                    {
                    Console.WriteLine("Empleado inválido.");
                    Pausa();
                    return;
                    }
                var empleado = gestorEmpleados.BuscarPorId(idEmp);
                if (empleado == null)
                    {
                    Console.WriteLine("Empleado no encontrado.");
                    Pausa();
                    return;
                    }

                // 3) Servicio
                Console.Clear();
                Console.WriteLine("Seleccione servicio:");
                gestorServicios.MostrarServicios();
                Console.Write("ID servicio: ");
                if (!int.TryParse(Console.ReadLine(), out int idServ))
                    {
                    Console.WriteLine("Servicio inválido.");
                    Pausa();
                    return;
                    }
                var servicio = gestorServicios.BuscarServicioPorId(idServ);
                if (servicio == null)
                    {
                    Console.WriteLine("Servicio no encontrado.");
                    Pausa();
                    return;
                    }

                // 4) Día disponible (7 días a 3 meses, sin domingos)
                Console.Clear();
                gestorHorarios.MostrarDiasDisponibles();
                Console.Write("\nSeleccione número de día: ");
                if (!int.TryParse(Console.ReadLine(), out int idxDia))
                    {
                    Console.WriteLine("Selección inválida.");
                    Pausa();
                    return;
                    }
                var dias = gestorHorarios.ObtenerDiasDisponibles();
                if (idxDia < 1 || idxDia > dias.Count)
                    {
                    Console.WriteLine("Día inválido.");
                    Pausa();
                    return;
                    }
                var diaSeleccionado = dias[idxDia - 1];

                // 5) Hora disponible para ese día y empleado
                Console.Clear();
                var horas = gestorHorarios.ObtenerHorasDisponibles(diaSeleccionado, empleado);
                if (horas.Count == 0)
                    {
                    Console.WriteLine("No hay horas disponibles para ese día.");
                    Pausa();
                    return;
                    }
                gestorHorarios.MostrarHorasDisponibles(horas);
                Console.Write("\nSeleccione número de hora: ");
                if (!int.TryParse(Console.ReadLine(), out int idxHora))
                    {
                    Console.WriteLine("Selección inválida.");
                    Pausa();
                    return;
                    }
                var slot = gestorHorarios.ReservarPorIndice(idxHora);
                if (slot == null)
                    {
                    Console.WriteLine("No se pudo reservar el horario.");
                    Pausa();
                    return;
                    }

                // 6) Crear cita
                var cita = new Cita(cliente, empleado, servicio, slot.Inicio);
                gestorCitas.AgregarCita(cita);
                Console.WriteLine($"\nCita creada: ID {cita.IdCita} | {slot.Inicio:dddd dd/MM/yyyy HH:mm}");
                Pausa();
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error: {ex.Message}");
                Pausa();
                }
            }

        // Utilidad
        private void Pausa()
            {
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            }
        }
    }
