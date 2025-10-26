namespace BarberiaLosHermanos
    {
    public class Servicio
        {
        // Atributos
        private int idServicio;
        private string nombreServicio;
        private double precio;
        private string descripcion;
        private eCategoriaServicio categoria;

        //enum categoria servicio
        public enum eCategoriaServicio
            {
            Barbero,
            Manicure,
            Masaje,
            Estilista,
            Otros
            }

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

        public eCategoriaServicio Categoria
            {
            get => categoria;
            set
                {
                if (!Enum.IsDefined(typeof(eCategoriaServicio), value))
                    throw new ArgumentException("Categoría de servicio inválida.");
                categoria = value;
                }
            }

        // Constructor
        public Servicio() { }

        public Servicio(int idServicio, string nombreServicio, double precio, string descripcion, eCategoriaServicio categoriaServicio)
            {
            IdServicio = idServicio;
            NombreServicio = nombreServicio;
            Precio = precio;
            Descripcion = descripcion;
            Categoria = categoriaServicio;
            }
        // Método para mostrar información del servicio
        public override string ToString()
            {
            return $"ID Servicio: {idServicio}, Nombre: {nombreServicio}, Precio: {precio:0.00},+ " +
                $"Categoría: {categoria}, $Descripción: {descripcion}";
            }
        public void MostrarServicio()
            {
            Console.WriteLine(this);
            }

        //Metodos para validar datos si es necesario

        private protected bool ValidarPrecio(double precio) => precio >= 0;
        private protected bool ValidarNombreServicio(string nombreServicio) => !string.IsNullOrWhiteSpace(nombreServicio);
        private protected bool ValidarDescripcion(string descripcion) => !string.IsNullOrWhiteSpace(descripcion);
        private protected bool ValidarIdServicio(int idServicio) => idServicio > 0;
        }
    }// fin de la clase Servicio

