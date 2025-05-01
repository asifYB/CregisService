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


            // 4. Send the POST request and get the response
            var response = await SendPostRequestAsync<CreateCardResponseData>(endpointConfig, payload);

            // 5. Process the response and convert it to the desired

            // early return if the response is null
            if (response.Data is null)
                return new ResponseDto()
                {
                    Status = response.Code,
                    Remarks = response.Msg
                };


            // 6. Return the response
            return new ResponseDto()
            {
                Status = response.Code,
                cardId = response.Data.CardId,
                CardNo = "",
                async = false,
                referenceId = response.Data.Sign,
                Remarks = response.Msg,
                taskId = response.Data.Nonce,
            };


        }

        public Task<CardOperationResDTO> SetPin(CardFreezeDto freeze)
        {
            throw new NotImplementedException();
        }
    }
}
