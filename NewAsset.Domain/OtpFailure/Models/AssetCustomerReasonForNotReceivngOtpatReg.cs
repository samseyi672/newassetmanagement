using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Domain.OtpFailure.Models
{
    [Table("asset_capital_insurance_customerissues")]
    public class AssetCustomerReasonForNotReceivngOtpatReg:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }
        [ColumnName("bvn")]
        public string? bvn { get; set; }
        [ColumnName("requestreference")]
        public string? requestreference { get; set; }
        [ColumnName("reason")]
        public string? reason { get; set; }
        [Required]
        [ColumnName("user_type")]
        public string user_type { get; set; }= string.Empty;
        [ColumnName("createdon")]
        public DateTime? createdon { get; set; }
        [NotMapped]
        public string Id
        {
            get => id.ToString();
            set => id = long.TryParse(value, out var result) ? result : id;
        }
    }
}
