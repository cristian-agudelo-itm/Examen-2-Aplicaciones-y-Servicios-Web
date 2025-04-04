# 📌 Examen 2 - Aplicación de Servicio Web (REST API)

## 📌 Descripción:

Este proyecto es una API REST desarrollada en C# con ASP.NET Web API (.NET Framework), que permite el **registro y control de camiones y pesajes**. La API fue diseñada como parte del Examen Parcial 2 de la asignatura, cumpliendo con los requerimientos especificados.

## 📌 Funcionalidades:

✅ Consultar todos los camiones  
✅ Consultar camión por placa  
✅ Registrar un nuevo camión  
✅ Eliminar un camión  
✅ Registrar pesajes de camiones, incluyendo carga de imagen  
✅ Validación de peso máximo permitido por número de ejes  
✅ Almacenamiento de imágenes en base de datos como `byte[]`  
✅ Visualización de datos mediante pruebas en Postman con variables y métodos organizados  

## 📌 Tecnologías utilizadas:

🔹 Lenguaje: C#  
🔹 Framework: ASP.NET Web API (.NET Framework)  
🔹 Base de Datos: SQL Server  
🔹 ORM: Entity Framework  
🔹 Herramientas de Prueba: Postman  

## 📌 Requisitos para ejecutar el proyecto:

🔹 Visual Studio 2022  
🔹 SQL Server (con la base de datos y tablas configuradas según `Examen_2_Jueves.sql`)  
🔹 Postman (importar colección `API.postman_collection.json`)  
🔹 Actualizar cadena de conexión en `Web.config` si se ejecuta desde otro equipo

## 🧪 Datos de prueba:

🔸 El proyecto incluye scripts para insertar registros de prueba en las tablas `Camion`, `Pesaje` y `FotoPesaje`.  
🔸 Las imágenes se almacenan directamente en la base de datos (campo `Imagen` como `varbinary(max)`).  
🔸 Se pueden subir imágenes desde Postman usando `form-data`.

## 📂 Estructura del Proyecto:

- `Models/` → Entidades como `Camion.cs`, `Pesaje.cs`, `FotoPesaje.cs`
- `Controllers/` → Controladores `CamionesController.cs`, `PesajesController.cs`
- `Services/` → Lógica de negocio en `CamionService.cs`, `PesajeService.cs`
- `API.postman_collection.json` → Colección de Postman con todos los métodos organizados y configurados

## 🔎 Validaciones:

✔️ Comprobación de si el camión ya está registrado (placa única)  
✔️ Validación del peso máximo por número de ejes  
✔️ Validación del tipo de archivo subido (imagen)  
✔️ Todos los métodos incluyen status y respuesta verificables en Postman  


## 👤 Autores:

👤 Cristian Andres Agudelo Henao y Jeronimo Patiño Betancur
📅 Fecha: 4 de Abril de 2025
