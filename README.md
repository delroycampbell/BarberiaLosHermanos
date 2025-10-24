# 💈 Barbería Los Hermanos  
**Sistema de Gestión de Clientes, Servicios y Citas (Aplicación de Consola en C#)**  

---

## 🧾 Instrucciones del Examen

1. Leer cuidadosamente toda la prueba antes de comenzar (tiempo máximo: **10 minutos**).  
2. Responder cada pregunta **en orden** y fundamentar cada respuesta.  
3. El examen puede realizarse **individual o en grupo** (máximo 4 integrantes).  
4. Si se utilizan recursos externos (imágenes, diagramas, fragmentos de código, etc.), **citar las fuentes**.  
   - El plagio será sancionado según las normas de la universidad.  
5. Si se realizan **suposiciones**, estas deben estar claramente **indicadas** en las respuestas.  
6. La entrega debe ser en **formato .ZIP** o, alternativamente, el **enlace del repositorio en GitHub**.  
   - Cualquier otro formato no será evaluado (**calificación: 1**).

---

## 🧠 Descripción del Escenario

El dueño de la barbería **“Los Hermanos”** solicita un **sistema de gestión personalizado** para clientes y citas.  
La aplicación debe ejecutarse en **consola**, enfocándose en la **funcionalidad y simplicidad**, sin interfaz gráfica.

**Objetivo principal:**  
> Modernizar la operación del negocio, organizar la agenda y fidelizar clientes mediante una base de datos gestionada.

---

## ⚙️ Requisitos Funcionales

### 1. Gestión de Citas *(50% del puntaje total)*

Funcionalidad crítica del sistema para **registrar y organizar reservas**.

#### 📅 Creación de Citas
- Registrar: nombre completo del cliente, fecha, hora y tipo de servicio (ej. corte, barba, facial, etc.).  
- Validar fecha:  
  - No se permiten fechas **pasadas**.  
  - Solo se pueden agendar citas con **máximo 7 días de anticipación**.  
- Información requerida: nombre, teléfono, correo, tipo de servicio, fecha y hora.

#### 🔍 Consulta de Citas
- Mostrar lista de citas programadas.  
- Permitir **filtrar por día**.

#### ❌ Cancelación de Citas
- Eliminar una cita existente mediante **nombre de cliente** o **ID**.

---

### 2. Control Básico de Clientes *(35% del puntaje total)*

Estructurado mediante **listas, colas o pilas** (no requiere base de datos).

#### ➕ Registro de Clientes
- Añadir nombre, teléfono y correo.  
- Usar esta información para futuras promociones.

#### 🔎 Búsqueda de Clientes
- Buscar por nombre y mostrar datos de contacto.

#### 🧾 Historial de Citas *(opcional)*
- Mostrar citas pasadas o futuras asociadas a un cliente específico.

---

### 3. Gestión de Servicios y Precios *(15% del puntaje total)*

Catálogo simple para estandarizar la oferta y facilitar registros.

#### 💇 Visualización de Servicios
- Mostrar servicios disponibles y su precio (ej. Corte Caballero, Afeitado Clásico).

#### ⚙️ Configuración de Servicios *(opcional)*
- Permitir al administrador **añadir, modificar o eliminar** servicios.

---

## 💻 Interfaz y Operación

**Plataforma:** Aplicación de Consola  
**Interacción:** Menú navegable mediante opciones numéricas  

### Menú Principal

```
1. Gestión de Citas
2. Control de Clientes
3. Servicios y Precios
4. Salir
```
Cada opción conduce a un submenú con sus respectivas funciones (crear, consultar, cancelar, etc.).

---

## 🧩 Conceptos de Programación Aplicados

1. **Programación Orientada a Objetos (POO):** diseño modular y reutilizable.  
2. **Clases y Objetos:** representación de entidades clave (*Cliente, Empleado, Servicio, Cita*).  
3. **Métodos:** acciones como registrar, buscar o eliminar.  
4. **Herencia:** jerarquías compartiendo propiedades comunes (*Persona → Cliente/Empleado*).  
5. **Abstracción:** ocultamiento de detalles mediante clases abstractas.  
6. **Polimorfismo:** comportamiento especializado según el tipo de objeto.  
7. **Encapsulación:** protección de datos mediante modificadores de acceso.  
8. **Ciclos:** recorrido de listas con estructuras `for` y `foreach`.  
9. **Manejo de errores:** uso de `try-catch` para estabilidad del sistema.

---

## 🧠 Suposiciones de Desarrollo
- Se asume que los datos de clientes y servicios se mantienen en memoria durante la ejecución.  
- No se requiere persistencia en archivos ni base de datos.  
- Los precios se expresan en moneda local (CRC).  
- Las citas se gestionan dentro de un rango horario de **9:00 a.m. a 8:00 p.m.**

---

## 🧑‍💻 Autores / Integrantes
| Nombre | Rol | Carné |
|---------|-----|--------|
| Nombre 1 | Programador | ####### |
| Nombre 2 | Tester | ####### |
| Nombre 3 | Diseñador Lógico | ####### |
| Nombre 4 | Documentación | ####### |

---

## 🧾 Citas y Referencias
> Toda información, imagen o fragmento de código externo deberá citarse en formato **APA 7**.  
Ejemplo:
> Microsoft (2023). *C# Documentation*. Retrieved from https://learn.microsoft.com/en-us/dotnet/csharp/

---

## 📦 Entrega
El proyecto debe entregarse como:
- Archivo comprimido `.zip` con todo el código fuente.  
- O enlace público del repositorio **GitHub**.

---

## 🧰 Tecnologías Utilizadas
- **Lenguaje:** C#  
- **Entorno:** .NET 8 / Visual Studio 2022  
- **Paradigma:** Programación Orientada a Objetos  
- **Arquitectura:** Clases modulares con herencia y validaciones

---

## 🧭 Estructura Sugerida del Proyecto

```
BarberiaLosHermanos/
│
├── Program.cs
├── Clases/
│ ├── Persona.cs
│ ├── Cliente.cs
│ ├── Empleado.cs
│ ├── Servicio.cs
│ ├── Cita.cs
│
├── Utils/
│ ├── MenuPrincipal.cs
│ ├── Validaciones.cs
│
└── README.md
```

---

## ⚖️ Licencia
Este proyecto se desarrolla con fines **académicos**.  
No está autorizado su uso comercial sin permiso del autor.

