# Prototipo2 (WinForms + SQLite)

Proyecto de ejemplo para gestión de una librería básica hecho en .NET Framework 4.7.2 con Windows Forms y SQLite.

Caracteristicas:
- Inicio de sesión con usuario Administrador y hash de contraseñas.
- CRUD de libros (guardar, buscar, modificar, eliminar).
- Ventas con carrito, actualización de stock y tablas de detalle.
- Corte de caja diario simple por usuario.
- Catálogo de usuarios (crear, modificar con o sin cambio de clave, eliminar).

Requisitos:
- Visual Studio 2022 o superior.
- .NET Framework 4.7.2 targeting pack.
- Paquetes NuGet: System.Data.SQLite, System.Data.SQLite.Core, FontAwesome.Sharp, y dependencias descritas en `packages.config`.

Configuración de Base de Datos:
- La app usa un archivo SQLite `prototipo2.db` en la carpeta de salida (por defecto).
- La cadena de conexión se lee de `App.config` (clave `Prototipo2`). Si falta, se crea una por defecto.
- En el primer arranque, si no existe el archivo, se crea con el esquema mínimo.
- En `Program.cs` se ejecuta `BookSeeder.Seed` para insertar libros de ejemplo si faltan.

Ejecución:
1) Abrir la solución `Prototipo2.sln`.
2) Restaurar paquetes NuGet (VS lo hace en la primera compilación o desde `Project > Manage NuGet Packages`).
3) Compilar y ejecutar el proyecto `Prototipo2`.
4) Iniciar sesión con:
   - Usuario: Administrador
   - Clave: Admin1
   La primera vez, si el admin no existe, se crea automáticamente.

Estructura principal:
- `backend/data/AyudanteBD.cs`: Inicializa la cadena de conexión, crea archivo DB y esquema si falta.
- `backend/data/BookSeeder.cs`: Siembra libros de ejemplo.
- `backend/PasswordHelper.cs`: Hash/Verificación de contraseñas con SHA-256 y salt simple.
- `VentanaInicio`: Login y migración de contraseñas texto->hash si detecta formato antiguo.
- `VentanaMenu`: Menú principal y navegación a pantallas.
- `VentanaGuardar`: Alta de libros.
- `VentanaBuscar`: Búsqueda de libros.
- `VentanaModificar`: Edición de libros existentes.
- `VentanaEliminar`: Eliminación de libros.
- `VentanaVentas`: Carrito y registro de venta, detalle y ventas_full (para reporteo simple).
- `VentanaCorte`: Resumen de ventas del día para el usuario logueado.
- `VentanaUsuarios`: Catálogo de usuarios, con hash de clave.

Notas para principiantes:
- Hay varios `try/catch` simples (con apenas comentarios) para evitar que la app se caiga. Es preferible un manejo de errores más específico y registro a archivo (logging).
- Se usan consultas parametrizadas para evitar inyecciones SQL.
- `PasswordHelper` usa un salt aleatorio por usuario y SHA-256. Para producción se recomienda un algoritmo de derivación (PBKDF2, bcrypt, scrypt o Argon2) y políticas de complejidad.
- `ventas_full` es una tabla denormalizada útil para reportes rápidos.

Buenas prácticas (pendientes / sugeridas):
- Centralizar manejo de errores y logs (Serilog, NLog).
- Mover reglas de validación a una capa de dominio.
- Tests unitarios de PasswordHelper y operaciones CRUD críticas.
- Mejorar UI/UX (validaciones en vivo, mensajes, etc.).

Licencia:
- MIT (ajusta según sea necesario).
