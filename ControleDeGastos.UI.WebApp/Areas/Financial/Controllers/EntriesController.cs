using ControleDeGastos.ApplicationCore.Entities;
using ControleDeGastos.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace ControleDeGastos.UI.WebApp.Areas.Financial.Controllers
{
    public class EntriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EntriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddOrEdit(int id)
        {
            var client = _httpClientFactory.CreateClient();

            //Product product = null;
            HttpResponseMessage response = await client.GetAsync($"api/entries/{id}");
            if (response.IsSuccessStatusCode)
            {
                var e = await response.Content.ReadFromJsonAsync<Entries>();
            }
            //return product;


            return View();
        }

        [HttpPost]
        public IActionResult AddOrEdit(EntriesViewModel model)
        {
            return View();

        }
    }
}
