using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanches_Mac.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategotiaId { get; set; }
        [StringLength(50, ErrorMessage="O tamanho máximo é 50 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(150, ErrorMessage = "O tamanho máximo é 50 caracteres")]
        [Required(ErrorMessage = "Informe a Descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        /*Definir um relacionamento de um para muitos com Lanche*/
        public List<Lanche> Lanches { get; set; }
    }
}
