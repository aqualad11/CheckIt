using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CheckIt.ServiceLayer
{
    public class SignatureService
    {

        private readonly string APIKey = "E3F13B1D7EBF1430109A30EDAF96A7B6662A7A00F56D333CDCBCC6A84CD95400";

        public bool IsValid(Guid ssoID, string email, long timestamp, string signature)
        {
            //create payload
            Dictionary<string, string> payload = new Dictionary<string, string>()
            {
                { "ssoUserId", ssoID.ToString() },
                { "email", email },
                { "timestamp", timestamp.ToString() }
            };

            string generatedSig = Sign(payload);
            return generatedSig == signature;

        }
        

        //The following methods were taken from SSO
        // Signs a dictionary with the provided key by constructing a key/value string
        public string Sign(Dictionary<string, string> payload)
        //public string Sign(string key, dynamic payload)
        {
            // Order the provided dictionary by key
            // This is necessary so that the recipient of the payload will be able to generate the
            // correct hash even if the order changes
            var orderedPayload = from payloadItem in payload
                                 orderby payloadItem.Value descending
                                 select payloadItem;

            var payloadString = "";
            // Build a payload string with the format:
            // key =value;key2=value2;
            // SECURITY: This must be passed in this format so that the resulting hash is the same
            foreach (var pair in orderedPayload)
            {
                payloadString += pair.Key + "=" + pair.Value + ";";
            }

            var signature = Sign(APIKey, payloadString);
            return signature;
        }

        // Signs a string with the provided key
        public string Sign(string key, string payloadString)
        {
            // Instantiate a new hashing algorithm with the provided key
            HMACSHA256 hashingAlg = new HMACSHA256(Encoding.ASCII.GetBytes(key));

            // Get the raw bytes from our payload string
            byte[] payloadBuffer = Encoding.ASCII.GetBytes(payloadString);

            // Calculate our hash from the byte array
            byte[] signatureBytes = hashingAlg.ComputeHash(payloadBuffer);

            var signature = Convert.ToBase64String(signatureBytes);
            return signature;
        }
    }
}
