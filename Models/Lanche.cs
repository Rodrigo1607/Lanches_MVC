using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;



namespace Lanches_Mac.Models
{
    [Table("Lanche")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        /*Data Annotation*/
        [Required(ErrorMessage="O nome deve ser informado")]/*Obriga informar o campo*/
        [Display(Name ="Nome do lanche")] /*Exibe o nome*/
        [StringLength(80, MinimumLength =10, ErrorMessage = "O {0} deve ter no Máximo {1} e no Minimo {2} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]/*Obriga informar o campo*/
        [Display(Name = "Descrição Curta")] /*Exibe o nome*/
        [StringLength(200, MinimumLength = 20, ErrorMessage = "O {0} deve ter no Máximo {1} e no Minimo {2} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "O nome deve ser informado")]/*Obriga informar o campo*/
        [Display(Name = "Descrição Detalhada")] /*Exibe o nome*/
        [StringLength(200, MinimumLength = 20, ErrorMessage = "O {0} deve ter no Máximo {1} e no Minimo {2} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informe o preço do lanche")]/*Obriga informar o campo*/
        [Display(Name = "Descrição Detalhada")] /*Exibe o nome*/
        [Column(TypeName="decimal(10,2)")]
        [Range(1,999.99, ErrorMessage="O preço deve ser entre 1 e 999,99" )]
        public decimal Preco {  get; set; }
        
        [Display(Name = "Caminho imagem Normal")] /*Exibe o nome*/
        [StringLength(200, ErrorMessage = "O {0} deve ter no Máximo {1} caracteres")]
        public string ImagemUrl {  get; set; }

        [Display(Name = "Caminho imagem minatura")] /*Exibe o nome*/
        [StringLength(200, ErrorMessage = "O {0} deve ter no Máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set;}

        [Display(Name ="Preferido?")]
        public bool ISLanchePreferido {  get; set; }

        [Display(Name = "Estoque")]
        public bool EmEstoque {  get; set; }

        /* Definir um relacionamento entre Lanche e Categoria*/
        public int CategoriaId {  get; set; }/* mapeado como chave estrangeira*/
        public virtual Categoria Categoria { get; set; }

    }
}
