using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace entity_course
{
    internal class ProdutoDAO : IDisposable
    {
        private MySqlConnection conexao;

        public ProdutoDAO()
        {
            this.conexao = new MySqlConnection("server=127.0.0.1;user id=admin;password=123456;port=3306;database=db;");
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        internal void Adicionar(Produto p)
        {
            try
            {
                var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Produtos (Nome, Categoria, Preco) VALUES (@nome, @categoria, @preco)";

                var paramNome = new MySqlParameter("nome", p.Nome);
                insertCmd.Parameters.Add(paramNome);

                var paramCategoria = new MySqlParameter("categoria", p.Categoria);
                insertCmd.Parameters.Add(paramCategoria);

                var paramPreco = new MySqlParameter("preco", p.Preco);
                insertCmd.Parameters.Add(paramPreco);

                insertCmd.ExecuteNonQuery();
            } catch (MySqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal void Atualizar(Produto p)
        {
            try
            {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Produtos SET Nome = @nome, Categoria = @categoria, Preco = @preco WHERE Id = @id";

                var paramNome = new MySqlParameter("nome", p.Nome);
                var paramCategoria = new MySqlParameter("categoria", p.Categoria);
                var paramPreco = new MySqlParameter("preco", p.Preco);
                var paramId = new MySqlParameter("id", p.Id);
                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramCategoria);
                updateCmd.Parameters.Add(paramPreco);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            } catch (MySqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal void Remover(Produto p)
        {
            try
            {
                var deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Produtos WHERE Id = @id";

                var paramId = new MySqlParameter("id", p.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            } catch(MySqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal IList<Produto> Produtos()
        {
            var lista = new List<Produto>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Produtos";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Produto p = new Produto();
                p.Id = Convert.ToInt32(resultado["Id"]);
                p.Nome = Convert.ToString(resultado["Nome"]);
                p.Categoria = Convert.ToString(resultado["Categoria"]);
                p.Preco = Convert.ToDouble(resultado["Preco"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}