using App.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace App.Repository
{
    public class AlunoDAO
    {
        //Exemplo 1
        //private string stringConexao = ConfigurationManager.AppSettings["ConnectionString"];
        //Exemplo 2
        private string stringConexao = ConfigurationManager.ConnectionStrings["ConexaoDev"].ConnectionString;
        private IDbConnection conexao;

        public AlunoDAO()
        {
            conexao = new SqlConnection(stringConexao);
            conexao.Open();
        }

        //Retorna a lista de alunos armazenados no Data Base
        public List<AlunoDTO> ListarAlunoDB(int? id)
        {
            var listaAlunos = new List<AlunoDTO>();

            try
            {
                IDbCommand selectCmd = conexao.CreateCommand();

                if (id == null)
                    selectCmd.CommandText = "select * from Alunos";
                else
                    selectCmd.CommandText = $"select * from Alunos where id = {id}";

                IDataReader resultado = selectCmd.ExecuteReader();
                while (resultado.Read())
                {
                    var alu = new AlunoDTO
                    {
                        id = Convert.ToInt32(resultado["id"]),
                        nome = Convert.ToString(resultado["nome"]).Trim(),
                        sobrenome = Convert.ToString(resultado["sobrenome"]).Trim(),
                        telefone = Convert.ToString(resultado["telefone"]).Trim(),
                        data = Convert.ToString(resultado["data"]).Trim(),
                        ra = Convert.ToInt32(resultado["ra"])
                    };

                    listaAlunos.Add(alu);
                }

                return listaAlunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        public void InserirAlunoDB(AlunoDTO aluno)
        {
            try
            { 
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "insert into Alunos (nome, sobrenome, telefone, data, ra) values (@nome, @sobrenome, @telefone, @data, @ra)";

                IDbDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                insertCmd.Parameters.Add(paramNome);

                IDbDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                insertCmd.Parameters.Add(paramSobrenome);

                IDbDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                insertCmd.Parameters.Add(paramTelefone);

                IDbDataParameter paramData = new SqlParameter("data", aluno.data);
                insertCmd.Parameters.Add(paramData);

                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);
                insertCmd.Parameters.Add(paramRa);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void AtualizarAlunoDB(AlunoDTO aluno)
        {
            try
            {
                IDbCommand updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "update Alunos set nome = @nome, sobrenome = @sobrenome, telefone = @telefone, data = @data, ra = @ra where id = @id";

                IDbDataParameter paramNome = new SqlParameter("nome", aluno.nome);
                IDbDataParameter paramSobrenome = new SqlParameter("sobrenome", aluno.sobrenome);
                IDbDataParameter paramTelefone = new SqlParameter("telefone", aluno.telefone);
                IDbDataParameter paramData = new SqlParameter("data", aluno.data);
                IDbDataParameter paramRa = new SqlParameter("ra", aluno.ra);
                updateCmd.Parameters.Add(paramNome);
                updateCmd.Parameters.Add(paramSobrenome);
                updateCmd.Parameters.Add(paramTelefone);
                updateCmd.Parameters.Add(paramData);
                updateCmd.Parameters.Add(paramRa);

                IDbDataParameter paramId = new SqlParameter("id", aluno.id);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void DeletarAlunoDB(int id)
        {
            try
            {
                IDbCommand deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "delete from Alunos where id = @id";

                IDbDataParameter paramId = new SqlParameter("id", id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}