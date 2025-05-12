
namespace NewAsset.Application.Common.dtos.response
{
    public class NinValidationResponse
    {

        [JsonProperty("status")]
        public string status { set; get; }


        [JsonProperty("response_code")]
        public string response_code { set; get; }

        [JsonProperty("statuscode")]
        public string statuscode { set; get; }

        [JsonProperty("message")]
        public string message { set; get; }

        [JsonProperty("nin_data")]
        public NinData ninData { set; get; }
    }

    public class NinData
    {

        public string firstname { set; get; }

        public string surname { set; get; }

        public string middlename { set; get; }

        public string birthdate { set; get; }

        public string userid { set; get; }

        public string gender { set; get; }

        public string telephoneno { set; get; }

        public string vnin { set; get; }

        public string self_origin_lga { set; get; }

        public string heigth { set; get; }

        public string birthstate { set; get; }

        public string signature { set; get; }

        public string religion { set; get; }

        public string educationallevel { set; get; }

        public string maritalstatus { set; get; }

        public string self_origin_state { set; get; }

        public string spoken_language { set; get; }

        public string trackingId { set; get; }

        public string self_origin_place { set; get; }

        public string residence_town { set; get; }

        public string nok_town { set; get; }

        public string residence_state { set; get; }

        public string residence_address { set; get; }

        public string birthcountry { set; get; }

        public string psurname { set; get; }

        [JsonProperty("pfirstname")]
        public string PFirstName { get; set; }

        [JsonProperty("nok_lga")]
        public string NokLga { get; set; }

        [JsonProperty("nok_address2")]
        public string NokAddress2 { get; set; }

        [JsonProperty("nok_state")]
        public string NokState { get; set; }

        [JsonProperty("nok_surname")]
        public string NokSurname { get; set; }

        [JsonProperty("nok_firstname")]
        public string NokFirstName { get; set; }

        [JsonProperty("ospokenlang")]
        public string OSpokenLang { get; set; }

        [JsonProperty("residencestatus")]
        public string ResidenceStatus { get; set; }

        [JsonProperty("pmiddlename")]
        public string PMiddleName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("nok_postalcode")]
        public string NokPostalCode { get; set; }

        [JsonProperty("nin")]
        public string Nin { get; set; }

        [JsonProperty("employmentstatus")]
        public string EmploymentStatus { get; set; }

        [JsonProperty("birthlga")]
        public string BirthLga { get; set; }

        [JsonProperty("residence_lga")]
        public string ResidenceLga { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("profession")]
        public string Profession { get; set; }

        [JsonProperty("centralID")]
        public string CentralID { get; set; }

        public string nok_address1 { set; get; }

        public string photo { set; get; }
    }
}
