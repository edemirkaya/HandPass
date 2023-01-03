using HandPass.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HandPass.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel model)
        {
            using (HttpClient _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7276/api/Category/")
            })
            {
                var myContent = JsonConvert.SerializeObject(model);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var data = _httpClient.PostAsync("CreateCategory", byteContent).Result;

                return RedirectToAction("Create","Category");
            }
        }
    }
}
