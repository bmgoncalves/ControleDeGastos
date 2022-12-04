using ControleDeGastos.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Category c)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonContent = JsonConvert.SerializeObject(c);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var uri = "CategoriesApi";
                HttpResponseMessage response = new();

                if (c.Id == 0)
                    response = await client.PostAsync(uri, contentString);
                else
                    response = await client.PutAsync(uri, contentString);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return View(c);

            }
            return View(c);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception($"Category {id} not found");
                }

                var client = _httpClientFactory.CreateClient();
                var response = await client.DeleteAsync($"CategoriesApi?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    return Ok();
                }
                
                var erro = await response.Content.ReadAsStringAsync();
                throw new Exception(erro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
