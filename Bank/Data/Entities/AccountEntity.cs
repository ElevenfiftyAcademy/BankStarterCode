using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Data.Entities;
public class AccountEntity
{
    [Key]
    public int AccountNumber { get; set; }

    [Required, MaxLength(50)]
    public string Label { get; set; } = null!;

    [ForeignKey(nameof(AccountHolder))]
    public int AccountHolderId { get; set; }
    public UserEntity AccountHolder { get; set; } = null!;

    public virtual List<TransactionEntity> Transactions { get; set; } = new();

    public double TotalValue
    {
        get
        {
            int GetModifier(TransactionType type) => type switch
            {
                TransactionType.Withdrawal => -1,
                _ => 1
            };

            return Transactions.Select(t => t.Amount * GetModifier(t.Type)).Sum();
        }
    }
}
