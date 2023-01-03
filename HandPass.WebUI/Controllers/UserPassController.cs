using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using HandPass.WebUI.Models;
using System.Net.Http.Headers;
using System;
using System.Text;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using HandPass.Core.Utilities.Results;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Mvc.Rendering;
using HandPass.Core.Utilities.Security.Hashing;
using HandPass.Entities.Dto;
using System.Security.Claims;
using HandPass.Core.CoreEntities;
using HandPass.Entities.Entitiy;

namespace HandPass.WebUI.Controllers
{
    public class UserPassController : Controller
    {
        public IActionResult Index()
        {
            using (HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7276/api/UserPassword/") })
            {
                HttpResponseMessage response = _httpClient.GetAsync("GetUserAllPasswords").Result;
                List<UserPasswordViewModel> userPassList = new List<UserPasswordViewModel>();
                if (response.IsSuccessStatusCode)
                {
                    string resultContent = response.Content.ReadAsStringAsync().Result;
                    JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(resultContent);
                    userPassList = jsonResponse["data"].ToObject<List<UserPasswordViewModel>>();
                }
                else
                {
                    Console.Write("Failure");
                }

                return View(userPassList);
            }
        }

        public IActionResult CreateUserPassword()
        {
            using (HttpClient _httpClientCateogry = new HttpClient { BaseAddress = new Uri("https://localhost:7276/api/Category/") })
            {
                HttpResponseMessage responseCategory = _httpClientCateogry.GetAsync("GetAll").Result;
                List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
                if (responseCategory.IsSuccessStatusCode)
                {
                    string resultContentCategory = responseCategory.Content.ReadAsStringAsync().Result;
                    JObject jsonResponseCategory = JsonConvert.DeserializeObject<JObject>(resultContentCategory);
                    categoryList = jsonResponseCategory["data"].ToObject<List<CategoryViewModel>>();
                    List<SelectListItem> categories = new List<SelectListItem>();
                    foreach (var item in categoryList)
                    {
                        categories.Add(new SelectListItem { Text = item.CategoryName, Value = item.CateogryId.ToString() });
                    }
                    ViewBag.Categories = categories;
                }
                return View();
            }
        }
        [HttpPost]
        public IActionResult CreateUserPassword(UserPassword model)
        {
            using (HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7276/api/User/") })
            {
                HttpResponseMessage response = _httpClient.GetAsync("GetByCacheUserName").Result;
                if (response.IsSuccessStatusCode)
                {
                    string resultContent = response.Content.ReadAsStringAsync().Result;
                    string jsonResponse = JsonConvert.DeserializeObject<JObject>(resultContent).GetValue("id").ToString();
                    model.UserId = Convert.ToInt32(jsonResponse);
                }
            }
            using (HttpClient _httpClientNew = new HttpClient { BaseAddress = new Uri("https://localhost:7276/api/UserPassword/") })
            {
                var myContent = JsonConvert.SerializeObject(model);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var data = _httpClientNew.PostAsync("NewUserPassword", byteContent).Result;

                return RedirectToAction("Index", "UserPass");
            }
        }
    }
}


