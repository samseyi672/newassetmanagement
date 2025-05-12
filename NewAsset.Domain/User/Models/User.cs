
namespace NewAsset.Domain.User.Models
{
    [Table("asset_capital_insurance_user")]
    public class User:IDbEntity
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

        [Column("channelId")]
        [ColumnName("channelId")]
        public int ChannelId { get; set; }

        [Column("first_name")]
        [ColumnName("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        [ColumnName("last_name")]
        public string LastName { get; set; }

        [Column("username")]
        [ColumnName("username")]
        public string UserName { get; set; }

        [Column("email")]
        [ColumnName("email")]
        public string Email { get; set; }

        [Column("password")]
        [ColumnName("password")]
        public string Password { get; set; }

        [Column("phonenumber")]
        [ColumnName("phonenumber")]
        public string PhoneNumber { get; set; }

        [Column("picture")]
        [ColumnName("picture")]
        public string ProfilePic { get; set; }

        [Column("status")]
        [ColumnName("status")]
        public int Status { get; set; } //1 for active , 2 for inactive

        [Column("bvn")]
        [ColumnName("bvn")]
        public string Bvn { get; set; }

        [Column("nin")]
        [ColumnName("nin")]
        public string NIN { get; set; }

        [Column("address")]
        [ColumnName("address")]
        public string Address { get; set; }

        [Column("created_at")]
        [ColumnName("created_at")]
        public DateTime? createdAt { get; set; }

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? createdon { get; set; }

        [Column("user_type")]
        [ColumnName("user_type")]
        public string UserType { get; set; }

        [Column("client_unique_ref")]
        [ColumnName("client_unique_ref")]
        public long ClientUniqueRef { get; set; }

        [Column("customerid")]
        [ColumnName("customerid")]
        public string Customerid { get; set; }

    }
}
