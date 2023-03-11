
using System.ComponentModel.DataAnnotations;

namespace WebApiEstoque.Models
{
   
    public class ProdutoModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Cor { get; set; }
        public int Quantidade { get; set; }
        [Required]
        public string Tamanho { get; set; }
        [Url] [Required]
        public string ImageUrl { get; set; }
    }
}
