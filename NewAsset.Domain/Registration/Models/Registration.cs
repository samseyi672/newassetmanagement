
namespace NewAsset.Domain.Registration.Models
{
    [Table("asset_capital_insurance_registration")]
    [Index(nameof(UserName), Name = "Registration_UserName")]
    [Index(nameof(UserType), nameof(CreatedAt), Name = "Registration_UserType_CreatedAt")]
    public class Registration:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }
        [NotMapped]
        public string Id
        {
            get => id.ToString();
            set => id = long.TryParse(value, out var result) ? result : id;
        }

        [Column("username")]
        [Required]
        [ColumnName("username")]
        public string UserName { get; set; } =string.Empty;

        [Column("validbvn")]
        [ColumnName("validbvn")]
        public bool ValidBvn { get; set; }

        [Column("user_type")]
        [Required]
        [ColumnName("user_type")]
        public string UserType { get; set; } = string.Empty;

        [Column("first_name")]
        [ColumnName("first_name")]
        public string? FirstName { get; set; }

        [Column("bvn")]
        [Required]
        [ColumnName("Bvn")]
        public string? Bvn { get; set; } =string.Empty ;

        [Column("nin")]
        [ColumnName("nin")]
        public string? Nin { get; set; }

        [Column("last_name")]
        [ColumnName("last_name")]
        public string? LastName { get; set; }

        [Column("address")]
        [ColumnName("address")]
        public string? Address { get; set; }

        [Column("email")]
        [ColumnName("email")]
        public string? email { get; set; }

        [Column("phonenumber")]
        [ColumnName("phonenumber")]
        public string? phoneNumber { get; set; }

        [Column("othernames")]
        [ColumnName("othernames")]
        public string? otherNames { get; set; }

        [Column("customerId")]
        [ColumnName("customerId")]
        public string? CustomerId { get; set; } // from finedge if exists

        [Column("AccountOpened")]
        [ColumnName("AccountOpened")]
        public int AccountOpened { get; set; }

        [Column("ProfiledOpened")]
        [ColumnName("ProfiledOpened")]
        public int ProfiledOpened { get; set; }

        [Column("RequestReference")]
        [ColumnName("RequestReference")]
        public string? RequestReference { get; set; }

        [Column("birth_date")]
        [ColumnName("birth_date")]
        public string? birth_date { set; get; } //(dd/MM/yyyy)

        [Column("client_unique_ref")]
        [ColumnName("client_unique_ref")]
        public int client_unique_ref { set; get; }

        [Column("idCountry")]
        [ColumnName("idCountry")]
        public string? idCountry { get; set; }

        [Column("idState")]
        [ColumnName("idState")]
        public string? idState { get; set; }

        [Column("idLga")]
        [ColumnName("idLga")]
        public string? idLga { get; set; }

        [Column("channelid")]
        [ColumnName("channelid")]
        public int Channelid { get; set; }

        [Column("title")]
        [ColumnName("title")]
        public string? title { get; set; }
        //M or F
        [Column("gender")]
        [ColumnName("gender")]
        public string? gender { get; set; }

        [Column("marital_status")]
        [ColumnName("marital_status")]
        public string? maritalStatus { get; set; }

        [Column("maiden_name")]
        [ColumnName("maiden_name")]
        public string? maidenName { get; set; }

        [Column("idreligion")]
        [ColumnName("idreligion")]
        public int idReligion { get; set; }

        [Column("occupationId")]
        [ColumnName("occupationId")]
        public int occupationId { get; set; }

        [Column("sourceOfFund")]
        [ColumnName("sourceOfFund")]
        public string? sourceOfFund { get; set; }

        [Column("employerCode")]
        [ColumnName("employerCode")]
        public string? employerCode { get; set; }

        [Column("created_at")]
        [ColumnName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? CreatedOn { get; set; }

        [Column("deviceId")]
        [ColumnName("deviceId")]
        public string? DeviceId { get; set; }

        [Column("devicename")]
        [ColumnName("devicename")]
        public string? Devicename { get; set; }

        [Column("password")]
        [ColumnName("password")]
        public string? Password { get; set; }

        [Column("transpin")]
        [ColumnName("transpin")]
        public string? transpin { get; set; }
    }
}
