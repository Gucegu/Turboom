using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turboom_Dinamic.Models
{
    [Table("MENSAGENS_TICKET")]
    public class Mensagem
    {
        [Key]
        [Column("IDMensagem")]
        public int IDMensagem { get; set; }

        [Column("IDTicket")]
        public int IDTicket { get; set; }

        [Column("IDCliente")]
        public int IDCliente { get; set; }

        [Column("Mensagem")]
        [Required]
        [StringLength(2000)]
        public string Texto { get; set; }

        [Column("DataEnvio")]
        public DateTime DataEnvio { get; set; } = DateTime.Now;

        [Column("EhInterno")]
        public bool EhInterno { get; set; } = false;

        // Propriedades de navegação
        [ForeignKey("IDTicket")]
        public virtual Ticket? Ticket { get; set; }

        [ForeignKey("IDCliente")]
        public virtual Cliente? Cliente { get; set; }
    }
}