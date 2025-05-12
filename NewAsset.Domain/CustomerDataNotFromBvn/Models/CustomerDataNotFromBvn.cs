namespace NewAsset.Domain.CustomerDataNotFromBvn.Models
{
    [Table("asset_capital_insurance_custdatanotfrombvn")]
    [Index(nameof(UserId), nameof(UserName), Name = "Registration_UserName_UserId")]
    public class CustomerDataNotFromBvn:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }

        [Column("channelId")]
        [ColumnName("channelId")]
        public int ChannelId { get; set; }

        [Column("user_id")]
        [ColumnName("UserId")]
        public long UserId { get; set; }

        [Column("username")]
        [ColumnName("UserName")]
        public string? UserName { get; set; }

        [Column("regid")]
        [ColumnName("RegId")]
        public int RegId { get; set; }


        [Column("phonenumber")]
        [ColumnName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Column("address")]
        [ColumnName("Address")]
        public string? Address { get; set; }

        [Column("email")]
        [ColumnName("Email")]
        public string? Email { get; set; }

        [Column("phonenumberfrombvn")]
        [ColumnName("PhoneNumberNotFromBvn")]
        public string? PhoneNumberNotFromBvn { get; set; }

        [Column("user_type")]
        [ColumnName("UserType")]
        public string? UserType { get; set; }

        [Column("created_at")]
        [ColumnName("created_at")]
        public DateTime? created_at { get; set; }

        [Column("createdon")]
        [ColumnName("CreatedOn")]
        public DateTime? CreatedOn { get; set; }
        [NotMapped]
        public string Id
        {
            get => id.ToString();
            set => id = long.TryParse(value, out var result) ? result : id;
        }
    }
}
