using Core.Data.Contracts;
using Core.Data.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Core.Data.Repository
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        IConfiguration _configuration;

        public ContatoRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("ContatoConnection").Value;
            return connection;
        }


        public ContatoItem Add(ContatoItem item)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Contatos(NOME, EMAIL, TELEFONE) VALUES (@NOME, @EMAIL, @TELEFONE)" +
                        "SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    count = con.Execute(query, item);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return item;
        }

        public List<ContatoItem> GetContato()
        {
            var connectionString = this.GetConnection();
            List<ContatoItem> autenticacaoItens = new List<ContatoItem>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Contatos";
                    autenticacaoItens = con.Query<ContatoItem>(query).ToList();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return autenticacaoItens;
            }
        }

        public ContatoItem Get(long id)
        {
            var connectionString = this.GetConnection();
            ContatoItem autenticacaoItem = new ContatoItem();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Contatos  WHERE ID=" + id;
                    autenticacaoItem = con.Query<ContatoItem>(query).FirstOrDefault();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return autenticacaoItem;
            }
        }

        public void Delete(long id)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Contatos WHERE ID =" + id;
                    count = con.Execute(query);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public ContatoItem Update(ContatoItem item)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Contatos SET NOME = @NOME, EMAIL = @EMAIL, TELEFONE = @TELEFONE WHERE ID = @id";
                    count = con.Execute(query, item);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return item;
            }
        }
    }
}

