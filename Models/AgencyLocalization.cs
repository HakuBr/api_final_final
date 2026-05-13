using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIsprint.Models
{
    [Table("tbl_Agency_Localization")]
    public class AgencyLocalization
    {
        [Key]
        public int agency_localization_id { get; set; }

        public int agency_id { get; set; }

        [Required]
        [MaxLength(5)]
        public string agency_number_identification { get; set; }

        [Required]
        [MaxLength(40)]
        public string agency_city { get; set; }

        [Required]
        [MaxLength(40)]
        public string agency_neighbordhood { get; set; }

        [Required]
        [MaxLength(40)]
        public string agency_road { get; set; }

        public short agency_number { get; set; }

        [ForeignKey("agency_id")]
        public Agency Agency { get; set; }
    }
}