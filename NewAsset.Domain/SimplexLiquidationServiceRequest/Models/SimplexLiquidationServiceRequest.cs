
namespace NewAsset.Domain.SimplexLiquidationServiceRequest.Models
{
    [Table("asset_mutualfundliquidation")]
    public class SimplexLiquidationServiceRequest:IDbEntity
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
        [Required]
        [ColumnName("UserType")]
        public string UserType { set; get; } = string.Empty;
        [ColumnName("Amount")]
        public decimal Amount { set; get; }
        [ColumnName("LiquidationAmount")]
        public decimal LiquidationAmount { set; get; }
        [Required]
        [ColumnName("UserName")]
        public string UserName { set; get; } = string.Empty;
        [Required]
        [ColumnName("RedemptionAccount")]
        public string RedemptionAccount { set; get; } = string.Empty;
        // public bool PartialOrFull { set; get; }
        [ColumnName("PartialOrFull")]
        public string? PartialOrFull { set; get; } //FULL_LIQUIDATION,PARTIAL_LIQUIDATION
        [ColumnName("BankName")]
        public string? BankName { set; get; }
        [ColumnName("InvestmentId")]
        public string? InvestmentId { set; get; }
        [ColumnName("ApprovalStatus")]
        public bool ApprovalStatus { set; get; }
        [ColumnName("Stage")]
        public string Stage { set; get; }  //PROCESSING,APPROVED
        [ColumnName("CreatedAt")]
        public DateTime? CreatedAt { set; get; }
        [ColumnName("UpdatedAt")]
        public DateTime? UpdatedAt { set; get; }
    }
}
