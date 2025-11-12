using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Turboom_Dinamic.Models
{
    [Table("PRODUTO")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDproduto")]
        public int IDproduto { get; set; }

        [Column("NomeProduto")]
        [Required]
        [StringLength(30)]
        public string NomeProduto { get; set; }

        [Column("MoodeloProduto")]
        [Required]
        [StringLength(30)]
        public string MoodeloProduto { get; set; }

        [Column("DescricaoProduto")]
        [StringLength(320)]
        public string DescricaoProduto { get; set; }
    }
}