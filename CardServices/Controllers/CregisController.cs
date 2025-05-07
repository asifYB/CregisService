using System.Threading.Tasks;
using CregisService.CardServices.Constants;
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

        [HttpPost]
        [Route("CreateVirtualCard")]
        public async Task<IActionResult> CreateVirtualCard([FromBody] ApplyCardDto applyCard)
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
                    mobileCode = "+1",
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
                    CardUserId = "user_7210",
                    accountNo = "123456789",
                    Association = "Visa"
                },
                PublicKey = ApiConstants.RSA.PublicKey,
                PrivateKey = ApiConstants.RSA.PrivateKey,
                ApiKey = ApiConstants.SignKey,
                Kid = "kid123",
                TenantId = "tenant123"
            };



            var response = await cregisServices.ApplyVirtualCard(applyCard: applyCardDto);

            return response.Status switch
            {
                "200" => Ok(response),
                _ => StatusCode(500, response)
            };
        }

        [HttpPost]
        [Route("CreatePhysicalCard")]
        public async Task<IActionResult> CreatePhysicalCard([FromBody] ApplyCardDto applyCard)
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
                    mobileCode = "+1",
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
                    CardUserId = "user_7210",
                    accountNo = "123456789",
                    Association = "Visa"
                },
                PublicKey = ApiConstants.RSA.PublicKey,
                PrivateKey = ApiConstants.RSA.PrivateKey,
                ApiKey = ApiConstants.SignKey,
                Kid = "kid123",
                TenantId = "tenant123"
            };



            var response = await cregisServices.ApplyPhysicalCard(applyCard: applyCardDto);
            return response.Status switch
            {
                "200" => Ok(response),
                _ => StatusCode(500, response)
            };
        }

        [HttpPost]
        [Route("ShowCardDetails")]
        public async Task<IActionResult> ShowCardDetails([FromBody] string cardId)
        {
            CregisServices cregisServices1 = new(new CardRequestBuilder());
            CregisServices cregisServices2 = new(new CardRequestBuilder());

            var response = await cregisServices1.CardDetails(cardId: "e28266c7-6328-47fa-baeb-78e6e78ea8e2", providerInformation: null);
            var fullresponse = await cregisServices2.CardDetails(cardId: "e28266c7-6328-47fa-baeb-78e6e78ea8e2", cardDetailsRespDto: response);

            return fullresponse.CardStatus switch
            {
                "200" => Ok(fullresponse),
                _ => StatusCode(500, fullresponse)
            };
        }

        [HttpPost]
        [Route("BlockCard")]
        public async Task<IActionResult> BlockCard([FromBody] string cardId)
        {
            CregisServices cregisServices = new(new CardRequestBuilder());
            var cardFreezeDto = new CardFreezeDto()
            {
                ProviderCardToken = "e28266c7-6328-47fa-baeb-78e6e78ea8e2"
            };
            var response = await cregisServices.CardLock(cardLockDto: cardFreezeDto);

            return response.Status switch
            {
                "200" => Ok(response),
                _ => StatusCode(500, response)
            };
        }

        [HttpPost]
        [Route("UnblockCard")]
        public async Task<IActionResult> UnblockCard([FromBody] string cardId)
        {
            CregisServices cregisServices = new(new CardRequestBuilder());
            var cardFreezeDto = new CardFreezeDto()
            {
                ProviderCardToken = "e28266c7-6328-47fa-baeb-78e6e78ea8e2"
            };

            var response = await cregisServices.CardUnock(cardUnlockDto: cardFreezeDto);

            return response.Status switch
            {
                "200" => Ok(response),
                _ => StatusCode(500, response)
            };
        }

        [HttpPost]
        [Route("SetPin")]
        public async Task<IActionResult> SetPinUnblockCard([FromBody] string cardId)
        {
            CregisServices cregisServices = new(new CardRequestBuilder());
            var cardFreezeDto = new CardFreezeDto()
            {
                ProviderCardToken = "e28266c7-6328-47fa-baeb-78e6e78ea8e2",
                pinNumber = "9143"
            };

            var response = await cregisServices.SetPin(freeze: cardFreezeDto);

            return response.Status switch
            {
                "200" => Ok(response),
                _ => StatusCode(500, response)
            };
        }
    }
}
