using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Domain.UserCredentials.Models
{
    [Table("asset_capital_insurance_user_credentials")]
    public class UserCredentials:IDbEntity
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

        [Column("user_id")]
        [ColumnName("user_id")]
        public long UserId { get; set; }

        [Column("retries")]
        [ColumnName("retries")]
        public int retries { get; set; }

        [Column("credential")]
        [ColumnName("credential")]
        public string? credential { get; set; }

        [Column("credential_type")]  // type 1 for password, type 2 for  pin
        [ColumnName("credential_type")]
        public string? credentialtype { get; set; }

        [Column("created_at")]
        [ColumnName("created_at")]
        public DateTime? createdAt { get; set; }


        [Column("createdon")]
        [ColumnName("createdon")]
        public DateTime? CreatedOn { get; set; }

        [Column("user_type")]
        [ColumnName("user_type")]
        public string? UserType { get; set; }

        [Column("status")]
        [ColumnName("status")]
        public bool Status { get; set; }

        [Column("temporarypin")]
        [ColumnName("temporarypin")]
        public string? TemporaryPIn { get; set; }

        [Column("ucid")]
        [ColumnName("ucid")]
        public int ucid { get; set; }
    }
}
