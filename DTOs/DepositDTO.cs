using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.FinanceOperationDTOs
{
    public class DepositDTO
    {
        [Required]
        public int account_id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal transation_value { get; set; }
    }
}