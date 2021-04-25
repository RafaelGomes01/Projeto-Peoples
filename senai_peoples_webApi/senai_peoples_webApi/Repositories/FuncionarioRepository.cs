using senai_peoples_webApi.Domains;
using senai_peoples_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        string stringConexao = "Data Source =DESKTOP-VVNQ5LN; initial catalog=M_Peoples; integrated security =true";

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios(nome, sobrenome) VALUES (@nome, @sobrenome)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString(),
                            sobrenome = rdr[2].ToString()

                        };

                        listaFuncionarios.Add(funcionario);
                    }
                }
            }
            return listaFuncionarios;
        }

        public FuncionarioDomain BuscarPorId(int Id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios WHERE idFuncionario = @Id";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(rdr[0]),
                            nome = rdr[1].ToString(),
                            sobrenome = rdr[2].ToString()
                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }

        public void Atualizar(int id, FuncionarioDomain funcionarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @nome, Sobrenome = @sobrenome, WHERE IdFuncionario = @Id";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@nome", funcionarioAtualizado.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionarioAtualizado.sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            } 
        }

        public void Delete(int Id)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @Id";

                using(SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
