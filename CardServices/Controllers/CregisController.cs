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

            var applyCardDto = new ApplyCardDto
            {
                ProgramId = "12345",
                KYC = new KYC
                {
                    firstName = "Asif",
                    lastName = "Test",
                    gender = 1,
                    dob = "1990-05-01",
                    nationalityId = "US",
                    email = "asif.test@example.com",
                    mobileCode = "1",
                    mobile = "2345678903",
                    address = "123 Main St",
                    town = "SampleTown",
                    city = "SampleCity",
                    state = "SampleState",
                    zipCode = "12345",
                    countryId = "USA",
                    countryIsoThree = "USA",
                    emergencyContact = "9876543210",
                    docType = 1,
                    docId = "1234567",
                    frontDoc = "frontDocPath",
                    backDoc = "backDocPath",
                    docExpireDate = "2030-01-01",
                    docNeverExpire = 0,
                    handHoldIdPhoto = "handHoldIdPhotoPath",
                    bioMatric = "bioMatricData",
                    photo = "photoPath",
                    signImage = "signImagePath"
                },
                ProviderInformation = new ProviderInformation
                {
                    productToken = "productToken123",
                    Currency = "US",
                    FirstRechargeAmount = "100.00",
                    CardOpeningAmount = "50.00",
                    kyctype = "Basic",
                    tenantId = "tenant123",
                    taskId = "task123",
                    Status = "Active",
                    UserCreated = "Admin",
                    CardBin = 123456,
                    CardUserId = "user_123",
                    accountNo = "123456789",
                    Association = "Visa"
                },
                PublicKey = "publicKey123",
                PrivateKey = "privateKey123",
                ApiKey = "apiKey123",
                Kid = "kid123",
                TenantId = "tenant123"
            };



            var response = await cregisServices.ApplyVirtualCard(applyCard: applyCardDto);

            return response.Status switch
            {
                "success" => Ok(response),
                "error" => BadRequest(response),
                _ => StatusCode(500, response)
            };
        }
    }
}
