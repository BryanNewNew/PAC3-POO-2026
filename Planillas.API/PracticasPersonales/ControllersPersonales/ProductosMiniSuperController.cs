using Microsoft.AspNetCore.Mvc;
using Planillas.API.PracticasPersonales.EntitiesPersonales;

namespace Planillas.API.PracticasPersonales.ControllersPersonales
{
    [ApiController]
    [Route("api/productos")]

    public class ProductosMiniSuperController : ControllerBase
    {
        private static List<ProductosMiniSuperEntity> productosMiniSuperEntities = new List<ProductosMiniSuperEntity>
        {
             new ProductosMiniSuperEntity { Id = 000001, Nombre = "Leche", Precio = 15.89m, Stock = 25, Categoria = "Lácteos" },
             new ProductosMiniSuperEntity { Id = 000002, Nombre = "Mantequilla", Precio = 32.89m, Stock = 20, Categoria = "Lácteos"} 
        };

        [HttpGet]

        public IActionResult Opciones()
        {
            var Opciones = new
            {
              Mensaje = "Lista de Opciones de el Controlador:\n ",
              RutasDisponibles  = new List<string>
              {
                  "Metodo GET: http://localhost:5174/api/productos - Obtener todos los productos",
                  "Metodo GET un producto http://localhost:5174/api/productos/{Id} - Obtener un producto específico",
                  "Metodo GET productos por categoria http://localhost:5174/api/productos/Categoria/{Categoria} - Obtener productos por categoría",
                  "Metodo POST: http://localhost:5174/api/productos - Agregar un nuevo producto",
                  "Metodo PUT: http://localhost:5174/api/productos/{Categoria}/{Id} - Actualizar un producto existente",
                  "Metodo DELETE: http://localhost:5174/api/productos/{Categoria}/{Id} - Eliminar un producto"
              }
            };

            return Ok(Opciones);
        }

        [HttpGet("ALL")]
        public IActionResult GetProductos()
        {
            return Ok(productosMiniSuperEntities);
        }

        [HttpGet("{Id}")]

        public IActionResult GetProductoPorId(int Id)
        {
            return Ok(productosMiniSuperEntities.FirstOrDefault(p => p.Id == Id));
        }

        [HttpGet("Categoria/{Categoria}")]

        public IActionResult GetProductosPorCategoria(string? Categoria)
        {
            var productosPorCategoria = productosMiniSuperEntities.Where(p => p.Categoria == Categoria).ToList();
            return Ok(productosPorCategoria);
        }

        [HttpPost]

        public IActionResult AgregarProducto([FromBody] ProductosMiniSuperEntity producto)
        {
            productosMiniSuperEntities.Add(producto);
            return Ok(new {Id = producto.Id});
        }

        [HttpPut("{Categoria}/{Id}")]
        public IActionResult ActualizarProducto(string? Categoria, int Id, [FromBody] ProductosMiniSuperEntity producto)
        {
            var productoExistente = productosMiniSuperEntities.FirstOrDefault(p => p.Categoria == Categoria && p.Id == Id);

            if(productoExistente == null)
            {
                return NotFound();
            }
            productosMiniSuperEntities.Remove(productoExistente);
            productosMiniSuperEntities.Add(producto);

            return Ok(new {
            Categoria = producto.Categoria,
            Id = producto.Id});
        }

        [HttpDelete("{Categoria}/{Id}")]

        public IActionResult EliminarProducto(string? Categoria, int Id)
        {
            var productoExistente = productosMiniSuperEntities.FirstOrDefault(p => p.Categoria == Categoria && p.Id == Id);

            if(productoExistente == null)
            {
                return NotFound();
            }
            
            productosMiniSuperEntities.Remove(productoExistente);
            return Ok(new {Categoria = productoExistente.Categoria, Id = productoExistente.Id});
        }
    }
}