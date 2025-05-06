namespace CregisService.CardServices.Constants
{
    public static class ApiConstants
    {
        public const string BaseUrl = "https://api-sandbox.byber.cc";
        public const string SignKey = "c6043c5bb7ed4afcba4272f48faa356f";
        public const string MerchantId = "PXqkHKbwGX";
        public const string RSA_PRIVATE_KEY = """
                                -----BEGIN RSA PRIVATE KEY-----
                                MIIEpAIBAAKCAQEAs2oKOGim4Nx2olXpaOh+oW/g7nsQYGIdUrmxWUgZTHJq4tkw
                                V7ZvKDyK3cDwWaC4k4Al9asGuR+IL2OE4bnSMtR2vbB+wARdUyvSRoVoHRI34VoW
                                OG2+9z7yjqh6bg2XTm1xJMMRqsE74Fz1mYWrgsoTT4smg4fjPygznTMhx0ySIHN0
                                ocIREZe32CKM/BlUlAsOyIX9n/bEbXak/w5Dld3crzoyjwhsf1/c3pBiXzL/nlY9
                                +7W6VbNXb5SPdO0Jvt8vuo1xzkQ8t1sFHGri+4W1JQeKJTmkbKMQS0eiMmA88KOR
                                Tol7TsRfDE1dRsRD9Flb0DciN35h+zkXXIiseQIDAQABAoIBAC8NzIhmyf2HVIXW
                                ylR9RVjJotBo7i6ZDN+5W83yns/x4h6En60hZ53B4xmtlFutTztADLSVmjnLD0h+
                                bUdWGM7D8jBlrZhmjKNXhtp/+oJFWOp9Wf6Kqd7mX28SuKlMXzZudZISpvuFmlKJ
                                jtAowoaWwOHHuN4eMXdK7952npFKDo/t4S3csyRQ2wQo4n4qCMDHlkQXTgZUsQkL
                                dUZRRYTQzb/9fmqstJ1VIpVHSOVtkljhlfj3eVrHWahgMUFSLGVIG9+D5jXO77QO
                                n62W+hPi+0GQdssGvg6Ec8Wozc9hfT15hhsfFwPBR4eRRHQVAmQaOggsmxyN3j9C
                                ydyWLhECgYEA8HTkxXni67E3SbLU+A5lY0hHru3GEqZTwBsN7vA5f2WgXa0rFlY7
                                JPe6jXIVetT6QSqxKBoxO/ZpO58RerTAmLi0H7eb5RkEHcG8GeRwci4ZSRv/TLTg
                                4ghRs9vcQVnrzsZlIuygIeiw8M4ibVGiFf4K3ptOUQf99wi8mrlqeBsCgYEAvwMC
                                TjqM+aHZ6qU3FPj0euApvbEzlXVlbJ1KDeggydEuYpQIV535yynYqplut+1/s+4E
                                EUFqAdLquGKvYbNuyLqO5T2/t9DgemyerzjVF1Xlu4CL9UyjNrnVDO3Fw4BaB1n7
                                pvhxglhPMkvbwopKiRj4jE2naa8ZjA4OA/HRXvsCgYEAxn2H92eFJVBVtlWULewc
                                T5dz7PfEYNLCIbtzhgDxRbPLbGitP7QRAJQqf+ZjytCSgEbQlK0CZWAkQB4v3J3m
                                umsF7YSwgK5k0neBYdJL7EUXhF1DIrvRQ2TgpNrh92RWHotxIyI3kaY2oaFXk+wm
                                I4dgy59iR8uUHl8s6YATXm8CgYEAp4C9AdsIi1Tqo4FUp1iWFDcFg6qkYLl9Qt0/
                                9qgMMM72jU3hbuxDBG1i6l/4nuRvq1rbSEKD8quCWEV6JQRT70TiUJdwy4IpiFI+
                                acw92ePivSXCFk+phTE7asYMOiARUwcOzuJpr/M/KA0r3xKkwEsckvT6DYyWq6Ib
                                mkvx3gcCgYA60Gv2XN1ODMVLWKb2DYVjz9V1DeKQYafaJXNrq9rAokE8/Yd5AJqM
                                JcDGdfPFqYr9MfDys86zvAfID+CsPvzP4DIflTlnYIXK5k6P3b2r0e77PAwapMFI
                                czD70wADaFKaQcd71y2lqGeoH/EYYxIuNQoRFPAExP1CDGcGsG7HPA==
                                -----END RSA PRIVATE KEY-----
                                """;

        public static readonly string[] CreateCardSignFields =
            { "cardType", "customerType", "preferredCardName", "timestamp", "nonce" };

        public static readonly string[] ActivationCodeSignFields =
            { "cardId", "timestamp", "nonce" };


        public static readonly string[] RetreiveCardDetailsSignFields =
            { "cardId", "timestamp", "nonce" };

        public static readonly string[] ShowPANCardSignFields =
            { "cardId", "timestamp", "nonce" };

        public static readonly string[] CardBlockSignFields =
           { "cardId", "timestamp", "nonce" };

        public static readonly string[] CardUnblockSignFields =
          { "cardId", "timestamp", "nonce" };

        public static class Endpoints
        {
            public static readonly string ApplyCard = $"{BaseUrl}/byber-cards-api/cards/apply/card";
            public static readonly string ActivationCode = $"{BaseUrl}/byber-cards-api/cards/activeCode";
            public static readonly string RetreiveCardDetails= $"{BaseUrl}/byber-cards-api/cards/retrieveCard";
            public static readonly string ShowCardPAN = $"{BaseUrl}/byber-cards-api/cards/cardImportance";
            public static readonly string CardBlock = $"{BaseUrl}/byber-cards-api/cards/cardBlock";
            public static readonly string CardUnblock = $"{BaseUrl}/byber-cards-api/cards/cardUnblock";
        }

        public static class RSA
        {
            public const string PublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAq3v1x5+4J6X2Z5g7m1h4" +
                                            "Yj6c3f";
            public const string PrivateKey = "";
        }
    }
}
