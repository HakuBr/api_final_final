using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.FinanceOperationDTOs
{
    public class TransferDTO
    {
        [Required]
        public int sender_account_id { get; set; }

        [Required]
        public int receiver_account_id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal transation_value { get; set; }
    }
}