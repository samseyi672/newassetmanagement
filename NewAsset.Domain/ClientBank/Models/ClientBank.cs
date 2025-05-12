
namespace NewAsset.Domain.ClientBank.Models
{
    [Table("asset_capital_insurance_clientbank")]
    public class ClientBank:IDbEntity
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
        [ColumnName("BankId")]
        public string? BankId { get; set; }
        [ColumnName("AccountNumber")]
        public string? AccountNumber { get; set; }
        [Required]
        [ColumnName("AccountName")]
        public string AccountName { get; set; }=string.Empty;
        [Required]
        [ColumnName("UserType")]
        public string UserType { get; set; }=string.Empty ;

        [Column("createdon")]
        [ColumnName("CreatedOn")]
        public DateTime? CreatedOn { get; set; }
    }
}





