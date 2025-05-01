using System.Globalization;
using System.Text.Json;
using CregisService.CardServices.Models;
using CregisService.CardServices.Models.Enum;
using CregisService.CardServices.Services.Helpers.Interface;

namespace CregisService.CardServices.Services.Helpers
{
    public class CardRequestBuilder : ICardRequestBuilder
    {
        public string CreateApplyCardRequest(ApplyCardDto applyCard, bool isVirtual)
        {
            var requestData = new
            {
                cardType = "Virtual",  //can be enum Virtual and Physiscal
                customerType = "Consumer",  // Business, Consumer
                kyc = new
                {
                    applyCard.KYC?.firstName,
                    applyCard.KYC?.lastName,
                    dob = applyCard.KYC?.dob != null
                 ? DateTime.Parse(applyCard.KYC.dob).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                 : null,
                    idDocumentType = applyCard.KYC?.docType != null 
                ? ((DocType)applyCard.KYC.docType).ToString()
                : null,  //Allowed values:Passport,Health,NationalID,TaxIDNumber,SocialService,DriversLicense
                    idDocumentNumber =  applyCard.KYC?.docId,
                    residentialAddress = new
                    {
                        line1 = applyCard.KYC?.address,
                        line2 = applyCard.KYC?.address,
                        line3 = "Building C",
                        line4 = "Central District",
                        line5 = "Block 12",
                        applyCard.KYC?.city,
                        country = applyCard.KYC?.countryId,
                        postalCode = applyCard.KYC?.zipCode
                    }
                },
                expiryDate = applyCard.KYC?.docExpireDate != null
                 ? DateTime.Parse(applyCard.KYC.docExpireDate).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                 : null,
                preferredCardName = applyCard.KYC?.firstName,
                meta = new
                {
                    id = applyCard.ProviderInformation.CardUserId,
                    applyCard.KYC?.email,
                    otpPhoneNumber = new
                    {
                        dialCode = int.TryParse(applyCard.KYC?.mobileCode, out var code) ? code : 0,
                        phoneNumber = applyCard.KYC?.mobile
                    }
                },
                cardDesign = (string?)null
            };

            return JsonSerializer.Serialize(requestData);
        }
    }
}
