using System.Globalization;
using System.Text.Json;
using CregisService.CardServices.Constants;
using CregisService.CardServices.Core;
using CregisService.CardServices.Models;
using CregisService.CardServices.Models.CardAPIResponseDTO;
using CregisService.CardServices.Services.Helpers;
using CregisService.CardServices.Services.Helpers.Interface;
using DigitalBank.CardsService.Samples;

namespace CregisService.CardServices.Services
{
    public class CregisServices : CregisBaseService, IProvicerService
    {
        private readonly ICardRequestBuilder _requestBuilder;

        public CregisServices(ICardRequestBuilder requestBuilder)
        {
            _requestBuilder = requestBuilder;
        }

        public Task<ResponseDto> ApplyPhysicalCard(ApplyCardDto activateCard)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> ApplyVirtualCard(ApplyCardDto applyCard)
        {
            //1. Create the request data using the request builder
            var requestData = _requestBuilder.CreateApplyCardRequest(applyCard: applyCard, isVirtual: true);

            // 2. Get endpoint configuration
            var endpointConfig = ApiConstants.Endpoints.ApplyCard;

            // 3. Prepare the payload along with signature
            var payload = PrepareRequestPayload(requestData, ApiConstants.CreateCardSignFields);

            Console.WriteLine(payload);

            // 4. Send the POST request and get the response
            var response  = await SendPostRequestAsync<CreateCardResponseData>(endpointConfig, payload);

            // 5. Process the response and convert it to the desired format
            var result = new ResponseDto()
            {
                Status = response.Code,
                cardId = response.Data.CardId,
                CardNo = "",
                async = false,
                referenceId = "",
                Remarks = "",
                taskId = "",
            };

            // 6. return the result
            return result;
        }

        public Task<CardOperationResDTO> SetPin(CardFreezeDto freeze)
        {
            throw new NotImplementedException();
        }
    }
}
