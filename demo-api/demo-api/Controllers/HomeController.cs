using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace demo_api.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private ApiService _apiService;

        public HomeController(ApiService apiService)
        {
            _apiService = apiService;
        }
        // GET
        public async Task<List<string>> GetAll()
        {
            return await _apiService.GetFromApi();
        }
    }
}