namespace APIsprint.DTOs.CardDTOs
{
    public class CardResponseDTO
    {
        public int card_id { get; set; }

        public string card_type { get; set; }

        public decimal card_limit { get; set; }

        public DateTime expiration_date { get; set; }

        public int account_id { get; set; }
    }
}