
namespace NewAsset.Domain.CustomerDevice.Models
{
    [Table("asset_capital_insurance_customerdevice")]
    public class CustomerDevice:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }

        [Column("login_status")]
        [ColumnName("login_status")]
        public int LoginStatus { get; set; }

        [Column("username")]
        [Required]
        [ColumnName("username")]
        public string UserName { get; set; }=string.Empty;

        [Column("device")]
        [ColumnName("device")]
        public string Device { get; set; } = string.Empty;

        [Column("track_device")]
        [ColumnName("track_device")]
        public string TrackDevice { get; set; } = string.Empty;

        [Column("session")]
        [ColumnName("session")]
        public string Session { get; set; } = string.Empty;

        [Column("user_type")]
        [Required]
        [ColumnName("user_type")]
        public string UserType { get; set; } = string.Empty;

        [Column("channelId")]
        [ColumnName("channelId")]
        public int ChannelId { get; set; }

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
