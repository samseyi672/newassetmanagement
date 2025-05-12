

namespace NewAsset.Application.Common.dtos.response
{
    public class CustomerBvn
    {
        public bool status { get; set; }
        public string statuscode { get; set; }
        public string detail { get; set; }
        public string response_code { get; set; }
        public string message { get; set; }
        public CustomerBvnData data { get; set; }
        public string source { get; set; }
        public string user_info { get; set; }
        public string request_data { get; set; }
    }
    public class CustomerBvnData
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string phoneNumber { get; set; }
    }
}
