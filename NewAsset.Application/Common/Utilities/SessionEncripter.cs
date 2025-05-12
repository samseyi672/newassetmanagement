

namespace NewAsset.Application.Common.Utilities
{
    public class SessionEncripter
    {
        public string EncryptString(string str)
        {
            try
            {
                if (string.IsNullOrEmpty(str))
                    return string.Empty;
                var hashAlgorithm = new Org.BouncyCastle.Crypto.Digests.Sha3Digest(512);
                

                // Choose correct encoding based on your usecase
                byte[] input = Encoding.ASCII.GetBytes(str);

                hashAlgorithm.BlockUpdate(input, 0, input.Length);

                byte[] result = new byte[64]; // 512 / 8 = 64
                hashAlgorithm.DoFinal(result, 0);

                string hashString = BitConverter.ToString(result);
                hashString = hashString.Replace("-", "").ToLowerInvariant();
                return hashString;
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex.Message + " " + ex.StackTrace);
                return null;
            }
        }
    }
}
