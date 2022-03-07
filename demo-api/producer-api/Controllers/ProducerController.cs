using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace producer_api.Controllers
{
    [ApiController]
    [Route("/producer")]
    public class ProducerController : ControllerBase
    {
        public List<string> GetAll()
        {
            return new List<string>() {"toto", "tata", "titi"};
        }
    }
}