# ASTRO API

 API desarrollada en ASP.NETCore que sirve datos del Catálogo Messier, planetas del sistema solar y de algunos agujeros negros conocidos. La API te facilita estos datos en tu frontend, ideal para proyectos web donde necesites consumir y mostrar correctamente los datos como: Imágenes de todos los objetos mencionados, datos de observación, físicos y dinámicos.

## Estructura del Proyecto

 **Controladores**: Maneja las solicitudes http exponiendo y validando la información con dos endpoints en todos los controladores.

- `MessierController`
- `BlackholeController`
- `PlanetsControllers`

**Modelos**: Definen el mapeo de los datos desde la persistencia (Json) hasta la capa de controladores.

- `MessierModel`
- `BlackHoleModel`
- `PlanetsModel`

 **Repositorios**:

- `IJsonDataRep`: Centraliza el llamado y la lectura de los json con los datos de cada controlador.

## Funcionalidades

**Endpoint de listado completo y de filtrado por ID**:

- Por ej: api/Messier/Data - Devuelve todos los datos relativos al catálogo Messier.
- Y api/Messier/{tipo(cuasar, nebulosa, planeta. etc)} - Devuelve datos según el tipo que se especifique.

## Ejemplo de Uso en tu front (Pendiente de deploy)

``` JavaScript
document.addEventListener('DOMContentLoaded', () => {

    
    cargarDatosBh();

});

async function cargarDatosBh() {
    try {
        const response = await fetch('http://exampleURL:5034/api/Blackhole/Data');
        const result = await response.json();

        console.log('Resultado completo:', result); 
        console.log('Datos:', result.data); 

        const items = result.data; 

        // Verificamos si hay datos en 'items'
        if (!Array.isArray(items) || items.length < 0) {

            console.log('No hay datos de Messier disponibles.');
            document.getElementById('bh-container').innerHTML = '<p>No hay datos disponibles.</p>';

        }

        let htmlContent = '';


        items.forEach(item => {

            const imagenUrl = `${BaseUrl}/${item.imagenURL}`;

            htmlContent += `
                <div class="card">
                    <div class="card-content">
                        <h2>Nombre: ${item.nombre || 'N/A'}</h2>
                        <h3>Tipo: ${item.tipo || 'N/A'}</h3>
                        <h3>Distancia: ${item.distancia || 'N/A'}</h3>
                        <h3>Masa (en masas solares): ${item.masasSolares || 'N/A'}</h3>
                        <h3>Radio de Schwarzschild: ${item.radioSchwarzschild || 'N/A'}</h3>
                        <h3>Fecha de descubrimiento: ${item.fechaDescubrimiento || 'N/A'} por: ${item.descubridor || 'N/A'}.</h3>
                        <p>${item.descripcion || 'N/A'}</p>
                    </div>
                    <img src="${imagenUrl || 'default-image.jpg'}" alt="${item.nombre || 'Imagen de Messier'}">
                </div>
            `;


        });

        document.getElementById('bh-container').innerHTML = htmlContent;


    } catch (error) {
        console.error('Error al cargar los datos de Messier:', error);
    }
}

```
