using Cards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Cards.Controllers
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

            return View();
        }

        public async Task<IActionResult> Search(string queryString)
        {
            using var client = new HttpClient();

            var url = "https://pixabay.com/api/?key=21202698-0832628a200234a5d9c3e6251&q=" + HttpUtility.UrlEncode(queryString) + "&image_type=photo";
            var result = await client.GetAsync(url);
            //var json = JsonConvert.DeserializeObject(result);
            return Json(result.Content.ReadAsStringAsync().Result);
        }

        //public IActionResult Details(int id, string url)
        //{
        //    ViewBag.Image = url;
        //    return View();
        //}

        //public async Task<IActionResult> Goruntule(int id, string url, string tags, string param)
        //{
        //    var client = new HttpClient();
        //    string apiurl = "http://api.positionstack.com/v1/forward?access_key=71be4d74c3046a60c83be8386d401414&query=" + param + "&limit=1";
        //    var result = await client.GetAsync(apiurl);
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var sonuc = await result.Content.ReadAsStringAsync();
        //        var sonuc2 = JsonConvert.DeserializeObject<List<PositionModel>>(sonuc.Result);
        //        return View(sonuc);
        //    }
        //    return null;
        //}

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
}
