using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIsprint.Models
{
    public enum FinanceOperationType
    {
        Deposito = 1,
        Saque = 2,
        Transferencia = 3,
        Pagamento = 4
    }

    [Table("tbl_Finance_Operation")]
    public class FinanceOperation
    {
        [Key]
        public int transation_id { get; set; }

        [ForeignKey("account_id")]
        public Account Account { get; set; }

        public int account_id { get; set; }

        public int? card_id { get; set; }

        [ForeignKey("card_id")]
        public Card Card { get; set; }

        [Required]
        public FinanceOperationType finance_operation_type { get; set; }

        [Required]
        public decimal transation_value { get; set; }

        public DateTime created_at { get; set; }
    }
}