# 📌 Examen 2 - Aplicación de Servicio Web (REST API)

## 📌 Descripción:

Este proyecto es una API REST desarrollada en C# con ASP.NET Web API (.NET Framework), que permite el **registro y control de camiones y pesajes**. La API fue diseñada como parte del Examen Parcial 2 de la asignatura, cumpliendo con los requerimientos especificados en el archivo oficial del examen.

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
- `Web.config` → Configuración de la conexión a la base de datos
- `API.postman_collection.json` → Colección de Postman con todos los métodos organizados y configurados

## 🔎 Validaciones:

✔️ Comprobación de si el camión ya está registrado (placa única)  
✔️ Validación del peso máximo por número de ejes  
✔️ Validación del tipo de archivo subido (imagen)  
✔️ Todos los métodos incluyen status y respuesta verificables en Postman  

## 📹 Instrucciones para la presentación en video:

1. Mostrar entorno de desarrollo (Visual Studio)
2. Explicar brevemente el modelo y estructura
3. Ejecutar el servidor local
4. Probar cada método desde Postman (usando variables y entorno creado)
5. Mostrar pruebas exitosas: creación, consulta, validación y carga de imagen
6. Finalizar mostrando resultados en la base de datos

## 👤 Autores:

👤 [Tu Nombre Aquí]  
📅 Fecha: Abril 2025
