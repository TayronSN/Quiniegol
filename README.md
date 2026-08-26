# Quiniegol — Web (Blazor Server)

Sistema corporativo de quinielas de fútbol desarrollado en C# con Blazor Server, siguiendo la arquitectura MVC y almacenamiento dual (SQLite + JSON).

---

## Integrantes

- Tayron Salas Núñez

---

## Tecnologías

- C# / .NET 10
- Blazor Server (renderizado interactivo en servidor)
- Entity Framework Core 10 + SQLite
- JSON (respaldo de datos)
- MSTest (pruebas unitarias)
- Git / GitHub

---

## Arquitectura

El proyecto está dividido en tres carpetas principales:

```
Quiniegol-v2/
├── Quiniegol.Core/       ← Lógica del negocio (Models, Controllers, Data, Utils)
├── Quiniegol.Web/        ← Interfaz web Blazor (páginas, layout, Program.cs)
└── Quiniegol.Tests/      ← Pruebas unitarias con MSTest
```

### Patrón MVC adaptado a Blazor

| Capa        | Ubicación                        | Responsabilidad                                    |
|-------------|----------------------------------|----------------------------------------------------|
| Model       | `Quiniegol.Core/Models/`         | Clases de datos (Usuario, Partido, Pronostico …)   |
| Controller  | `Quiniegol.Core/Controllers/`    | Reglas de negocio y validaciones                   |
| View        | `Quiniegol.Web/Components/Pages/`| Páginas Razor que muestran y reciben datos         |
| Data        | `Quiniegol.Core/Data/`           | Acceso a SQLite (EF Core) y lectura/escritura JSON |

---

## Modelos

| Clase              | Descripción                                                  |
|--------------------|--------------------------------------------------------------|
| `Usuario`          | Empleado registrado. Tiene ID, nombre, correo, contraseña y rol (1 = Admin, 2 = Usuario). |
| `Partido`          | Partido del torneo. Tiene equipos, fase, estado y resultado. |
| `Pronostico`       | Apuesta de un empleado sobre el resultado de un partido.     |
| `Equipo`           | Equipo participante con nombre, grupo y ruta de bandera.     |
| `Ranking`          | Posición de un empleado (ID + puntos acumulados).            |
| `Insignia`         | Logro desbloqueado por el usuario (nombre + condición).      |
| `UsuarioEstadistica` | Agrupa pronósticos y aciertos de un usuario para reportes. |

---

## Controladores

| Controlador              | Métodos principales                                                         |
|--------------------------|-----------------------------------------------------------------------------|
| `UsuarioController`      | `RegistrarUsuario`, `IniciarSesion`, `ObtenerUsuario`, `CambiarPassword`, `EliminarUsuario` |
| `PartidoController`      | `RegistrarPartido`, `ActualizarPartido`, `EliminarPartido`                  |
| `PronosticoController`   | `RegistrarPronostico`, `ActualizarPronostico`, `EliminarPronostico`         |
| `RankingController`      | `GenerarRanking` — 5 puntos por cada acierto, ordenado de mayor a menor    |
| `EstadisticasController` | Estadísticas globales (admin) y personales (usuario), más insignias        |

---

## Capa de datos

Cada clase en `Data/` combina SQLite con un archivo JSON de respaldo:

- **SQLite** es la base de datos principal (se crea automáticamente en `bin/Debug/net10.0/quiniegol.db`).
- **JSON** actúa como respaldo: se lee al iniciar la app para poblar SQLite, y se actualiza cada vez que se realiza un cambio.

| Clase             | Archivo JSON         |
|-------------------|----------------------|
| `UsuariosData`    | `Data/usuarios.json` |
| `PartidosData`    | `Data/partidos.json` |
| `PronosticosData` | `Data/pronosticos.json` |
| `EquiposData`     | Hardcodeado en código (48 equipos, 12 grupos) |
| `AppDbContext`    | Contexto de Entity Framework Core; define las 4 tablas |

> **Importante:** si se modifican los archivos JSON con nuevos datos, se debe borrar `quiniegol.db` antes de volver a ejecutar la aplicación para que EF Core lo reconstruya desde el JSON.

---

## Sesión de usuario

| Clase          | Tipo     | Usado en        | Descripción                                                                 |
|----------------|----------|-----------------|-----------------------------------------------------------------------------|
| `SesionService`| `Scoped` | Blazor (todas las páginas) | Servicio inyectado por DI. Cada conexión tiene su propia instancia, evitando que dos usuarios compartan sesión. Expone el evento `OnCambio` para que `NavMenu` y las páginas se actualicen automáticamente al iniciar o cerrar sesión. |

---

## Funcionalidades

### Login
- Inicio de sesión por ID de empleado y contraseña.
- Validación de credenciales con mensajes de error en pantalla.
- Redirección automática según el rol (admin → `/principal`, usuario → `/principal-usuario`).

### Registro
- Registro de nuevos usuarios con validación de correo, contraseña y datos obligatorios.
- La contraseña solo puede contener letras y debe tener al menos 5 caracteres.
- No se permiten IDs ni correos duplicados.

### Administración de partidos (admin)
- Registrar, editar y eliminar partidos.
- Registrar el resultado → el partido pasa automáticamente a estado "Cerrado".
- Si se borra el resultado → el partido vuelve a "Abierto".

### Administración de usuarios (admin)
- Ver todos los usuarios registrados.
- Cambiar la contraseña de cualquier usuario.
- Eliminar usuarios (no se permite eliminar administradores).

### Pronósticos (usuario)
- Solo se pueden apostar partidos con estado "Abierto".
- El dropdown muestra únicamente los partidos abiertos en los que el usuario aún no ha apostado.
- Cada empleado puede hacer un único pronóstico por partido.
- Opciones: Local, Empate, Visitante.

### Ranking
- Se calculan 5 puntos por cada pronóstico acertado.
- Solo se consideran partidos con estado "Cerrado" y con resultado registrado.
- Ordenado de mayor a menor puntuación.

### Estadísticas (admin)
- Resultado más repetido en partidos cerrados.
- Partido con más aciertos.
- Usuarios con más aciertos (tabla completa y top 5).
- Partidos con más pronósticos recibidos.
- Partidos cerrados donde ningún usuario acertó.
- Equipo sorpresa (ganó siendo el menos votado).

### Estadísticas (usuario)
- Equipo al que más le apostó a ganar.
- Total de pronósticos realizados.
- Total de aciertos.
- Porcentaje de aciertos.
- Insignias desbloqueadas.

### Insignias
| Nombre               | Condición                              |
|----------------------|----------------------------------------|
| Participante         | Al menos 1 pronóstico registrado       |
| Primer acierto       | Al menos 1 acierto                     |
| Buen pronosticador   | Al menos 5 aciertos                    |
| Experto              | Al menos 10 aciertos                   |

---

## Roles

### Administrador (IdRol = 1)
- Credenciales predeterminadas: ID `12345`, contraseña `tayron`
- Accede a: Principal (estadísticas globales), Partidos, Usuarios, Pronósticos, Ranking.

### Usuario normal (IdRol = 2)
- Accede a: Principal (estadísticas personales + insignias), Pronósticos, Ranking.

---

## Páginas Blazor

| Ruta                | Página                | Rol          |
|---------------------|-----------------------|--------------|
| `/` o `/login`      | `Login.razor`         | Público      |
| `/registro`         | `Registro.razor`      | Público      |
| `/logout`           | `Logout.razor`        | Autenticado  |
| `/principal`        | `Principal.razor`     | Admin        |
| `/partidos`         | `Partidos.razor`      | Admin        |
| `/usuarios`         | `Usuarios.razor`      | Admin        |
| `/principal-usuario`| `PrincipalUsuario.razor` | Usuario   |
| `/pronosticos`      | `Pronosticos.razor`   | Usuario/Admin|
| `/ranking`          | `Ranking.razor`       | Ambos        |

---

## Pruebas unitarias

24 pruebas con MSTest, organizadas en 3 clases. Todas pasan (0 errores).

| Archivo                      | Tests | Qué cubre                                              |
|------------------------------|-------|--------------------------------------------------------|
| `UsuarioControllerTest.cs`   | 13    | `RegistrarUsuario`, `IniciarSesion`, `CambiarPassword` |
| `PartidoControllerTest.cs`   | 6     | `RegistrarPartido`, `ActualizarPartido`                |
| `PronosticoControllerTest.cs`| 6     | `RegistrarPronostico` — campos obligatorios y resultado inválido |

Las pruebas únicamente prueban las validaciones de los controladores, sin depender de la base de datos.

---

## Persistencia

```
Quiniegol.Core/Data/
├── usuarios.json       ← 40 usuarios
├── partidos.json       ← 40 partidos (IDs 1-30 Cerrado, IDs 31-40 Abierto)
├── pronosticos.json    ← 1 365 pronósticos
└── equipos.json        ← 48 equipos (12 grupos de 4)
```

---

## Estructura del proyecto

```
Quiniegol-v2/
├── Quiniegol.Core/
│   ├── Controllers/
│   │   ├── UsuarioController.cs
│   │   ├── PartidoController.cs
│   │   ├── PronosticoController.cs
│   │   ├── RankingController.cs
│   │   └── EstadisticasController.cs
│   ├── Data/
│   │   ├── AppDbContext.cs
│   │   ├── UsuariosData.cs
│   │   ├── PartidosData.cs
│   │   ├── PronosticosData.cs
│   │   ├── EquiposData.cs
│   │   ├── usuarios.json
│   │   ├── partidos.json
│   │   ├── pronosticos.json
│   │   └── equipos.json
│   ├── Models/
│   │   ├── Usuario.cs
│   │   ├── Partido.cs
│   │   ├── Pronostico.cs
│   │   ├── Equipo.cs
│   │   ├── Ranking.cs
│   │   ├── Insignia.cs
│   │   └── UsuarioEstadistica.cs
│   ├── Utils/
│   │   └── SesionService.cs   ← sesión activa en Blazor (Scoped)
│   └── Quiniegol.Core.csproj
├── Quiniegol.Web/
│   ├── Program.cs
│   ├── Components/
│   │   ├── Layout/
│   │   │   ├── MainLayout.razor
│   │   │   └── NavMenu.razor
│   │   └── Pages/
│   │       ├── Login.razor
│   │       ├── Logout.razor
│   │       ├── Registro.razor
│   │       ├── Principal.razor
│   │       ├── PrincipalUsuario.razor
│   │       ├── Partidos.razor
│   │       ├── Usuarios.razor
│   │       ├── Pronosticos.razor
│   │       └── Ranking.razor
│   └── Quiniegol.Web.csproj
└── Quiniegol.Tests/
    ├── UsuarioControllerTest.cs
    ├── PartidoControllerTest.cs
    ├── PronosticoControllerTest.cs
    └── Quiniegol.Tests.csproj
```

---

## Ejecución

### Requisitos
- .NET 10 SDK instalado

### Ejecutar la aplicación web

```powershell
$env:PATH = "C:\Program Files\dotnet;" + $env:PATH
dotnet run --project "Quiniegol.Web\Quiniegol.Web.csproj"
```

Acceder desde el navegador en: `https://localhost:7282` o `http://localhost:5129`

### Ejecutar las pruebas

```powershell
$env:PATH = "C:\Program Files\dotnet;" + $env:PATH
dotnet test "Quiniegol.Tests\Quiniegol.Tests.csproj"
```

> Si se modifican los archivos JSON, borrar `Quiniegol.Web\bin\Debug\net10.0\quiniegol.db` antes de volver a ejecutar.
