using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSmart.Models;

namespace StockSmart.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductosController(IHttpClientFactory http)
        {
            _httpClient = http.CreateClient("APIApp");
        }


        // GET: ProductosController
        public ActionResult Index()
        {
            var productos = _httpClient.GetFromJsonAsync<List<Producto>>("products").Result;

            return View(productos);
        }

        // GET: ProductosController/Ficha/5
        [HttpGet]
        public ActionResult Ficha(int id)
        {
            var producto = _httpClient.GetFromJsonAsync<Producto>($"products/{id}").Result;

            return View(producto);
        }

        // POST: ProductosController/Ficha/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Ficha(int id, IFormCollection collection)
        public ActionResult Ficha(int id, Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Enviamos al API como PUT

                    var response = _httpClient.PutAsJsonAsync<Producto>($"products/{id}", producto).Result;

                    return RedirectToAction(nameof(Index));

                }
                else
                { 
                    return View(producto);
                }
            }
            catch
            {
                return View(new Producto());
            }
        }


        // GET: ProductosController/Nuevo
        public ActionResult Nuevo()
        {
            return View("Ficha", new Producto());
        }

        // POST: ProductosController/Nuevo
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Nuevo(IFormCollection collection)
        public ActionResult Nuevo(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var response = _httpClient.PostAsJsonAsync<Producto>("products", producto).Result;

                    //Enviamos al API como POST
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(producto);
                }
            }
            catch
            {
                return View("Ficha", new Producto());
            }
        }
    }
}
