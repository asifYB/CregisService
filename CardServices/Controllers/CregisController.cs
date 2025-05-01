using System.Threading.Tasks;
using CregisService.CardServices.Models;
using CregisService.CardServices.Services;
using CregisService.CardServices.Services.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CregisService.CardServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CregisController : ControllerBase
    {

        private readonly ILogger<CregisController> _logger;

        public CregisController(ILogger<CregisController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CreateCard")]
        public async Task<IActionResult> CreateCard()
        {
            CregisServices cregisServices = new(new CardRequestBuilder());

            var response = await cregisServices.ApplyVirtualCard(new ApplyCardDto());

            return response.Status switch
            {
                "success" => Ok(response),
                "error" => BadRequest(response),
                _ => StatusCode(500, response)
            };
        }
    }
}
