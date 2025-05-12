using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Domain.PaymentNotificationOutsideOfFlutterwave.Models
{
    [Table("paymentnotificationoutsideofflutterwave")]
    public class PaymentNotificationOutsideOfFlutterwave
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long id { get; set; }
        [Required]
        public string UserType { set; get; }=string.Empty;

        public string BankName { set; get; } = string.Empty;

        public string Session { set; get; } = string.Empty;

        public string PaymentReference { set; get; } = string.Empty;

        public string UserName { set; get; } = string.Empty;

        public decimal Amount { set; get; } 

        public string AccountNumber { set; get; } = string.Empty;
    }
}
