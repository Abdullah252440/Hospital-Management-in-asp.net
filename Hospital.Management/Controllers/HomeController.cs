using Hospital.Management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Hospital.Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            //ApiResponse data= new ApiResponse();
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            //    //HTTP GET
            //    var responseTask = client.GetAsync("todos/1");
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadFromJsonAsync<ApiResponse>();
            //        readTask.Wait();

            //        data = readTask.Result;
            //    }
            //    else //web api sent error response 
            //    {
            //        //log response status here..

                  

            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //    }
            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class ApiResponse
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
}