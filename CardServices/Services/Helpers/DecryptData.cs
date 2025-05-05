using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto;
using System.Text;
using Org.BouncyCastle.OpenSsl;

namespace CregisService.CardServices.Services.Helpers
{
    public class DecryptData
    {
        public static string DecryptResponseData(string base64EncryptedData, string privateKeyPem)
        {
            // Decode base64 encrypted data
            byte[] encryptedBytes = Convert.FromBase64String(base64EncryptedData);

            // Load the private key from PEM
            AsymmetricKeyParameter privateKey;
            using (TextReader reader = new StringReader(privateKeyPem))
            {
                PemReader pemReader = new PemReader(reader);
                object keyObject = pemReader.ReadObject();

                if (keyObject is AsymmetricCipherKeyPair keyPair)
                {
                    privateKey = keyPair.Private;
                }
                else if (keyObject is AsymmetricKeyParameter keyParam)
                {
                    privateKey = keyParam;
                }
                else
                {
                    throw new InvalidCastException("Could not read private key from PEM.");
                }
            }

            // Initialize the cipher with OAEP SHA-1 padding
            var engine = new OaepEncoding(
                new RsaEngine(),
                new Org.BouncyCastle.Crypto.Digests.Sha1Digest(),
                new Org.BouncyCastle.Crypto.Digests.Sha1Digest(),
                null
            );
            engine.Init(false, privateKey); // false = decryption

            // Decrypt
            byte[] decryptedBytes = engine.ProcessBlock(encryptedBytes, 0, encryptedBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
