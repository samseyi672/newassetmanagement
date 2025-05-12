
namespace NewAsset.Domain.RegistrationSession.Models
{
    [Table("asset_capital_insurance_reg_session")]
    public class RegistrationSession:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }

        [Column("user_id")]
        [Required]
        [ColumnName("user_id")]
        public long UserId { get; set; }

        [NotMapped]
        public string Id
        {
            get => id.ToString();
            set => id = long.TryParse(value, out var result) ? result : id;
        }

        [Column("session")]
        [Required]
        [ColumnName("session")]
        public string Session { get; set; }=string.Empty;

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? CreatedOn { get; set; }

        [Column("status")]
        [ColumnName("status")]
        public int Status { get; set; }

        [Column("channelId")]
        [ColumnName("channelId")]
        public int ChannelId { get; set; }

        [Column("reg_id")]
        [ColumnName("reg_id")]
        public int RegId { get; set; }

        [Column("user_type")]
        [ColumnName("user_type")]
        public string UserType { get; set; }
    }
}
