using Microsoft.AspNetCore.Mvc;
using System.Text;
using Frontend.Models;
using Frontend.Response;
using Newtonsoft.Json;
using Frontend.Middleware;

namespace Frontend.Controllers
{
    [IsLoginMiddleware]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private string apiurl = "";

        public LoginController(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            apiurl = _configuration["BackendUrl"];
        }
        public IActionResult Index()
        {
            ViewData["Layout"] = false;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Auth(string username, string password)
        {

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData["message"] = "Please fill username and password!";
                return RedirectToAction("Index", "Login");
            }

            var queryString = $"?username={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}";
            var url = $"{apiurl}api/Master/Auth{queryString}";

            HttpResponseMessage response = await _httpClient.PostAsync(url, null);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var baseResponse = JsonConvert.DeserializeObject<BaseResponse<User>>(content);
                if(baseResponse.message.Equals("Login Success"))
                {
                    HttpContext.Session.SetString("Username", username);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["message"] = "Error calling API: " + response.ReasonPhrase;
            }

            return RedirectToAction("Index", "Login");
        }
    }
}
