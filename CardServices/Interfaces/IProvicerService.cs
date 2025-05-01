using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CregisService.CardServices.Models;
//using DigitalBank.CardsService.HyperPay;
//using DigitalBank.CardsService.Mesta;
//using DigitalBank.CardsService.Models;
//using DigitalBank.CardsService.Payments;
//using DigitalBank.CardsService.PayOu;
//using DigitalBank.CardsService.PhotonPay;
//using DigitalBank.CardsService.ProviderModels;
//using Volo.Abp.Application.Services;
//using static System.Runtime.InteropServices.JavaScript.JSType;
//using static DigitalBank.CardsService.ProviderModels.WebhookResponcesModels;

namespace DigitalBank.CardsService.Samples
{
    public interface IProvicerService
    {
        Task<ResponseDto> ApplyVirtualCard(ApplyCardDto activatecardReqDto);
        //Task<CardOperationResDTO> CardTopUp(CardTopUpDto cardtopupReqDto);



        //Task<List<ListOfCardsDto>> ShowListOfCards(string? taskId);
        //Task<List<Item>> ShowListOfCard(string? taskId, int page);

        //// Task<EstimateCardFeeUppfoResp> EstimateCardFee(EstimateCreateOrCancelCardFee estimateCardFeeReq);
        ////// Task<CardDetailsRespDto> AddCardAddress(UserInfo userInfo, string cardToken);
        //// Task<ResponseDto> CardTopUp(CardTopUpReqDto cardtopupReqDto);
        //// Task<string> CardVerificationCode(CardReqDto cardReqDto);
        //Task<CardOperationResDTO> CardLock(CardFreezeDto cardLockDto);
        //Task<CustomerBalance> CustomerCards(string uuid, string accountId, ProviderInformationDto providerInformation);
        //CardTypePhysicalDetails CardPhsyicalList(string cardTypeId);

        //Task<CardOperationResDTO> CardUnock(CardFreezeDto cardUnlockDto);
        //// Task<CardWithdrawalRespDto> CardWithdrawal(CardWithdrawalReqDto cardwithdrawalDto);
        //Task<CardDetailsRespDto> CardDetails(string cardId, ProviderInformationDto providerInformation, string refId = null);
        //Task<CardOperationResDTO> CardCancellation(CardFreezeDto cancelCardDto);
        //// Task<TaskDetailsRespDto> TaskDetails(TaskDetailsReqDto taskDetailsReqDto);
        //// Task<string> Transactions();
        //Task<ActivateCardEventModel> CardStatusUpdate(string taskId, ProviderInformationDto providerInformation);
        //Task<EstimateTopupResponce> EstimateCardTopup(string cardId, string amount, ProviderInformationDto providerInformation, string accountNo);

        //Task<List<HBCardTransactionsDto>> CardsTransactions(string cardId, string notifyTyp, ProviderInformationDto providerInformation);
        //Task<HBCardTransactionsDto> RechargeStatusUpdate(string cardId, string mctradenumber, string notifyType, ProviderInformationDto providerInformation);


        //// for physical card
        //Task<BindingResDto> BindCard(BindCardDto bindingReqDto);
        ////Task<BindingKycResDto> BindingKYC(BindingKYCDto bindingKYCDto);
        //Task<CardDetailResDto> PinQuery(string cardId, ProviderInformationDto providerInformation);


        //// for internal main provider details 
        //Task<CustomerInformation> PoviderInfo(string customerToken);


        //Task<bool?> GetMerchantConfig(ProviderInformationDto providerInformation);
        ////Task submitkycverification(string uuguid, int cardid);
        //Task<ResponseDto> CustomerRegister(object activateCard);
        Task<ResponseDto> ApplyPhysicalCard(ApplyCardDto activateCard);
        ////Task<ResponseDto> UploadFile(UploadFileReqDto uploadFile);
        ////Task<ResponseDto> MerchantListRegistration(object activateCard);

        ////Task MerchantListUpdate(MerchantListUpdateDto merchantListUpdate);
        //Task<CustomerInformation> PoviderInfo();
        //Task<List<ProviderBalance>> ProviderBalance(ProviderInformationDto provi);
        //Task<ResponseDto> PayouApplyVirtualCard(PayouApplyCardDto activateCard);
        //Task<ResponseDto> UserRegistration(ApplyCardDto applyCardDto);
        //Task<ResponseDto> KycBinding(BindKYCAttachments bindKYCAttachments);
        //Task<ResponseDto> KYCAttachments(KYCAttachmentsVerification kYCAttachments);
        //Task<ResponseDto> VirtualCardStatus(string cardToken, ProviderInformationDto provider);
        //Task<TransactionResponseDTO> TradeConsumes(TransactionDTO trans);


        //Task<CardsListDto> MerchantCardslist(ProviderInformationDto providerInformation);
        //Task<ReqKycDocumentsDto> UploadDocuments(KycDocumentsDto kycDocumentsDto, ProviderInformationDto provider);
        Task<CardOperationResDTO> SetPin(CardFreezeDto freeze);
        //Task<Datum> CardList(string programid, ProviderInformationDto provider);
        //Task<CardRechargeDto> CardRechargeStatus(string orderNo, string publicKey, string privateKey, string apiKey);
        //Task<PaymentReponseDto> CreateSenders(CreateSenderDto senders);
        //Task<List<WalletAddressResponseDto>> GetWalletAddresses(string taskId);
        //Task<PaymentReponseDto> UpdateSender(UpdateSenderDto updateSenderDto, string senderId);

        //Task<PaymentReponseDto> CreateBeneficiary(BeneficiariesDto beneficiariesDto);
        //Task<PaymentReponseDto> UpdateBeneficiary(BeneficiaryEditDto beneficiaryEditDto, string beneficiaryId);
        //Task<SenderViewDto> GetSender(string senderId);
        //Task<QuoteReponseDto> CreateQuote(CreateQuoteDto createQuoteDto);
        //Task<PaymentReponseDto> CreateOrder(CreateOrderDto createOrderDto);
        //Task<PaymentReponseDto> Beneficiaries(string beneficiaryId);


        //Task<QuoteReponseDto> GetQuote(string acceptedQuoteId);
        //Task<PaymentReponseDto> VerifySender(string? taskId);
        //Task<string> Transactions(string cardNumber, DateTime start, DateTime end, int page, int pagesize);
        //Task<string> UppfoAuthtransaction(string cardNumber, DateTime start, DateTime end, int page, int pagesize);
        //Task<List<RefundDataRecord>> CardsRefundTransactions(HyperPayRefundsDto hyperPayRefundsDto, ProviderInformationDto provider);
        //Task<string> kycverification(string uniqueId, int cardTypeId, ProviderInformationDto provider);
        //Task<string> kycquery(string uniqueId, int cardTypeId, ProviderInformationDto provider);

        //Task<CardDetailsUppfoResponse> CardBalanceDetails(string cardId, ProviderInformationDto providerInformation);
        //Task<string> AsinxKYCQuery(ReqDto reqDto, ProviderInformationDto provider);
        //Task<string> ShowListOfCardss(int page, int limt);
        //Task<ResponseDto> CardHolderInfo(WewallexCardCreation cardCreation, ProviderInformationDto provider);
        //Task AsinxSetCardHolderInfo(string? reqorResPayload, ProviderInformationDto provider);
        //Task<PhotonPayApplyCardDto> PhotonPayRequestResult(PhotonPayCardCreation photonPayCardCreation, string v, ProviderInformationDto provider);
    }
}
