namespace BarberiaLosHermanos
    {
    public class Servicio
        {
        // Atributos
        private int idServicio;
        private string nombreServicio;
        private double precio;
        private string descripcion;

        // Propiedades
        public int IdServicio
            {
            get => idServicio;
            set
                {
                if (ValidarIdServicio(value))
                    idServicio = value;
                else
                    throw new ArgumentException("ID de servicio inválido.");
                }
            }
        public string NombreServicio
            {
            get => nombreServicio;
            set
                {
                if (ValidarNombreServicio(value))
                    nombreServicio = value;
                else
                    throw new ArgumentException("Nombre de servicio inválido.");
                }
            }
        public double Precio
            {
            get => precio;
            set
                {
                if (ValidarPrecio(value))
                    precio = value;
                else
                    throw new ArgumentException("Precio inválido.");
                }
            }
        public string Descripcion
            {
            get => descripcion;
            set
                {
                if (ValidarDescripcion(value))
                    descripcion = value;
                else
                    throw new ArgumentException("Descripción inválida.");
                }
            }

        // Constructor
        public Servicio(int idServicio, string nombreServicio, double precio, string descripcion)
            {
            this.IdServicio = idServicio;
            this.NombreServicio = nombreServicio;
            this.Precio = precio;
            this.Descripcion = descripcion;
            }
        // Método para mostrar información del servicio
        public override string ToString()
            {
            return $"ID Servicio: {idServicio}, Nombre: {nombreServicio}, Precio: {precio:C}, Descripción: {descripcion}";
            }
        public void MostrarServicio()
            {
            Console.WriteLine(this);
            }

        //Metodos para validar datos si es necesario

        private protected bool ValidarPrecio(double precio)
            {
            return precio >= 0;
            }

        private protected bool ValidarNombreServicio(string nombreServicio)
            {
            return !string.IsNullOrWhiteSpace(nombreServicio);
            }

        private protected bool ValidarDescripcion(string descripcion)
            {
            return !string.IsNullOrWhiteSpace(descripcion);
            }

        private protected bool ValidarIdServicio(int idServicio)
            {
            return idServicio > 0;
            }
        }// fin de la clase Servicio

    }