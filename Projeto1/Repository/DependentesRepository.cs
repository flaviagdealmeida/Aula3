using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using Projeto1.Entity;

namespace Projeto1.Repository
{
    public class DependentesRepository
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader dr;

        private string connectionString;

        public DependentesRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AULA"].ConnectionString;
        }


        //inserir dependentes
        public void Inserir(Dependentes dependentes)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd = new SqlCommand("SP_InserirDependentes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", dependentes.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", dependentes.DataNascimento);
                cmd.Parameters.AddWithValue("@IdFuncionario", dependentes.Funcionario.IdFuncionario);

                cmd.ExecuteNonQuery();
            }

        }

        public void Atualizar(Dependentes dependentes)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd = new SqlCommand("SP_AtualizarDependente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDependente", dependentes.IdDependentes);
                cmd.Parameters.AddWithValue("@Nome", dependentes.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", dependentes.DataNascimento);
                cmd.Parameters.AddWithValue("@IdFuncionario", dependentes.Funcionario.IdFuncionario);

                cmd.ExecuteNonQuery();
            }

        }

        public void Excluir(int IdDependentes)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                cmd = new SqlCommand("SP_ExcluirDependente", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdDependente", IdDependentes);
                
                cmd.ExecuteNonQuery();
            }

        }


        public List<Dependentes> ObterTodos()
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "select * from VW_Dependentes";

                cmd = new SqlCommand(query, conn);
                dr = cmd.ExecuteReader();

                List<Dependentes> lista = new List<Dependentes>();

                while (dr.Read())
                {
                    Dependentes dependentes = new Dependentes();
                    dependentes.Funcionario = new Funcionario();
                    
                    dependentes.IdDependentes = Convert.ToInt32(dr["idDependente"]);
                    dependentes.Nome = Convert.ToString(dr["NomeDependente"]);
                    dependentes.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                    dependentes.Funcionario.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);

                    dependentes.Funcionario.Nome = Convert.ToString(dr["NomeFuncionario"]); ;
                    dependentes.Funcionario.Salario = Convert.ToDecimal(dr["Salario"]); ;
                    dependentes.Funcionario.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]); ;

                    lista.Add(dependentes);
                }
                return lista;
            }
        }
        public Dependentes ObterTodosPorID(int IdDependente)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "select * from VW_Dependentes where IdDependente = @IdDependente";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdDependente", IdDependente);
                dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    Dependentes dependentes = new Dependentes();
                    dependentes.Funcionario = new Funcionario();

                    dependentes.IdDependentes = Convert.ToInt32(dr["idDependente"]);
                    dependentes.Nome = Convert.ToString(dr["NomeDependente"]);
                    dependentes.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                    dependentes.Funcionario.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);

                    dependentes.Funcionario.Nome = Convert.ToString(dr["NomeFuncionario"]); ;
                    dependentes.Funcionario.Salario = Convert.ToDecimal(dr["Salario"]); ;
                    dependentes.Funcionario.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]); ;

                    return dependentes;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
