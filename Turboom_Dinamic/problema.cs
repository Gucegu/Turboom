using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turboom_Dinamic.Models
{
    [Table("Problema")]
    public class Problema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdProblema")]
        public int IdProblema { get; set; }

        [Column("Titulo")]
        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Column("Descricao")]
        [Required]
        public string Descricao { get; set; }

        [Column("Solucao")]
        public string Solucao { get; set; }

        [Column("DataRegistro")]
        public DateTime DataRegistro { get; set; } = DateTime.Now;
    }
}