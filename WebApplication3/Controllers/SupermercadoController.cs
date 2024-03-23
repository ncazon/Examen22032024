using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{

    public class SupermercadoController : Controller
    {
        private static List<Producto> productos = new List<Producto>
    {
        new Producto { Id = 1, Nombre = "Atún VanCamps", Precio = 12, Imagen = "atun.jpg" },
        new Producto { Id = 2, Nombre = "Queso menonita", Precio = 45, Imagen = "queso.jpg" }
    };

        private static List<Elemento> carrito = new List<Elemento>();

        public IActionResult Index()
        {
            return View(productos);
        }

        public IActionResult AgregarAlCarrito(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                var elemento = carrito.FirstOrDefault(e => e.Producto.Id == id);
                if (elemento != null)
                {
                    elemento.Cantidad++;
                }
                else
                {
                    carrito.Add(new Elemento { Producto = producto, Cantidad = 1 });
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Carrito()
        {
            return View(carrito);
        }

        public IActionResult EliminarDelCarrito(int id)
        {
            var elemento = carrito.FirstOrDefault(e => e.Producto.Id == id);
            if (elemento != null)
            {
                if (elemento.Cantidad > 1)
                {
                    elemento.Cantidad--;
                }
                else
                {
                    carrito.Remove(elemento);
                }
            }
            return RedirectToAction("Carrito");
        }

        public IActionResult FinalizarCompra()
        {
            var montoTotal = carrito.Sum(e => e.Producto.Precio * e.Cantidad);
            carrito.Clear();
            ViewBag.MontoTotal = montoTotal;
            return View("CompraRealizada");
        }
    }

}
