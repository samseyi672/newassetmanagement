using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Domain.OtpSession.Models
{
    [Table("asset_capital_insurance_otp_session")]
    public class OtpSession:IDbEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [PrimaryKey]
        [ColumnName("id")]
        public long id { get; set; }

        [Column("user_id")]
        [ColumnName("user_id")]
        public long UserId { get; set; }

        [Column("created_at")]
        [ColumnName("created_at")]
        public DateTime? createdAt { get; set; }

        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? CreatedOn { get; set; }

        [Column("user_type")]
        [ColumnName("user_type")]
        public string UserType { get; set; }

        [Column("session")]
        [ColumnName("session")]
        public string Session { get; set; }

        [Column("otp")]
        [ColumnName("otp")]
        public string Otp { get; set; }

        [Column("otp_type")]
        [ColumnName("otp_type")]
        public int OtpType { get; set; }

        [Column("status")]
        [ColumnName("status")]
        public int status { get; set; }

        [Column("ucid")]
        [ColumnName("ucid")]
        public int ucid { get; set; }
        [NotMapped]
        public string Id
        {
            get => id.ToString();
            set => id = long.TryParse(value, out var result) ? result : id;
        }
    }
}
