# Quiniegol

Sistema de gestión de quinielas mundialistas desarrollado en C# Windows Forms utilizando MVC y Programación Orientada a Objetos.





\# Quiniegol



Proyecto desarrollado en C# Windows Forms utilizando el patrón MVC y almacenamiento en archivos JSON.



\## Integrantes



\- Tayron Salas



\## Tecnologías



\- C#

\- Windows Forms

\- .NET

\- JSON

\- Git

\- GitHub



\## Arquitectura



El proyecto está organizado siguiendo una arquitectura MVC adaptada a Windows Forms.



```

Controllers

Data

Forms

Models

Resources

Utils

```



\## Funcionalidades



\### Login



\- Inicio de sesión por ID de empleado.

\- Validación de credenciales.

\- Acceso según el rol del usuario.



\### Registro



\- Registro de nuevos usuarios.

\- Validación de datos.

\- Almacenamiento en `usuarios.json`.



\### Administración de usuarios



\- Consultar usuarios registrados.

\- Eliminar usuarios.

\- Impedir eliminar administradores.

\- Exportar listado de usuarios a archivo `.txt`.



\### Administración de partidos



\- Registrar partidos.

\- Editar partidos.

\- Eliminar partidos.

\- Cambiar estado del partido.

\- Registrar resultado.



\### Pronósticos



\- Registrar pronósticos.

\- Un usuario solo puede pronosticar partidos abiertos.

\- Cada usuario únicamente visualiza sus propios pronósticos.



\### Ranking



\- Cálculo automático de puntos.

\- Ordenamiento de mayor a menor puntuación.

\- Exportación del ranking a archivo `.txt`.



\## Persistencia



La información se almacena en archivos JSON.



```

Data/

│

├── usuarios.json

├── equipos.json

├── partidos.json

└── pronosticos.json

```



\## Roles



\### Administrador



\- Administrar usuarios.

\- Administrar partidos.

\- Consultar pronósticos.

\- Consultar ranking.



\### Usuario



\- Registrar pronósticos.

\- Consultar ranking.



\## Estructura del proyecto



```

Quiniegol

│

├── Controllers

├── Data

├── Forms

├── Models

├── Resources

├── Utils

└── Data

```



\## Ejecución



1\. Clonar el repositorio.

2\. Abrir la solución en Visual Studio.

3\. Restaurar dependencias.

4\. Ejecutar el proyecto.



\## Repositorio



Repositorio GitHub del proyecto Quiniegol.



\## Últimas mejoras



\- Implementación de roles (Administrador y Usuario).

\- Menús independientes según el rol.

\- Administración de usuarios.

\- Eliminación de usuarios con restricción para administradores.

\- Exportación de usuarios a TXT.

\- Exportación del ranking a TXT.

\- Mejoras en la navegación entre formularios.

\- Persistencia mediante archivos JSON.

