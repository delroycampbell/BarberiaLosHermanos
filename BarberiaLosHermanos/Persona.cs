using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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
            set => nombre = value;
            }

        public string Apellido1
            {
            get => apellido1;
            set => apellido1 = value;
            }

        public string Apellido2
            {
            get => apellido2;
            set => apellido2 = value;
            }

        public string Telefono
            {
            get => telefono;
            set
                {
                if (ValidarTelefono(value))
                    telefono = value;
                else
                    throw new ArgumentException("Teléfono inválido.");
                }
            }

        public string Correo
            {
            get => correo;
            set
                {
                if (ValidarCorreo(value))
                    correo = value;
                else
                    throw new ArgumentException("Correo electrónico inválido.");
                }
            }

        // Constructores
        public Persona() { }

        public Persona(string nombre, string apellido1, string apellido2, string telefono, string correo)
            {
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;
            this.Telefono = telefono; // valida formato
            this.Correo = correo;     // valida formato
            }

        // Método abstracto (obligatorio en subclases)
        public abstract string MostrarDatos();

        // Método general de texto
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

            // Permitir solo números y longitud razonable
            return telefono.All(char.IsDigit) && telefono.Length >= 8 && telefono.Length <= 15;
            }
        }
    }

