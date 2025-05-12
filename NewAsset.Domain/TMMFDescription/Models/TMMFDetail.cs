using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Domain.TMMFDescription.Models
{
    [Table("TMMF")]
    public class TMMFDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("abouttmmf")]
        public string AboutTMMF { get; set; }

        [Column("managementfee")]
        public string ManagementFee { set; get; }

        [Column("howitworks")]
        public string HowItWorks { set; get; }

        [Column("yeartildate")]
        public string yearTilDate { set; get; }

        [Column("productname")]
        public string ProductName { set; get; }

        [Column("offerprice")]
        public string OfferPrice { set; get; }

        [Column("bidprice")]
        public string BidPrice { set; get; }

        [Column("suitability")]
        public string Suitability { set; get; }


        [Column("productby")]
        public string ProductBy { set; get; }

        [Column("incomedistribution")]
        public string IncomeDistribution { set; get; }

        [Column("historicalperformance")]
        public string HistoricalPerformance { set; get; }

        [Column("createdon")]
        public DateTime? CreatedOn { set; get; }

        [Column("updatedon")]
        public DateTime? UpdatedOn { set; get; }
    }
}
