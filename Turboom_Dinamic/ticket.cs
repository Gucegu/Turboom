using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turboom_Dinamic.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdTicket")]
        public int IdTicket { get; set; }

        // Relacionamentos
        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [Column("IdAgente")]
        public int? IdAgente { get; set; }

        [Column("IdProblema")]
        public int? IdProblema { get; set; }

        // Dados do ticket
        [Column("Titulo")]
        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Column("Descricao")]
        [Required]
        public string Descricao { get; set; }

        [Column("Status")]
        [StringLength(50)]
        public string Status { get; set; } = "Aberto";

        [Column("Prioridade")]
        [StringLength(20)]
        public string Prioridade { get; set; } = "Normal";

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("DataFechamento")]
        public DateTime? DataFechamento { get; set; }

        // Propriedades de navegação
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("IdAgente")]
        public virtual Agente? Agente { get; set; }

        [ForeignKey("IdProblema")]
        public virtual Problema? Problema { get; set; }
    }
}