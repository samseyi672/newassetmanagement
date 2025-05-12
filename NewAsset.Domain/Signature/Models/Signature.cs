
namespace NewAsset.Domain.Signature.Models
{
    [Table("asset_capital_insurance_signature")]
    public class Signature:IDbEntity
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
        [ColumnName("UserName")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [ColumnName("UserType")]
        public string UserType { get; set; }=string.Empty;
        [Required]
        [ColumnName("Filepath")]
        public string Filepath { get; set; }=string.Empty ;
        [ColumnName("inititated")]
        public int inititated { get; set; }  // 0 for new entry,1 for initiated
        [ColumnName("approvalstatus")]
        public bool approvalstatus { get; set; } //false for new entry, true for approved

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? CreatedOn { get; set; }
    }
}






































