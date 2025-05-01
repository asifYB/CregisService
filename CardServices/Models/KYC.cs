namespace CregisService.CardServices.Models
{
    public class KYC
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int? gender { get; set; }
        public string? dob { get; set; } //birthday  Birthday (yyyy-MM-dd)  //provider convert
        public string? nationalityId { get; set; }
        public string? email { get; set; }
        public string? mobileCode { get; set; }  //areaCode  +86
        public string? mobile { get; set; }
        public string? address { get; set; }
        public string? town { get; set; }  //town code
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zipCode { get; set; }
        public string? countryId { get; set; }
        public string? countryIsoThree { get; set; }  // Country code. 3-digit code. See dictionary_common.xlsx (sheet. regin)
        public string? emergencyContact { get; set; }
        public int? docType { get; set; }    //idType is Passport  1 Passport
        public string? docId { get; set; }  //IdNo
        public string? frontDoc { get; set; }//idPicture
        public string? backDoc { get; set; }
        public string? docExpireDate { get; set; } //idNoExpiryDate
        public int? docNeverExpire { get; set; }
        public string? handHoldIdPhoto { get; set; } //handledPhoto  
        public string? bioMatric { get; set; }
        public string? photo { get; set; } //facePicture
        public string? signImage { get; set; }
    }
}
