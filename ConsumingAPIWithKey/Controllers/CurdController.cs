using ConsumingAPIWithKey.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumingAPIWithKey.Controllers
{
    public class CurdController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<RegisterModel> obj = await getAllData();
            return View(obj);
        }

        public async Task<IEnumerable<RegisterModel>> getAllData()
        {
            IEnumerable<RegisterModel> obj = null;
            var Apikey = "Abc123@_";
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:7085/api/Curd/GetAllData");  // getting the data from this uri
                request.Method = HttpMethod.Get;
                request.Headers.Add("X-api-key", Apikey);
                HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var data = await httpResponseMessage.Content.ReadAsAsync<IEnumerable<RegisterModel>>();
                    obj = data;
                }
                else
                {
                    obj = null;
                }

            }


            return obj;
        }

        public async Task<IActionResult> Insert(RegisterModel obj)
        {
            var Apikey = "Abc123@_";
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:7085/api/Curd/posts");
                request.Method = HttpMethod.Post;
                request.Headers.Add("X-api-key", Apikey);
                request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle the error
                  //  ModelState.AddModelError(string.Empty,);
                    return View(obj);
                }
            }
        }
        public async Task<IActionResult> Edit(RegisterModel obj)
        {
            var Apikey = "Abc123@_";
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:7085/api/Curd/UpdatesData");
                request.Method = HttpMethod.Put;
                request.Headers.Add("X-api-key", Apikey);
                request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle the error
                  //  ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return View(obj);
                }
            }
        }
        public async Task<IActionResult> Delete(int RollNo)
        {
            var Apikey = "Abc123@_";
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri("https://localhost:7085/api/Curd/DeletesData{ RollNo}");
                request.Method = HttpMethod.Delete;
                request.Headers.Add("X-api-key", Apikey);

                HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle the error
                  //  ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return RedirectToAction("Index");
                }
            }
        }



    }
}
