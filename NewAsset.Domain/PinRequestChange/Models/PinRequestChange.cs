
namespace NewAsset.Domain.PinRequestChange.Models
{
    [Table("asset_capital_insurance_pinrequestchange")]
    public class PinRequestChange:IDbEntity
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

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? createdon { get; set; }

        [Column("user_type")]
        [Required]
        [ColumnName("user_type")]
        public string? UserType { get; set; } = string.Empty;

        [Column("request")]
        [ColumnName("request")]
        public string? Comment { get; set; }

        [Column("approvalstatus")]
        [ColumnName("approvalstatus")]
        public bool ApprovalStatus { get; set; } = false;

        [Column("initiated")]
        [ColumnName("initiated")]
        public bool initiated { get; set; } = false;

        [Column("userid")]
        [ColumnName("UserId")]
        public long UserId { get; set; }

    }
}
