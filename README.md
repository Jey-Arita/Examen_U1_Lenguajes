# API de Gestión de Solicitudes de Permisos Laborales

Esta API REST está diseñada para gestionar las solicitudes de permisos laborales en una empresa. Desarrollada con C#, .NET y SQL Server, la API permite a los empleados enviar solicitudes de permiso y a Administradores gestionar y revisar dichas solicitudes. El sistema utiliza ASP.NET Identity para implementar la autenticación y autorización, asegurando que solo los roles adecuados puedan acceder a determinadas funciones. 

### Características principales 📋

CRUD para la gestión de empleados.
- Creación y visualización de solicitudes de permisos por parte de los empleados.
- Aprobación o rechazo de solicitudes por Administrador.
- Protección de endpoints mediante roles ("Empleado", "Administrador").

### Requerimientos previos 🔧

1. .NET 8 (o la versión compatible que estés usando).
2. SQL Server.
3. Herramienta para gestionar bases de datos como SQL Server Management Studio (SSMS).
4. Tener los paquetes instalados visto en clases.


## Pasos para la instalación ⚙️

1. Aplica las respetivas migraciones
2. Crea una nueva base de datos en SQL Server.
3. Actualiza el archivo appsettings.json con tu cadena de conexión.

### Roles y Autorización 🔩

_Solicitudes de Permiso_

```
POST: Crear una nueva solicitud de permiso (Acceso: Empleado).
```
```
GET: Ver todas las solicitudes de un empleado (Acceso: Empleado, Administrador).
```
```
GET: Ver todas las solicitudes (Acceso: Administrador).
```
```
PUT: Aprobar una solicitud (Acceso: Recursos Humanos).
```
```
DELETE: Aprobar una solicitud (Acceso: Recursos Humanos).
```

## Autores ✒️

* **Yeison Arita** - *Trabajo Inicial* 
* **Michael Galdamez** - *Trabajo Inicial*

