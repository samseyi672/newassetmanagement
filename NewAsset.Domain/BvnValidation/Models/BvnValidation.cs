
namespace NewAsset.Domain.BvnValidation.Models
{

    [Table("asset_capital_insurance_bvn_validation")]
    public sealed class BvnValidation:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        [PrimaryKey]
        [ColumnName("ID")]
        public long ID { get; set; }
        [NotMapped]
        public string Id
        {
            get => ID.ToString();
            set => ID = long.TryParse(value, out var result) ? result : ID;
        }
        [ColumnName("BVN")]
        public string? BVN { get; set; }
        [ColumnName("PHONENUMBER")]
        public string? PHONENUMBER { get; set; }
        [ColumnName("PHONENUMBER2")]
        public string? PHONENUMBER2 { get; set; }
        [ColumnName("EMAIL")]
        public string? EMAIL { get; set; }
        [ColumnName("GENDER")]
        public string? GENDER { get; set; }
        [ColumnName("LgaResidence")]
        public string? LgaResidence { get; set; }
        [ColumnName("LgaOrigin")]
        public string? LgaOrigin { get; set; }
        [ColumnName("MARITALSTATUS")]
        public string? MARITALSTATUS { get; set; }
        [ColumnName("NATIONALITY")]
        public string? NATIONALITY { get; set; }
        [ColumnName("RESIDENTIALADDRESS")]
        public string? RESIDENTIALADDRESS { get; set; }
        [ColumnName("STATEORIGIN")]
        public string? STATEORIGIN { get; set; }
        [ColumnName("StateResidence")]
        public string? StateResidence { get; set; }
        [ColumnName("DateCreated")]
        public DateTime? DateCreated { get; set; }
        [ColumnName("DOB")]
        public DateTime? DOB { get; set; }
        [ColumnName("FIRSTNAME")]
        public string? FIRSTNAME { get; set; }
        [ColumnName("MIDDLENAME")]
        public string? MIDDLENAME { get; set; }
        [ColumnName("LASTNAME")]
        public string? LASTNAME { get; set; }
    }
}
