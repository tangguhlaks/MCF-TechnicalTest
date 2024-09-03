using Frontend.Middleware;
using Frontend.Models;
using Frontend.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace Frontend.Controllers
{
    [IsNotLoginMiddleware]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private string apiurl = "";
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, HttpClient httpClient)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClient = httpClient;
            apiurl = _configuration["BackendUrl"];
        }

        public async Task<IActionResult> Index()
        {
            var url = $"{apiurl}api/Master/GetStorageLocation";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var baseResponse = JsonConvert.DeserializeObject<BaseResponse<List<StorageLocation>>>(content);
                ViewBag.storages = baseResponse.data;
            }
            else
            {
                ViewBag.storages = new List<StorageLocation>();
            }

            url = $"{apiurl}api/Transaction/GetBpkb";

            response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var baseResponse = JsonConvert.DeserializeObject<BaseResponse<List<Bpkb>>>(content);
                ViewBag.listData = baseResponse.data;
            }
            else
            {
                ViewBag.listData = new List<Bpkb>();
            }
            ViewBag.username = HttpContext.Session.GetString("Username");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string agreement_number)
        {
            var url = $"{apiurl}api/Transaction/DeleteBpkb?agreementNumber={agreement_number}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var baseResponse = JsonConvert.DeserializeObject<BaseResponse<Bpkb>>(content);
                if (baseResponse.message.Equals("success"))
                {
                    TempData["success-message"] = $"Delete Data Successfully!";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["error-message"] = $"Delete Data Failed!";
                return RedirectToAction("Index", "Home");
            }
            TempData["error-message"] = $"Delete Data Failed!";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bpkb model)
        {
            if (ModelState.IsValid)
            {
                string username = HttpContext.Session.GetString("Username");
                model.created_by = username;
                model.last_updated_by = username;
                model.last_updated_on = DateTime.Now;
                model.created_on = DateTime.Now;

                var url = $"{apiurl}api/Transaction/CreateBpkb";

                // Serialize the model to JSON and send it in the request body
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                // Post the data to the API
                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    // Handle the error response from the API
                    TempData["success-message"] = $"Submit Data Successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error-message"] = $"Submit Data Failed!";
                    return RedirectToAction("Index", "Home");

                }
            }
            TempData["error-message"] = $"Submit Data Failed!";
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Update(Bpkb model)
        {
            if (ModelState.IsValid)
            {
                string username = HttpContext.Session.GetString("Username");
                
                model.created_by = username;
                model.last_updated_by = username;
                model.last_updated_on = DateTime.Now;
                model.created_on = DateTime.Now;
                
                var url = $"{apiurl}api/Transaction/UpdateBpkb";

                // Serialize the model to JSON and send it in the request body
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                // Post the data to the API
                HttpResponseMessage response = await _httpClient.PutAsync(url, jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    // Handle the error response from the API
                    TempData["success-message"] = $"Update Data Successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error-message"] = $"Update Data Failed!";
                    return RedirectToAction("Index", "Home");

                }
            }
            TempData["error-message"] = $"Update Data Failed!";
            return RedirectToAction("Index", "Home");

        }
    }
}
