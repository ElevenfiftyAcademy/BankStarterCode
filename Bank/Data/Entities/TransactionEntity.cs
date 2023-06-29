using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Data.Entities;
public class TransactionEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public double Amount { get; set; }

    [Range(0, 1)]
    public TransactionType Type { get; set; }

    [ForeignKey(nameof(Account))]
    public int AccountNumber { get; set; }
    public AccountEntity Account { get; set; } = null!;
}

public enum TransactionType { Deposit = 0, Withdrawal = 1 }
