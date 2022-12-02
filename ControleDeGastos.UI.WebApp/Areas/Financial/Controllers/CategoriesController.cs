using ControleDeGastos.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControleDeGastos.UI.WebApp.Areas.Financial.Controllers
{
    [Area("Financial")]
    public class CategoriesController : Controller
    {
        private IHttpClientFactory _httpClientFactory;
        public CategoriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"CategoriesApi");
            if (response.IsSuccessStatusCode)
            {
                List<Category> listaCategorias = await response.Content.ReadFromJsonAsync<List<Category>>();
                return View(listaCategorias);
            }
            return View();
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            id ??= 0;
            if (id > 0)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"CategoriesApi/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var c = await response.Content.ReadFromJsonAsync<Category>();
                    return View(c);
                }
                return BadRequest("Categoria não localizada, tratar este erro!");
            }
            return View();
        }


    }
}
