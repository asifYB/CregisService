using CregisService.CardServices.Models;

namespace CregisService.CardServices.Services.Helpers.Interface
{
    public interface ICardRequestBuilder
    {
        string CreateApplyCardRequest(ApplyCardDto applyCard, bool isVirtual);
        string CreateCardDetailsRequest(string cardId);
    }
}
