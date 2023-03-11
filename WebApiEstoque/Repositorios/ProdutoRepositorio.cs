using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiEstoque.Models;
using WebApiEstoque.Data;
using WebApiEstoque.Repositorios.Interface;

namespace WebApiEstoque.Repositorios
{
    public class ProdutoRepositorio : IProdutosRepositorio
    {
        private readonly ProdutosDbContext _dbContext;
        public ProdutoRepositorio(ProdutosDbContext produtoDbContext)
        {
            _dbContext = produtoDbContext;
        }
        public async Task<ProdutoModel> BuscarPorId(int id)
        {
           return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
           ProdutoModel produtoPorId = await BuscarPorId(id) ?? throw new Exception($"Produto para o ID:{id} não foi encontrado");
            produtoPorId.Nome = produto.Nome;
            produtoPorId.Modelo = produto.Modelo;
            produtoPorId.Cor = produto.Cor;
            produtoPorId.Quantidade = produto.Quantidade;
            produtoPorId.Tamanho = produto.Tamanho;
            produtoPorId.ImageUrl = produto.ImageUrl;

            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id) ?? throw new Exception($"Produto para o ID:{id} não foi encontrado");
            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
