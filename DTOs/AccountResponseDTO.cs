namespace APIsprint.DTOs.AccountDTOs
{
    public class AccountResponseDTO
    {
        public int account_id { get; set; }

        public string account_type { get; set; }

        public decimal balance { get; set; }

        public decimal credit { get; set; }

        public string email { get; set; }

        public int person_id { get; set; }
    }
}