using System.Globalization;
using System.Text.Json;
using CregisService.CardServices.Constants;
using CregisService.CardServices.Models;
using CregisService.CardServices.Models.Enum;
using CregisService.CardServices.Services.Helpers.Interface;

namespace CregisService.CardServices.Services.Helpers
{
    public class CardRequestBuilder : ICardRequestBuilder
    {
        public string CreateApplyCardRequest(ApplyCardDto applyCard, bool isVirtual)
        {
            var kyc = applyCard.KYC;
            var cardType = isVirtual ? CardTypes.Virtual.ToString() : CardTypes.Physical.ToString();

            var requestData = new
            {
                cardType,
                customerType = CustomerTypes.Consumer.ToString(),
                kyc = new
                {
                    kyc?.firstName,
                    kyc?.lastName,
                    dob = DateTime.TryParse(kyc?.dob, out var dobDate)
                          ? dobDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                          : null,
                    idDocumentType = kyc?.docType != null
                                     ? ((DocType)kyc.docType).ToString()
                                     : null,
                    idDocumentNumber = kyc?.docId,
                    residentialAddress = new
                    {
                        line1 = kyc?.address,
                        line2 = kyc?.address,
                        kyc?.city,
                        country = kyc?.countryId
                    }
                },
                expiryDate = DateTime.TryParse(kyc?.docExpireDate, out var expDate)
                             ? expDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                             : null,
                preferredCardName = kyc?.firstName,
                meta = new
                {
                    id = applyCard.ProviderInformation?.CardUserId,
                    kyc?.email,
                    otpPhoneNumber = new
                    {
                        dialCode = int.TryParse(kyc?.mobileCode, out var code) ? code : 0,
                        phoneNumber = kyc?.mobile
                    }
                }
            };

            return JsonSerializer.Serialize(requestData);
        }
    }
}
