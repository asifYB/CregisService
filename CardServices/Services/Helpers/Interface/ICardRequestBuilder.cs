using CregisService.CardServices.Models;

namespace CregisService.CardServices.Services.Helpers.Interface
{
    public interface ICardRequestBuilder
    {
        string CreateApplyCardRequest(ApplyCardDto applyCard, bool isVirtual);
        string CreateCardDetailsRequest(string cardId);
        string CreateSetPinRequest(string cardId, string pin);
        string CreatePinQueryRequest(string cardId);

        string CreateBindCardRequest(string cardId, string code);
    }
}
