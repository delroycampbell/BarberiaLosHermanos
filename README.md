Instrucciones: 
1. Leer con cuidado toda la prueba, cuenta con 10 minutos. 
2. Proceda luego a contestar cada pregunta, en el orden en que aparece el presente 
examen. Asegúrese de fundamentar sus respuestas y contestar únicamente lo que se le 
pide. 
3. Este examen se puede realizar individual o en grupo (con la cantidad máxima de 4 
integrantes por examen). 
4. Si utiliza información, imágenes, diagramas, etc, tomados de Internet, libros o algún otro 
recurso, no olvide citar la fuente, de lo contrario será señalado como plagio y se anulará 
el examen según las disposiciones de la universidad. 
5. Para el desarrollo de los casos, de ser necesario puede hacer las suposiciones que 
considere necesarias, sin embargo, debe indicarlas en sus respuestas. 
6. El examen debe entregarse en fomarto ZIP en la Plataforma de la Universidad, o en su 
defecto entregar el link del repositorio en GitHub. Cualquier otro formato o tipo de 
entrega no será tomado en cuenta para la evaluación y se obtendrá de calificación un 1.  
Descripción del Escenario 
El dueño de la barbería "Los Hermanos" requiere el desarrollo de un sistema de gestión 
de clientes y citas a la medida. El sistema debe ser una aplicación de consola para ser 
utilizada directamente en su computadora personal, priorizando la sencillez y la 
funcionalidad sobre una interfaz gráfica compleja. 
1 
El objetivo principal es modernizar la operación, permitiendo una mejor organización de 
la agenda y facilitando la fidelización de clientes a través de la gestión de una base de 
datos. 
Requisitos Funcionales del Sistema 
El sistema debe incluir las siguientes funcionalidades esenciales, accesibles mediante 
un menú de consola: 
1. Gestión de Citas (Función Crítica, este rubro contempla el 50% del puntaje de este examen) 
Esta es la funcionalidad central para organizar y registrar las reservas de servicios. 
● Creación de Citas: 
○ Debe registrar el nombre completo del cliente, la fecha, la hora y el tipo de 
servicio (ej. corte, barba, ambos, facial, etc.). 
○ Debe obligatoriamente validar la fecha: no se permiten agendar citas en 
fechas pasadas. 
○ Debe limitar la anticipación: solo se puede agendar con máximo una 
semana de antelación. 
○ Información de la cita: Nombre, teléfono, correo electrónico, tipo de 
servicio, fecha y hora. 
● Consulta de Citas: 
○ Permitir visualizar una lista clara de todas las citas programadas, con 
opción a filtrar por día. 
● Cancelación de Citas: 
○ Facilitar la eliminación de una reserva existente, idealmente buscando por 
el nombre del cliente o un ID de cita. 
2. Control Básico de Clientes (Esta función equivale al 35% del puntaje de este examen) 
A nivel sistema, esta funcionalidad la pueden operar con una estructura de datos (pila, 
cola, lista, etc) no es necesario que se conecten a una base de datos o algún archivo 
de texto. 
● Registro de Clientes: 
○ Permitir añadir clientes guardando su nombre y datos de contacto 
(teléfono y correo electrónico) para futuros envíos de promociones. 
● Búsqueda de Clientes: 
○ Habilitar la búsqueda por nombre para recuperar rápidamente sus datos 
de contacto. 
2 
● Historial de Citas (Deseable): 
○ Mostrar un registro de las citas pasadas y/o futuras asociadas a un cliente 
específico. 
3. Gestión de Servicios y Precios (Esta función equivale al 15% del puntaje de este examen) 
Un catálogo simple para estandarizar la oferta y facilitar el registro de citas. 
● Visualización de Servicios: 
○ Mostrar una lista predefinida de los servicios ofrecidos (ej., "Corte 
Caballero", "Afeitado Clásico") junto con su precio correspondiente. 
● Configuración de Servicios (Opcional/Administrativo): 
○ Permitir al administrador (el barbero) añadir, modificar o eliminar servicios 
y actualizar sus precios. 
4. Interfaz y Operación 
● Plataforma: Aplicación de Consola. 
● Usabilidad: La navegación debe ser dirigida por menú, fácil de usar mediante 
comandos numéricos. 
Estructura del Menú: 
1. Menú Principal: 
4. Gestión de Citas 
5. Control de Clientes 
6. Servicios y Precios 
7. Salir 
2. Submenús: Cada opción principal debe conducir a sus respectivas 
funcionalidades (Crear, Consultar, Añadir, Buscar, etc.). 
Objetivos del escenario 
Los estudiantes deberán aplicar los siguientes conceptos de programación en C# para 
construir este sistema: 
1. Programación Orientada a Objetos (POO): Los estudiantes deberán organizar 
su código utilizando los principios de POO, promoviendo la reutilización y la 
modularidad. 
2. Clases y Objetos: Los estudiantes crearán clases que representen entidades 
clave como productos, clientes y ventas. 
3 
3. Métodos: Los estudiantes implementarán métodos que permitan realizar 
acciones como registrar citas, clientes, servicios, etc. 
4. Herencia: Se utilizará la herencia para crear una jerarquía de clases que permita 
compartir comportamiento y propiedades comunes. 
5. Abstracción: Los estudiantes deberán abstraer los detalles de implementación y 
definir comportamientos comunes a través de clases abstractas. 
6. Polimorfismo: Se utilizará el polimorfismo para permitir que diferentes tipos de 
productos se comporten de manera específica a través de un método común. 
7. Encapsulación: Los estudiantes aprenderán a proteger los datos de sus clases 
mediante el uso de modificadores de acceso. 
8. Ciclos: Se emplearán ciclos for para iterar sobre colecciones de datos, como 
listas de productos o ventas. 
9. Manejo de errores (try-catch): Los estudiantes implementarán bloques 
try-catch para manejar excepciones y errores de forma elegante, garantizando la 
estabilidad del sistema.
