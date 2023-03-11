using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEstoque.Models;

namespace WebApiEstoque.Repositorios.Interface
{
    public interface IProdutosRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosProdutos();
        Task<ProdutoModel> BuscarPorId(int id);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);
        Task<bool> Apagar(int id);    

    }
}
