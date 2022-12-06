using ControleDeGastos.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace ControleDeGastos.UI.WebApp.Areas.Financial.Controllers
{
    [Area("Financial")]
    public class EntriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EntriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("EntriesApi");
            if (response.IsSuccessStatusCode)
            {
                List<Entries> lista = await response.Content.ReadFromJsonAsync<List<Entries>>();
                return View(lista);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEdit(Entries e)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var client = _httpClientFactory.CreateClient();
                    HttpResponseMessage response = new();
                    var jsonContent = JsonConvert.SerializeObject(e);
                    var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var uri = "EntriesApi";

                    if (e.Id == 0)
                        response = await client.PostAsync(uri, contentString);
                    else
                        response = await client.PutAsync(uri, contentString);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    var erro = await response.Content.ReadAsStringAsync();
                    return BadRequest(erro);

                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"CategoriesApi");
            if (response.IsSuccessStatusCode)
            {
                List<Category> listaCategorias = await response.Content.ReadFromJsonAsync<List<Category>>();
                if (listaCategorias != null)
                {
                    ViewBag.Categories = listaCategorias.OrderBy(c => c.Description).ToList().Select(c => new SelectListItem(c.Description, c.Id.ToString()));
                }
            }

            id ??= 0;
            if (id == 0)
            {
                return View();
            }
            response = await client.GetAsync($"EntriesApi?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var e = await response.Content.ReadFromJsonAsync<Entries>();
                if (e != null)
                {
                    return View(e);
                }
            }
            return View();
        }


    }
}
