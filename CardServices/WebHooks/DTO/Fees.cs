using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cregis.WebHooks.DTO
{
    public class Fees
    {
        [JsonPropertyName("fx_fees")]
        public string FxFees { get; set; } = "0.00";

        [JsonPropertyName("programFees")]
        public string ProgramFees { get; set; } = "0.00";

        [JsonPropertyName("refundFees")]
        public string RefundFees { get; set; } = "0.00";

        [JsonPropertyName("atm_fees")]
        public string AtmFees { get; set; } = "0.00";

        [JsonPropertyName("authorization_fee")]
        public string AuthorizationFee { get; set; } = "0.00";
    }
}
