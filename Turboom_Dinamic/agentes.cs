using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turboom_Dinamic.Models
{
    [Table("Agente")]
    public class Agente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdAgente")]
        public int IdAgente { get; set; }

        [Column("Nome")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("Email")]
        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Column("SenhaHash")]
        [Required]
        [StringLength(255)]
        public string SenhaHash { get; set; }

        // Chave estrangeira para Funcao
        [Column("IdFuncao")]
        public int IdFuncao { get; set; }

        // Propriedade de navegação
        [ForeignKey("IdFuncao")]
        public virtual Funcao Funcao { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}