using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace HandPass.WebUI.Controllers
{
    public class BaseController : Controller
    {
        internal readonly HttpClient _httpClient;
        public BaseController()
        {
            _httpClient = new HttpClient {
                BaseAddress = new Uri("https://localhost:7276/api/")
            };
        }
    }
}
