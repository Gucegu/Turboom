using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turboom_Dinamic.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Column("Nome")]
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Column("Email")]
        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        [Column("Telefone")]
        [StringLength(20)]
        public string? Telefone { get; set; }

        [Column("SenhaHash")]
        [StringLength(255)]
        public string? SenhaHash { get; set; } = string.Empty;

    }
}