
namespace NewAsset.Domain.UserSession.Models
{
    [Table("asset_capital_insurance_user_session")]
    public class UserSession:IDbEntity
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

        [Column("user_id")]
        [ColumnName("user_id")]
        public long UserId { get; set; }

        [Column("ucid")]
        [ColumnName("ucid")]
        public long ucid { get; set; }

        [Column("session")]
        [ColumnName("session")]
        public string Session { get; set; }

        [Column("created_on")]
        [ColumnName("created_on")]
        public DateTime? CreatedOn { get; set; }

        [Column("status")]
        [ColumnName("status")]
        public int Status { get; set; }

        [Column("user_type")]
        [ColumnName("user_type")]
        public string UserType { get; set; }

        [Column("channelId")]
        [ColumnName("channelId")]
        public int ChannelId { get; set; }

        [Column("last_activity")]
        [ColumnName("last_activity")]
        public DateTime? LastActivity { get; set; }
    }
}
