<<<<<<< HEAD
# 🚀 MyApi – API RESTful en .NET 8 con Clean Architecture

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Developer-blue?logo=csharp)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red?logo=microsoftsqlserver)
![License](https://img.shields.io/badge/License-MIT-yellow)
![Status](https://img.shields.io/badge/Status-Active-success)

# MyApi

**MyApi** es una API RESTful desarrollada en **.NET 8**, diseñada siguiendo los principios de **Clean Architecture** para lograr un código modular, mantenible y escalable.  
La solución separa claramente las responsabilidades en capas independientes, promoviendo una arquitectura desacoplada y fácil de probar.

---

## 🏗️ Estructura del Proyecto

```bash
MyApi/
├── Core/              → 🧠 Dominio: entidades e interfaces base del negocio
├── Application/       → ⚙️ Aplicación: lógica de negocio y casos de uso
├── Infrastructure/    → 🧩 Infraestructura: persistencia y servicios externos
├── WebApi/            → 🌐 Presentación: controladores y endpoints HTTP
└── Utilities/         → 🧰 Utilidades y funciones auxiliares
```

## 🏗️ Estructura del Proyecto: Detalle por cada capa
```bash
MyApi/
├── Core/                                ← 🧠 Capa de Dominio
│   ├── Entities/                        ← Entidades del dominio (modelos base del negocio)
│   │   └── UnidadMedida.cs              ← Representa una entidad del dominio (por ejemplo, unidad de medida de un producto)
│   ├── Interfaces/                      ← Contratos (abstracciones) del dominio
│   │   └── IPedidosRepository.cs        ← Define qué operaciones deben ofrecer los repositorios, sin implementar nada
│   └── Core.csproj                      ← Proyecto del dominio (sin dependencias a otras capas)
│
├── Application/                         ← ⚙️ Capa de Aplicación
│   ├── DTOs/                            ← Objetos de transferencia de datos (para comunicar entre capas)
│   │   └── UnidadMedidaDto.cs           ← Versión simplificada de la entidad, usada en servicios o controladores
│   ├── Interfaces/                      ← Contratos para los servicios de aplicación
│   │   └── IUnidadMedidaService.cs      ← Define las operaciones de negocio disponibles (por ejemplo, CRUD de unidades)
│   ├── Services/                        ← Implementaciones de los servicios de aplicación
│   │   └── UnidadMedidaService.cs       ← Implementa la lógica de negocio usando los repositorios del dominio
│   ├── DependencyInjection.cs           ← Configuración de inyección de dependencias para registrar servicios en el contenedor
│   └── Application.csproj               ← Proyecto que depende solo del Core (Dominio)
│
├── Infrastructure/                      ← 🧩 Capa de Infraestructura
│   ├── Persistence/                     ← Acceso a datos y persistencia
│   │   ├── SqlServer/                   ← Implementaciones específicas para SQL Server
│   │   │   ├── DatabaseSettings.cs      ← Configuración de conexión a la base de datos
│   │   │   ├── SqlServerConnectionFactory.cs ← Crea conexiones SQL de manera centralizada
│   │   │   └── Repositories/            ← Implementaciones concretas de repositorios
│   │   │       └── PedidosRepository.cs ← Implementa IPedidosRepository, con consultas SQL reales
│   ├── DependencyInjection.cs           ← Registra la infraestructura (repositorios, DbContext, etc.) en el contenedor DI
│   └── Infrastructure.csproj            ← Proyecto que depende de Core y Application
│
├── WebApi/                              ← 🌐 Capa de Presentación (API)
│   ├── Controllers/                     ← Puntos de entrada HTTP (endpoints)
│   │   └── PedidosController.cs         ← Expone las operaciones de pedidos mediante HTTP
│   ├── DTOs/                            ← Modelos específicos para respuestas o peticiones API
│   │   └── ApiResponse.cs               ← Modelo estándar de respuesta (status, mensaje, datos)
│   ├── Middleware/                      ← Middleware personalizados de ASP.NET Core
│   │   └── ExceptionHandlingMiddleware.cs ← Captura y maneja excepciones globalmente
│   ├── appsettings.json                 ← Configuración general de la aplicación (conexiones, claves, etc.)
│   ├── Program.cs                       ← Punto de entrada de la aplicación; configura servicios y middleware
│   └── WebApi.csproj                    ← Proyecto ejecutable, depende de Application e Infrastructure
│
├── Utilities/                           ← 🧰 Capa de utilidades o helpers
│   ├── ErrorUtilities.cs                ← Funciones auxiliares para manejo o formato de errores
│   └── Utilities.csproj                 ← Proyecto de utilidades reutilizable por otras capas
│
└── MyApi.sln                            ← 💼 Solución principal que agrupa todos los proyectos
```

### 🔁 Dependencias entre capas

- **WebApi** depende de **Application**
- **Application** depende de **Core**
- **Infrastructure** implementa interfaces de **Core** y es utilizada por **Application**
- **Utilities** puede ser usada por todas las capas

---

## 🚀 Características Principales

- Arquitectura basada en principios **SOLID**  
- Separación clara de responsabilidades  
- Uso de **Inyección de Dependencias (DI)**  
- Integración con **Entity Framework Core** y **MediatR**  
- Validación de entrada con **FluentValidation**  
- Manejo global de errores y respuestas consistentes  
- Documentación interactiva con **Swagger / OpenAPI**  

---

## ⚙️ Requisitos Previos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) u otro motor compatible
- [Visual Studio 2022](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)

---

## 🧩 Ejecución del Proyecto

1. Clonar el repositorio  
   ```bash
   git clone https://github.com/gilnergarciaambulay/api-rest-net8-clear-aquitectura.git
   cd api-rest-net8-clear-aquitectura
   ```
2. Restaurar dependencias  
   ```bash
   dotnet restore
   ```

3. Aplicar migraciones (si corresponde)  
   ```bash
   dotnet ef database update
   ```

4. Ejecutar la API  
   ```bash
   dotnet run --project api-rest-net8-clear-aquitectura
   ```

5. Acceder a la documentación Swagger:  
   👉 [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 🧠 Arquitectura Clean Overview

Cada capa tiene una responsabilidad clara:

| Capa | Rol | Descripción |
|------|------|-------------|
| **Core** | Dominio | Contiene las entidades, interfaces base y lógica empresarial pura. |
| **Application** | Aplicación | Define los casos de uso, servicios y lógica de negocio específica. |
| **Infrastructure** | Infraestructura | Implementa la persistencia, integración con bases de datos y servicios externos. |
| **WebApi** | Presentación | Expone endpoints HTTP y maneja solicitudes de clientes. |
| **Utilities** | Utilidades | Contiene funciones, extensiones o helpers reutilizables. |

---

## 🧰 Mejores Prácticas Implementadas

- Patrón **Repository y Unit of Work**  
- Validación y manejo de excepciones centralizados  
- DTOs y mapeos con **AutoMapper**  
- Configuración por entorno (Development, Staging, Production)  
- Registro y trazabilidad con **Serilog**  

---

## 📄 Licencia

Este proyecto se distribuye bajo la licencia **MIT**, lo que permite su libre uso y modificación.

=======
# \# 🚀 MyApi – API RESTful en .NET 8 con Clean Architecture

# 

# !\[.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet\&logoColor=white)

# !\[C#](https://img.shields.io/badge/C%23-Developer-blue?logo=csharp)

# !\[Clean Architecture](https://img.shields.io/badge/Architecture-Clean-brightgreen)

# !\[SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red?logo=microsoftsqlserver)

# !\[License](https://img.shields.io/badge/License-MIT-yellow)

# !\[Status](https://img.shields.io/badge/Status-Active-success)

# 

# \# MyApi

# 

# \*\*MyApi\*\* es una API RESTful desarrollada en \*\*.NET 8\*\*, diseñada siguiendo los principios de \*\*Clean Architecture\*\* para lograr un código modular, mantenible y escalable.  

# La solución separa claramente las responsabilidades en capas independientes, promoviendo una arquitectura desacoplada y fácil de probar.

# 

# ---

# 

# \## 🏗️ Estructura del Proyecto

# 

# ```bash

# MyApi/

# ├── Core/              → 🧠 Dominio: entidades e interfaces base del negocio

# ├── Application/       → ⚙️ Aplicación: lógica de negocio y casos de uso

# ├── Infrastructure/    → 🧩 Infraestructura: persistencia y servicios externos

# ├── WebApi/            → 🌐 Presentación: controladores y endpoints HTTP

# └── Utilities/         → 🧰 Utilidades y funciones auxiliares

# ```

# 

# \## 🏗️ Estructura del Proyecto: Detalle por cada capa

# ```bash

# MyApi/

# ├── Core/                                ← 🧠 Capa de Dominio

# │   ├── Entities/                        ← Entidades del dominio (modelos base del negocio)

# │   │   └── UnidadMedida.cs              ← Representa una entidad del dominio (por ejemplo, unidad de medida de un producto)

# │   ├── Interfaces/                      ← Contratos (abstracciones) del dominio

# │   │   └── IPedidosRepository.cs        ← Define qué operaciones deben ofrecer los repositorios, sin implementar nada

# │   └── Core.csproj                      ← Proyecto del dominio (sin dependencias a otras capas)

# │

# ├── Application/                         ← ⚙️ Capa de Aplicación

# │   ├── DTOs/                            ← Objetos de transferencia de datos (para comunicar entre capas)

# │   │   └── UnidadMedidaDto.cs           ← Versión simplificada de la entidad, usada en servicios o controladores

# │   ├── Interfaces/                      ← Contratos para los servicios de aplicación

# │   │   └── IUnidadMedidaService.cs      ← Define las operaciones de negocio disponibles (por ejemplo, CRUD de unidades)

# │   ├── Services/                        ← Implementaciones de los servicios de aplicación

# │   │   └── UnidadMedidaService.cs       ← Implementa la lógica de negocio usando los repositorios del dominio

# │   ├── DependencyInjection.cs           ← Configuración de inyección de dependencias para registrar servicios en el contenedor

# │   └── Application.csproj               ← Proyecto que depende solo del Core (Dominio)

# │

# ├── Infrastructure/                      ← 🧩 Capa de Infraestructura

# │   ├── Persistence/                     ← Acceso a datos y persistencia

# │   │   ├── SqlServer/                   ← Implementaciones específicas para SQL Server

# │   │   │   ├── DatabaseSettings.cs      ← Configuración de conexión a la base de datos

# │   │   │   ├── SqlServerConnectionFactory.cs ← Crea conexiones SQL de manera centralizada

# │   │   │   └── Repositories/            ← Implementaciones concretas de repositorios

# │   │   │       └── PedidosRepository.cs ← Implementa IPedidosRepository, con consultas SQL reales

# │   ├── DependencyInjection.cs           ← Registra la infraestructura (repositorios, DbContext, etc.) en el contenedor DI

# │   └── Infrastructure.csproj            ← Proyecto que depende de Core y Application

# │

# ├── WebApi/                              ← 🌐 Capa de Presentación (API)

# │   ├── Controllers/                     ← Puntos de entrada HTTP (endpoints)

# │   │   └── PedidosController.cs         ← Expone las operaciones de pedidos mediante HTTP

# │   ├── DTOs/                            ← Modelos específicos para respuestas o peticiones API

# │   │   └── ApiResponse.cs               ← Modelo estándar de respuesta (status, mensaje, datos)

# │   ├── Middleware/                      ← Middleware personalizados de ASP.NET Core

# │   │   └── ExceptionHandlingMiddleware.cs ← Captura y maneja excepciones globalmente

# │   ├── appsettings.json                 ← Configuración general de la aplicación (conexiones, claves, etc.)

# │   ├── Program.cs                       ← Punto de entrada de la aplicación; configura servicios y middleware

# │   └── WebApi.csproj                    ← Proyecto ejecutable, depende de Application e Infrastructure

# │

# ├── Utilities/                           ← 🧰 Capa de utilidades o helpers

# │   ├── ErrorUtilities.cs                ← Funciones auxiliares para manejo o formato de errores

# │   └── Utilities.csproj                 ← Proyecto de utilidades reutilizable por otras capas

# │

# └── MyApi.sln                            ← 💼 Solución principal que agrupa todos los proyectos

# ```

# 

# \### 🔁 Dependencias entre capas

# 

# \- \*\*WebApi\*\* depende de \*\*Application\*\*

# \- \*\*Application\*\* depende de \*\*Core\*\*

# \- \*\*Infrastructure\*\* implementa interfaces de \*\*Core\*\* y es utilizada por \*\*Application\*\*

# \- \*\*Utilities\*\* puede ser usada por todas las capas

# 

# ---

# 

# \## 🚀 Características Principales

# 

# \- Arquitectura basada en principios \*\*SOLID\*\*  

# \- Separación clara de responsabilidades  

# \- Uso de \*\*Inyección de Dependencias (DI)\*\*  

# \- Integración con \*\*Entity Framework Core\*\* y \*\*MediatR\*\*  

# \- Validación de entrada con \*\*FluentValidation\*\*  

# \- Manejo global de errores y respuestas consistentes  

# \- Documentación interactiva con \*\*Swagger / OpenAPI\*\*  

# 

# ---

# 

# \## ⚙️ Requisitos Previos

# 

# \- \[.NET SDK 8.0](https://dotnet.microsoft.com/download)

# \- \[SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) u otro motor compatible

# \- \[Visual Studio 2022](https://visualstudio.microsoft.com/) o \[Visual Studio Code](https://code.visualstudio.com/)

# 

# ---

# 

# \## 🧩 Ejecución del Proyecto

# 

# 1\. Clonar el repositorio  

# &nbsp;  ```bash

# &nbsp;  git clone https://github.com/gilnergarciaambulay/api-rest-net8-clear-aquitectura.git

# &nbsp;  cd api-rest-net8-clear-aquitectura

# &nbsp;  ```

# 2\. Restaurar dependencias  

# &nbsp;  ```bash

# &nbsp;  dotnet restore

# &nbsp;  ```

# 

# 3\. Aplicar migraciones (si corresponde)  

# &nbsp;  ```bash

# &nbsp;  dotnet ef database update

# &nbsp;  ```

# 

# 4\. Ejecutar la API  

# &nbsp;  ```bash

# &nbsp;  dotnet run --project api-rest-net8-clear-aquitectura

# &nbsp;  ```

# 

# 5\. Acceder a la documentación Swagger:  

# &nbsp;  👉 \[http://localhost:5000/swagger](http://localhost:5000/swagger)

# 

# ---

# 

# \## 🧠 Arquitectura Clean Overview

# 

# Cada capa tiene una responsabilidad clara:

# 

# | Capa | Rol | Descripción |

# |------|------|-------------|

# | \*\*Core\*\* | Dominio | Contiene las entidades, interfaces base y lógica empresarial pura. |

# | \*\*Application\*\* | Aplicación | Define los casos de uso, servicios y lógica de negocio específica. |

# | \*\*Infrastructure\*\* | Infraestructura | Implementa la persistencia, integración con bases de datos y servicios externos. |

# | \*\*WebApi\*\* | Presentación | Expone endpoints HTTP y maneja solicitudes de clientes. |

# | \*\*Utilities\*\* | Utilidades | Contiene funciones, extensiones o helpers reutilizables. |

# 

# ---

# 

# \## 🧰 Mejores Prácticas Implementadas

# 

# \- Patrón \*\*Repository y Unit of Work\*\*  

# \- Validación y manejo de excepciones centralizados  

# \- DTOs y mapeos con \*\*AutoMapper\*\*  

# \- Configuración por entorno (Development, Staging, Production)  

# \- Registro y trazabilidad con \*\*Serilog\*\*  

# 

# ---

# 

# \## 📄 Licencia

# 

# Este proyecto se distribuye bajo la licencia \*\*MIT\*\*, lo que permite su libre uso y modificación.

# 

# 

# 

# 
>>>>>>> 0b9eaf3 (Actualizar README con nueva información)



