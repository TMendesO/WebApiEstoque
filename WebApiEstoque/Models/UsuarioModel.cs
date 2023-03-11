
using System.ComponentModel.DataAnnotations;

namespace WebApiEstoque.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public bool? Administrador { get; set; }
    }
}
