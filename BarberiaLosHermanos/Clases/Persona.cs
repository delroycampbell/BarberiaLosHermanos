namespace BarberiaLosHermanos.Clases
    {
    public abstract class Persona
        {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public Persona(string nombre, string apellido1, string apellido2, string telefono, string correo)
            {
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Telefono = telefono;
            Correo = correo;
            }

        public abstract void MostrarInfo();
        }
    }
