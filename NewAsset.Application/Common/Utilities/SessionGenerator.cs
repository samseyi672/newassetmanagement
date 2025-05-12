

namespace NewAsset.Application.Common.Utilities
{
    public class SessionGenerator
    {
        public string GetSession()
        {
            try
            {
                string sess =new SessionEncripter().EncryptString(DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + new Random().Next(1111, 9999));
                StringBuilder sb = new StringBuilder();
                foreach (char c in sess)
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                        sb.Append(c);
                Console.WriteLine($"returning {sb.ToString()}");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex.Message + " " + ex.StackTrace);
                throw new BadRequestException();
            }
        }
     
    }
}
