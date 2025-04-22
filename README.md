# ASTRO API 

Este proyecto es una API desarrollada en ASP.NET Core que sirve datos del Catálogo Messier y de agujeros negros conocidos. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre los datos de ambos catálogos, proporcionando una interfaz para acceder y manipular la información de estos objetos astronómicos.

## Estructura del Proyecto

1. **Controladores**:
   - `MessierController`: Maneja las operaciones relacionadas con los objetos del Catálogo Messier.
   - `BlackholeController`: Maneja las operaciones relacionadas con los agujeros negros.

2. **Modelos**:
   - `MessierModel`: Define la estructura de los datos para los objetos del Catálogo Messier.
   - `BlackHoleModel`: Define la estructura de los datos para los agujeros negros.

3. **Repositorios**:
- `‎IJsonDataRep`: Centraliza el llamado y la lectura de los json con los datos de cada controlador. Es escalable y está desacoplado del resto de la api.

## Funcionalidades

- **Operaciones CRUD**:
  - Obtener la lista completa de objetos del Catálogo Messier y de agujeros negros.
  - Obtener un objeto específico del Catálogo Messier por su ID.
  - Obtener un agujero negro específico por su tipo.
  - Crear nuevos objetos en el Catálogo Messier y nuevos agujeros negros.
  - Actualizar objetos existentes en el Catálogo Messier y agujeros negros.
  - Eliminar objetos del Catálogo Messier y agujeros negros.

- **CORS**:
  - Configuración de CORS para permitir solicitudes desde cualquier origen, método y encabezado.

- **Documentación OpenAPI**:
  - Generación de documentación OpenAPI para facilitar la exploración y prueba de la API.

- **Archivos Estáticos**:
  - Configuración para servir archivos estáticos desde la carpeta `wwwroot/Assets`.

## Ejemplo de Uso (Pendiente de deploy)

Para obtener la lista completa de objetos del Catálogo Messier, puedes realizar una solicitud GET a la siguiente URL: 
