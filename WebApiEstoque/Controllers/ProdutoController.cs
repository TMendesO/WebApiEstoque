using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using WebApiEstoque.Models;
using WebApiEstoque.Repositorios.Interface;

namespace WebApiEstoque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController:ControllerBase
    {
        private readonly IProdutosRepositorio _produtosRepositorio;
        public ProdutoController(IProdutosRepositorio produtosRepositorio)
        {
            _produtosRepositorio = produtosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
          List<ProdutoModel> produtos =  await  _produtosRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ProdutoModel produto = await _produtosRepositorio.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost, Authorize(Roles = "administrator")]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody]ProdutoModel produtoModel)
        {
           ProdutoModel produto = await _produtosRepositorio.Adicionar(produtoModel);
            return Ok(produto);
        }

        [HttpPut("{id}"), Authorize(Roles = "administrator")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.Id = id;
            ProdutoModel produto = await _produtosRepositorio.Atualizar(produtoModel,id);
            return Ok(produto);
        }

        [HttpDelete("{id}"), Authorize(Roles = "administrator")]
        public async Task<ActionResult<ProdutoModel>> Apagar(int id)
        {
          bool apagado = await _produtosRepositorio.Apagar(id);
            return Ok(apagado);
        }

    }
}
