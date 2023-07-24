using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ShopListAppNKatmanli.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       


        [HttpGet]
        public async Task<IActionResult> Adresses()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7297/api/Addresses");

            if (response.IsSuccessStatusCode)
            {
                var content=await response.Content.ReadAsStringAsync();
                List<GetAddressDTO> addressList=JsonConvert.DeserializeObject<List<GetAddressDTO>>(content);
                

                

                return View(addressList);
                
            }

            

            return View();
        }

        [HttpGet]
        public IActionResult AddAddresses() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAddresses(DefaultAddressDTO dto)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:7297/api/Addresses/addaddress",dto);
            
            return RedirectToAction("Adresses", "Dashboard");
        }
        
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var httpClient = new HttpClient();
            var response =  httpClient.DeleteAsync("https://localhost:7297/api/Addresses/delete?addressID=" + id);
           
            return RedirectToAction("Adresses", "Dashboard");
        }

        public async Task<IActionResult> GetAddress(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7297/api/Addresses/get?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var addressDTO = JsonConvert.DeserializeObject<GetAddressDTO>(jsonContent);

                    return View("GetAddress", addressDTO);
                }
                else
                {
                    // API'dan veri alınırken hata oluştu, uygun bir hata sayfasına yönlendirilebilir.
                    return View("Error");
                }
            }
        }
        public async Task<IActionResult> UpdateAddress(GetAddressDTO dto)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync("https://localhost:7297/api/Addresses/update",dto);
            return RedirectToAction("Adresses","Dashboard");
        }


        public async Task<IActionResult> GetAddressDetail(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://localhost:7297/api/Addresses/get?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var addressDTO = JsonConvert.DeserializeObject<GetAddressDTO>(jsonContent);

                    return View("GetAddressDetail", addressDTO);
                }
                else
                {
                    // API'dan veri alınırken hata oluştu, uygun bir hata sayfasına yönlendirilebilir.
                    return View("Error");
                }
            }
        }


    }
}
