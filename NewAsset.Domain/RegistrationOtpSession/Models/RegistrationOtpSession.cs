
namespace NewAsset.Domain.RegistrationOtpSession.Models
{
    [Table("asset_capital_insurance_registration_otp_session")]
    public class RegistrationOtpSession:IDbEntity
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

        [Column("created_at")]
        [ColumnName("created_at")]
        public DateTime? createdAt { get; set; }

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? CreatedOn { get; set; }
        [Required]
        [Column("user_type")]
        [ColumnName("user_type")]
        public string UserType { get; set; } = string.Empty;

        [Column("session")]
        [Required]
        [ColumnName("session")]
        public string Session { get; set; } = string.Empty;

        [Column("otp")]
        [ColumnName("otp")]
        public string? Otp { get; set; }

        [Column("otp_type")]
        [ColumnName("otp_type")]
        public int OtpType { get; set; }

        [Column("status")]
        [ColumnName("status")]
        public int status { get; set; }

        [Column("bvn")]
        [ColumnName("bvn")]
        public string bvn { get; set; }
    }

}
