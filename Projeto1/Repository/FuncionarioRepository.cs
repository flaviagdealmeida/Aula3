using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

using Projeto1.Entity;
namespace Projeto1.Repository
{
    public class FuncionarioRepository
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader dr;

        //conexao com o caminho do arquivo
        private string connectionString;

        //ctor + 2x tab
        public FuncionarioRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["AULA"].ConnectionString;
        }

        // inserir

        public void Inserir(Funcionario funcionario)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();//abrir conexao

                //insert
                string query = "insert into Funcionario(Nome, Salario, DataAdmissao) "
                    + "values (@Nome, @Salario, @DataAdmissao)";

                //executar
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                cmd.Parameters.AddWithValue("@DataAdmissao", funcionario.DataAdmissao);

                cmd.ExecuteNonQuery();

            }

        }

        public void Atualizar(Funcionario funcionario)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();//abrir conexao

                //Atualizar
                string query = "update Funcionario set Nome=@Nome, Salario=@Salario, DataAdmissao=@DataAdmissao "
                    + "where IdFuncionario = IdFuncionario";

                //executar
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
                cmd.Parameters.AddWithValue("@DataAdmissao", funcionario.DataAdmissao);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionario.IdFuncionario);

                cmd.ExecuteNonQuery();

            }

        }


        public void Excluir(int idFuncionario)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();//abrir conexao

                //Excluir
                string query = "delete from Funcionario where IdFuncionario = @IdFuncionario";

                //executar
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdFuncionario", idFuncionario);

                cmd.ExecuteNonQuery();

            }

        }

        public List<Funcionario> ObterTodos()
        {

            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();//abrir conexao
                string query = "select * from Funcionario";

                cmd = new SqlCommand(query, conn);
                 dr = cmd.ExecuteReader();

                List<Funcionario> lista = new List<Funcionario>();
                while (dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                    funcionario.Nome = Convert.ToString(dr["Nome"]); ;
                    funcionario.Salario = Convert.ToDecimal(dr["Salario"]); ;
                    funcionario.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]); ;

                    lista.Add(funcionario);
                }

                return lista;

            }

        }


        public Funcionario ObterPorId(int idFuncionario)
        {

            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();//abrir conexao
                string query = "select * from Funcionario where IdFuncionario = @IdFuncionario";

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdFuncionario", idFuncionario);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.IdFuncionario = Convert.ToInt32(dr["IdFuncionario"]);
                    funcionario.Nome = Convert.ToString(dr["Nome"]); ;
                    funcionario.Salario = Convert.ToDecimal(dr["Salario"]); ;
                    funcionario.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]); ;

                    return funcionario;
    
                }
                else
                {
                    return null;
                }


            }

        }
    }
}
