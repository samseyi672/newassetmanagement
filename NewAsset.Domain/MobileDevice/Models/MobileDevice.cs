
namespace NewAsset.Domain.MobileDevice.Models
{
    [Table("asset_capital_insurance_mobile_device")]
    public class MobileDevice:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }

        [Column("device_token")]
        [ColumnName("device_token")]
        public string? DeviceToken { get; set; }

        [Column("channelId")]
        [ColumnName("channelId")]
        public int ChannelId { get; set; }

        [Column("device")]
        [ColumnName("device")]
        public string? DeviceId { get; set; }

        [Column("device_name")]
        [ColumnName("device_name")]
        public string? DeviceName { get; set; }

        [Column("user_id")]
        [ColumnName("user_id")]
        public long UserId { get; set; }

        [Column("status")]
        [ColumnName("status")]
        public int Status { get; set; }

        [Column("user_type")]
        [ColumnName("user_type")]
        public string? UserType { get; set; }

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? created_at { get; set; }
        [NotMapped]
        public string Id
        {
            get => id.ToString();
            set => id = long.TryParse(value, out var result) ? result : id;
        }

    }
}
