# SmartTask API

SmartTask API es una aplicación backend desarrollada con ASP.NET Core Web API orientada a la gestión inteligente de tareas.

El sistema permite autenticación segura mediante JWT, manejo de tareas por usuario, cálculo automático de prioridades y persistencia de datos utilizando SQL Server y Entity Framework Core.

---

# Características

- Autenticación con JWT
- Refresh Tokens
- Encriptación de contraseñas con BCrypt
- Gestión de tareas por usuario
- Priorización automática de tareas
- Arquitectura en capas
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
- Dependency Injection
- Async/Await

---

# Tecnologías Utilizadas

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- JWT Authentication
- BCrypt.Net
- Swagger / OpenAPI

---

# Arquitectura del Proyecto

El proyecto implementa una arquitectura en capas para mantener separación de responsabilidades.

```text
Controllers/
Services/
DTOs/
Models/
Data/
Helpers/
```

## Controllers
Manejan solicitudes HTTP y respuestas.

## Services
Contienen la lógica de negocio.

## DTOs
Controlan los datos enviados y recibidos por la API.

## Models
Representan entidades de base de datos.

## Data
Configuración y contexto de Entity Framework Core.

## Helpers
Contienen lógica reutilizable del sistema.

---

# Funcionalidades Principales

## Autenticación

- Registro de usuarios
- Inicio de sesión
- JWT Authentication
- Refresh Tokens
- Revocación de tokens

## Gestión de Tareas

- Crear tareas
- Obtener tareas del usuario autenticado
- Actualizar tareas
- Eliminar tareas
- Prioridad automática

---

# Prioridad Automática

La prioridad de las tareas se calcula automáticamente según la fecha de vencimiento.

| Días restantes | Prioridad |
|---|---|
| 1 día o menos | High |
| Hasta 3 días | Medium |
| Más de 3 días | Low |

---

# Seguridad

El proyecto implementa:

- JWT Bearer Authentication
- BCrypt para hashing de contraseñas
- Endpoints protegidos con `[Authorize]`
- Claims para identificación de usuarios
- Refresh Tokens

---

# Base de Datos

El sistema utiliza SQL Server junto con Entity Framework Core bajo el enfoque Code First.

Las migraciones permiten mantener sincronizada la estructura de la base de datos con el código.

---

# Configuración del Proyecto

## 1. Clonar repositorio

```bash
git clone <repository-url>
```

---

## 2. Restaurar paquetes

```bash
dotnet restore
```

---

## 3. Configurar Connection String

Editar `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SmartTaskDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 4. Configurar JWT

```json
"Jwt": {
  "Key": "smarttask_super_secret_key_2026_ultra_secure",
  "Issuer": "SmartTaskAPI",
  "Audience": "SmartTaskUsers"
}
```

---

## 5. Ejecutar migraciones

```powershell
Update-Database
```

---

## 6. Ejecutar aplicación

```bash
dotnet run
```

---

# Swagger

Swagger se encuentra disponible en:

```text
https://localhost:<port>/swagger
```

La documentación permite probar endpoints protegidos mediante JWT utilizando el botón:

```text
Authorize
```

---

# Endpoints Principales

## Auth

| Método | Endpoint |
|---|---|
| POST | /api/auth/register |
| POST | /api/auth/login |
| POST | /api/auth/refresh |
| POST | /api/auth/logout |

---

## Tasks

| Método | Endpoint |
|---|---|
| GET | /api/tasks |
| GET | /api/tasks/{id} |
| POST | /api/tasks |
| PUT | /api/tasks/{id} |
| DELETE | /api/tasks/{id} |

---

## Users

| Método | Endpoint |
|---|---|
| GET | /api/user/me |

---

# Flujo de Autenticación

1. Usuario se registra
2. Usuario inicia sesión
3. Backend genera JWT y Refresh Token
4. Cliente envía JWT en requests protegidos
5. ASP.NET Core valida el token automáticamente

---

# Posibles Mejoras Futuras

- Roles y permisos
- Frontend con React
- Docker
- Logging
- Tests automatizados
- Notificaciones
- Recuperación de contraseña
- Deploy en la nube

---

# Integrantes

- Diego Enrique Arguera Canjura
- Integrantes del grupo

---

# Licencia

Proyecto académico desarrollado con fines educativos.
