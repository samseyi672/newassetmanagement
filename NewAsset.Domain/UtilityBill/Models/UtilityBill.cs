

namespace NewAsset.Domain.UtilityBill.Models
{
    [Table("asset_capital_insurance_utilitybill")]
    public class UtilityBill:IDbEntity
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
        [ColumnName("UserName")]
        public string? UserName { get; set; }
        [ColumnName("UserType")]
        public string? UserType { get; set; }
        [ColumnName("Filepath")]
        public string? Filepath { get; set; }
        [ColumnName("inititated")]
        public int inititated { get; set; }  // 0 for new entry,1 for initiated

        [ColumnName("approvalstatus")]
        public bool approvalstatus { get; set; } //false for new entry, true for approved

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? CreatedOn { get; set; }
    }
}
