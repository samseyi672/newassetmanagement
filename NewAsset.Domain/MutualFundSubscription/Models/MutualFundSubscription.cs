
namespace NewAsset.Domain.MutualFundSubscription.Models
{
    [Table("asset_mutualfundsubscription")]
    public class MutualFundSubscription:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }
        [ColumnName("AppType")]
        public string? AppType { set; get; }
        [ColumnName("ClientUniqueRef")]
        public int ClientUniqueRef { set; get; }
        [ColumnName("PaymentReference")]
        public string? PaymentReference { set; get; }
        [ColumnName("PortfolioId")]
        public int PortfolioId { set; get; }
        [ColumnName("UserName")]
        public string? UserName { set; get; }
        [ColumnName("CreatedAt")]
        public DateTime? CreatedAt { set; get; }
        [ColumnName("PaymentChannelOptionForsubscription")]
        public string? PaymentChannelOptionForsubscription { set; get; }
        [ColumnName("Amount")]
        public decimal Amount { set; get; }
        [ColumnName("currency")]
        public string? currency { set; get; }
        [NotMapped]
        public string Id
        {
            get => id.ToString();
            set => id = long.TryParse(value, out var result) ? result : id;
        }
    }
}
