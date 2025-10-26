using System;
using System.Linq;
using System.Net.Mail;

namespace BarberiaLosHermanos
    {
    public abstract class Persona
        {
        // Atributos privados
        private string nombre;
        private string apellido1;
        private string apellido2;
        private string telefono;
        private string correo;

        // Propiedades públicas
        public string Nombre
            {
            get => nombre;
            set
                {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value.Trim();
                }
            }

        public string Apellido1
            {
            get => apellido1;
            set
                {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El primer apellido no puede estar vacío.");
                apellido1 = value.Trim();
                }
            }

        public string Apellido2
            {
            get => apellido2;
            set => apellido2 = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
            }

        public string Telefono
            {
            get => telefono;
            set
                {
                if (!ValidarTelefono(value))
                    throw new ArgumentException("Teléfono inválido. Debe contener solo números y tener entre 8 y 15 dígitos.");
                telefono = value.Trim();
                }
            }

        public string Correo
            {
            get => correo;
            set
                {
                if (!ValidarCorreo(value))
                    throw new ArgumentException("Correo electrónico inválido.");
                correo = value.Trim();
                }
            }

        // Constructores
        public Persona() { }

        public Persona(string nombre, string apellido1, string apellido2, string telefono, string correo)
            {
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Telefono = telefono; // valida formato
            Correo = correo;     // valida formato
            }

        // Método abstracto (debe implementarse en subclases)
        public abstract string MostrarDatos();

        // Representación textual genérica
        public override string ToString()
            {
            return $"{nombre} {apellido1} {apellido2}, Tel: {telefono}, Correo: {correo}";
            }

        // Validación de correo
        protected static bool ValidarCorreo(string correo)
            {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            try
                {
                var addr = new MailAddress(correo);
                return addr.Address == correo;
                }
            catch
                {
                return false;
                }
            }

        // Validación de teléfono
        protected static bool ValidarTelefono(string telefono)
            {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            // Solo dígitos y longitud razonable
            return telefono.All(char.IsDigit) && telefono.Length >= 8 && telefono.Length <= 15;
            }
        }
    }
