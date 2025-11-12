using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turboom_Dinamic.Models
{
    [Table("Funcao")]
    public class Funcao
    {
        [Key]
        [Column("IdFuncao")]
        public int IdFuncao { get; set; }

        [Column("NomeFuncao")]
        [Required]
        [StringLength(50)]
        public string NomeFuncao { get; set; }
    }
}