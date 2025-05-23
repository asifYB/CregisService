﻿using CregisService.CardServices.Constants;
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
            var payload = PrepareRequestPayload(requestData, PayloadConstants.CreateCardSignFields);

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
            var payload = PrepareRequestPayload(requestData, PayloadConstants.CreateCardSignFields);

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

       

        public async Task<CardDetailsRespDto> CardDetails(string cardId, ProviderInformationDto providerInformation, string refId = null)
        {  
            // 1. Prepare request payload
            var requestData = _requestBuilder.CreateCardDetailsRequest(cardId: cardId);
            var payload = PrepareRequestPayload(requestData, PayloadConstants.RetrieveCardDetailsSignFields);

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
            var payload = PrepareRequestPayload(requestData, PayloadConstants.ShowPANCardSignFields);

            // 2. Define endpoints
            var showPANCardEndpoint = ApiConstants.Endpoints.ShowCardPAN;

            // 3. send the request
            var encryptPan = await SendPostRequestAsync<string>(showPANCardEndpoint, payload);

            // 4. Decrypt and manually parse response data
            var values = new Dictionary<string, string>();

            if(encryptPan.Data is not null)
            {
                var decryptedResponse = DecryptData.DecryptResponseData(encryptPan.Data, ApiConstants.RSA_PRIVATE_KEY);
                values = ParseQueryStringManual(decryptedResponse);

                // 5. Check if the response contains the expected number of values
                if (values.Count == 6)
                {
                    cardDetailsRespDto.CardNumber = values.GetValueOrDefault("pan") ?? string.Empty;
                    cardDetailsRespDto.Cvv = values.GetValueOrDefault("cvv") ?? string.Empty;
                    cardDetailsRespDto.ExpirationDate = values.GetValueOrDefault("expiryDate") ?? string.Empty;
                }
            }
            
            // 6. Return the card details response DTO
            return cardDetailsRespDto;
        }

        public async Task<CardOperationResDTO> CardLock(CardFreezeDto cardLockDto)
        {
            // Ensure the request object is not null
            if (cardLockDto is null || string.IsNullOrEmpty(cardLockDto.ProviderCardToken))
                return await Task.FromResult(new CardOperationResDTO());

            // Prepare request payload
            var requestData = _requestBuilder.CreateCardDetailsRequest(cardId: cardLockDto.ProviderCardToken!);

            var payload = PrepareRequestPayload(requestData, PayloadConstants.CardBlockSignFields, reason: "Blocking Card For Testing");

            // Define endpoints
            var cardBlockEndpoint = ApiConstants.Endpoints.CardBlock;

            // Send request
            var cardBlockResponse = await SendPostRequestAsync<CardBlockData>(cardBlockEndpoint, payload);

            // early return
            if (cardBlockResponse.Data is null)
                return await Task.FromResult(new CardOperationResDTO()
                {
                    Status = cardBlockResponse.Code,
                    Remarks = cardBlockResponse.Msg
                }); ;

            //  return the actual response
            return new CardOperationResDTO()
            {
                Status = cardBlockResponse.Code,
                Remarks = cardBlockResponse.Msg + " : Card Blocked Successfully!",
                TaskId = cardBlockResponse.Data.Nonce
            };
        }

        public async Task<CardOperationResDTO> CardUnock(CardFreezeDto cardUnlockDto)
        {
            // Ensure the request object is not null
            if (cardUnlockDto is null || string.IsNullOrEmpty(cardUnlockDto.ProviderCardToken))
                return await Task.FromResult(new CardOperationResDTO());

            // Prepare request payload
            var requestData = _requestBuilder.CreateCardDetailsRequest(cardId: cardUnlockDto.ProviderCardToken!);

            var payload = PrepareRequestPayload(requestData, PayloadConstants.CardUnblockSignFields);

            // Define endpoints
            var cardBlockEndpoint = ApiConstants.Endpoints.CardUnblock;

            // Send request
            var cardBlockResponse = await SendPostRequestAsync<CardBlockData>(cardBlockEndpoint, payload);

            // early return
            if (cardBlockResponse.Data is null)
                return await Task.FromResult(new CardOperationResDTO()
                {
                    Status = cardBlockResponse.Code,
                    Remarks = cardBlockResponse.Msg
                }); ;

            //  return the actual response
            return new CardOperationResDTO()
            {
                Status = cardBlockResponse.Code,
                Remarks = cardBlockResponse.Msg + " : Card Unblocked Successfully!",
                TaskId = cardBlockResponse.Data.Nonce
            };
        }

        

        public async Task<CardOperationResDTO> SetPin(CardFreezeDto freeze)
        {
            // Ensure the request object is not null
            if (freeze is null || string.IsNullOrEmpty(freeze.ProviderCardToken) || string.IsNullOrEmpty(freeze.pinNumber))
                return await Task.FromResult(new CardOperationResDTO()
                {
                    Status = "400",
                    Remarks = "Invalid request data"
                });

            // Prepare request payload
            var requestData = _requestBuilder.CreateSetPinRequest(cardId: freeze.ProviderCardToken!, pin: freeze.pinNumber);

            var payload = PrepareRequestPayload(requestData, PayloadConstants.SetPinSignFields);

            // Define endpoints
            var setCardPinEndpoint = ApiConstants.Endpoints.SetPin;

            // Send request
            var setCardPinResponse = await SendPostRequestAsync<SetPinData>(setCardPinEndpoint, payload);

            // early return
            if (setCardPinResponse.Data is null)
                return await Task.FromResult(new CardOperationResDTO()
                {
                    Status = setCardPinResponse.Code,
                    Remarks = setCardPinResponse.Msg
                }); ;

            //  return the actual response
            return new CardOperationResDTO()
            {
                Status = setCardPinResponse.Code,
                Remarks = setCardPinResponse.Msg + " : Card Pin created Successfully!",
                TaskId = setCardPinResponse.Data.Nonce
            };

        }

        //this is for physical card to get the pin
        public async Task<CardDetailResDto> PinQuery(string cardId, ProviderInformationDto providerInformation)
        {
            // Ensure the request object is not null
            if (cardId is null)
                return await Task.FromResult(new CardDetailResDto());

            // Prepare request payload
            var requestData = _requestBuilder.CreatePinQueryRequest(cardId: cardId);

            var payload = PrepareRequestPayload(requestData, PayloadConstants.PinQuerySignFields);

            // Define endpoints
            var pinQueryEndpoint = ApiConstants.Endpoints.PinQuery;

            // Send request
            var pinQueryResponse = await SendPostRequestAsync<PinQueryData>(pinQueryEndpoint, payload);

            return pinQueryResponse.Data is null ?
                new CardDetailResDto()
                {
                    Pin = string.Empty,
                    CardNumber = string.Empty,
                }
                :
                new CardDetailResDto()
                {
                    Pin = pinQueryResponse.Data.ActivationCode,
                    CardNumber = string.Empty,
                };
        }

        public async Task<BindingResDto> BindCard(BindCardDto bindingReqDto)
        {
           if(bindingReqDto is null || bindingReqDto.cardid is null || bindingReqDto.UniqueId is null)
                return await Task.FromResult(new BindingResDto()
                {
                    Status = "400",
                    Remarks = "Invalid request data"
                });

            // Prepare request payload
            var requestData = _requestBuilder.CreateBindCardRequest(cardId: bindingReqDto.cardid!, code: bindingReqDto.UniqueId!);
            var payload = PrepareRequestPayload(requestData, PayloadConstants.BindCardSignFields);

            // Define endpoints
            var bindCardEndpoint = ApiConstants.Endpoints.BindCard;

            // Send request
            var bindCardResponse = await SendPostRequestAsync<BindCardData>(bindCardEndpoint, payload);


            // early return
            if (bindCardResponse.Data is null)
                return await Task.FromResult(new BindingResDto()
                {
                    Status = bindCardResponse.Code,
                    Remarks = bindCardResponse.Msg
                });

            //  return the actual response
            return new BindingResDto()
            {
                Status = bindCardResponse.Code,
                Remarks = bindCardResponse.Msg + " : Card Binded Successfully!",
                TaskId = bindCardResponse.Data.Nonce
            };
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
