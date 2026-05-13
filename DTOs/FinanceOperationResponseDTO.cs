namespace APIsprint.DTOs.FinanceOperationDTOs
{
    public class FinanceOperationResponseDTO
    {
        public int transation_id { get; set; }

        public string transation_type { get; set; }

        public decimal transation_value { get; set; }

        public DateTime created_at { get; set; }

        public int account_id { get; set; }

        public int? card_id { get; set; }
    }
}