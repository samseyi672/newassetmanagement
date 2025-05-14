using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Application.Common.dtos.response
{
    public class BvnResponse
    {
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string bankCode { get; set; }
        public string bankBranch { get; set; }
        public string phoneNumber { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public bool watchListed { get; set; }
        public string bvn { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string secondaryPhoneNumber { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfResidence { get; set; }
        public string maritalStatus { get; set; }
        public string nationalIdentityNumber { get; set; }
        public string nameOnCard { get; set; }
        public string nationality { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string base64Image { get; set; }
        public string lgaOfOrigin { get; set; }
    }
}
