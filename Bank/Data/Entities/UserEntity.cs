using System.ComponentModel.DataAnnotations;

namespace Bank.Data.Entities;
public class UserEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    public virtual List<AccountEntity> Accounts { get; set; } = new();
}
