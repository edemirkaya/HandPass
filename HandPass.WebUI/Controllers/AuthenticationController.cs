using HandPass.Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using HandPass.Core.Utilities.Security.Jwt;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using HandPass.WebUI.Models;

namespace HandPass.WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserForLoginDto model)
        {
            using (HttpClient _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7276/api/Auth/")
            })
            {
                var myContent = JsonConvert.SerializeObject(model);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var data = _httpClient.PostAsync("Login", byteContent).Result;
                AccessToken result = new AccessToken();
                if (data.IsSuccessStatusCode)
                {
                    string resultContent = data.Content.ReadAsStringAsync().Result;
                    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(resultContent);
                    result = jsonResponse["data"].ToObject<AccessToken>();
                }
                return Json(result);
            }
        }

        [HttpPost]
        public IActionResult Register(CreateUserViewModel model)
        {
            using (HttpClient _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7276/api/Auth/")
            })
            {
                var myContent = JsonConvert.SerializeObject(model);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var data = _httpClient.PostAsync("Register", byteContent).Result;
                
                return RedirectToAction("Login");
            }
        }
    }
}
