#                                                                   ASTRO API 

Este proyecto es una API desarrollada en ASP.NET Core que sirve datos del Catálogo Messier, planetas del sistema solar y de agujeros negros conocidos. La API te facilita estos datos en tu frontend, ideal para proyectos web donde necesites consumir y mostrar correctamente los datos como: Imágenes de todos los objetos mencionados, datos de observación, físicos y dinámicos.  

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

- **Endpoint de listado completo y de filtrado por ID**:
- Por ej: api/Messier/Data - Devuelve todos los datos relativos al catálogo Messier.
- Y api/Messier/{tipo(cuasar, nebulosa, planeta. etc)} - Devuelve datos según el tipo que se especifique.


- **CORS**:
  - Configuración de CORS para permitir solicitudes desde cualquier origen, método y encabezado.

- **Documentación OpenAPI**:
  - Generación de documentación OpenAPI para facilitar la exploración y prueba de la API.

- **Archivos Estáticos**:
  - Configuración para servir archivos estáticos desde la carpeta `wwwroot/Assets`.

## Ejemplo de Uso (Pendiente de deploy)

Para obtener la lista completa de objetos del Catálogo Messier, puedes realizar una solicitud GET a la siguiente URL: 
