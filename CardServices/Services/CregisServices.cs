using CregisService.CardServices.Constants;
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

        public async Task<ResponseDto> ApplyPhysicalCard(ApplyCardDto applyCard)
        {
            //1. Create the request data using the request builder
            var requestData = _requestBuilder.CreateApplyCardRequest(applyCard: applyCard, isVirtual: false);

            // 2. Get endpoint configuration
            var endpointConfig = ApiConstants.Endpoints.ApplyCard;

            // 3. Prepare the payload along with signature
            var payload = PrepareRequestPayload(requestData, ApiConstants.CreateCardSignFields);

            // 4. Send the POST request and get the response
            var response = await SendPostRequestAsync<CreateCardResponseData>(endpointConfig, payload);

            // 5. Process the response and convert it to the desired
            // early return if the response is null because of error
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
                CardNo = string.Empty,
                referenceId = ApiConstants.MerchantId,
                Remarks = response.Msg,
                taskId = response.Data.Nonce,
            };
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
            // early return if the response is null because of error
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
                CardNo = string.Empty,
                referenceId = ApiConstants.MerchantId,
                Remarks = response.Msg,
                taskId = response.Data.Nonce,
            };
        }

        public Task<BindingResDto> BindCard(BindCardDto bindingReqDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CardDetailsRespDto> CardDetails(string cardId, ProviderInformationDto providerInformation, string refId = null)
        {  
            // 1. Prepare request payload
            var requestData = _requestBuilder.CreateCardDetailsRequest(cardId: cardId);
            var payload = PrepareRequestPayload(requestData, ApiConstants.RetreiveCardDetailsSignFields);

            // 2. Define endpoints
            var retrieveCardEndpoint = ApiConstants.Endpoints.RetreiveCardDetails;

            // 3. send request
            var cardDetails = await SendPostRequestAsync<CardDetailsData>(retrieveCardEndpoint, payload);

            //early return if error occurred
            if (cardDetails?.Data == null)
                return new CardDetailsRespDto()
                {
                    CardNumber = string.Empty,
                    CardStatus = string.Empty,
                    Cvv = string.Empty,
                    ExpirationDate = string.Empty,
                };

            // return the response dto
            return new CardDetailsRespDto
            {
                CardNumber =  string.Empty,
                CardStatus = cardDetails.Data.Status,
                Cvv = string.Empty,
                ExpirationDate =  string.Empty,
            };
        }

        public async Task<CardDetailsRespDto> CardDetails(string cardId, CardDetailsRespDto cardDetailsRespDto)
        {
            // 1. Prepare request payload
            var requestData = _requestBuilder.CreateCardDetailsRequest(cardId: cardId);
            var payload = PrepareRequestPayload(requestData, ApiConstants.ShowPANCardSignFields);

            // 2. Define endpoints
            var showPANCardEndpoint = ApiConstants.Endpoints.ShowCardPAN;

            // 3. Fire parallel requests
            var encryptPan = await SendPostRequestAsync<string>(showPANCardEndpoint, payload);
  
            // 4. Decrypt and manually parse response data
            var decryptedResponse = DecryptData.DecryptResponseData(encryptPan.Data, ApiConstants.RSA_PRIVATE_KEY);
            var values = ParseQueryStringManual(decryptedResponse);

            // 5. Check if the response contains the expected number of values
            if (values.Count == 6)
            {
                cardDetailsRespDto.CardNumber = values.GetValueOrDefault("pan") ?? string.Empty;
                cardDetailsRespDto.Cvv = values.GetValueOrDefault("cvv") ?? string.Empty;
                cardDetailsRespDto.ExpirationDate = values.GetValueOrDefault("expiry") ?? string.Empty;
            }

            // 6. Return the card details response DTO
            return cardDetailsRespDto;
        }

        public Task<CardOperationResDTO> CardLock(CardFreezeDto cardLockDto)
        {
            throw new NotImplementedException();
        }

        public Task<CardOperationResDTO> CardUnock(CardFreezeDto cardUnlockDto)
        {
            throw new NotImplementedException();
        }

        public Task<CardOperationResDTO> SetPin(CardFreezeDto freeze)
        {
            throw new NotImplementedException();
        }

        public Task<string> ShowListOfCardss(int page, int limt)
        {
            throw new NotImplementedException();
        }

        public Task<string> Transactions()
        {
            throw new NotImplementedException();
        }

        #region Private Methods
        private Dictionary<string, string> ParseQueryStringManual(string input)
        {
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var part in input.Split('&', StringSplitOptions.RemoveEmptyEntries))
            {
                var pair = part.Split('=', 2);
                if (pair.Length == 2)
                {
                    result[pair[0].Trim()] = Uri.UnescapeDataString(pair[1].Trim());
                }
            }

            return result;
        }
        #endregion
    }
}
