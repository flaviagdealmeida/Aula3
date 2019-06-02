using Projeto1.Entity;
using Projeto1.Repository;
using System;
using System.Collections.Generic;

namespace Projeto1
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("\n .:: SISTEMA DE GESTÃO DE PESSOAL ::. \n");
                Console.WriteLine("(1) Gerenciar Funcionário");
                Console.WriteLine("(2) Gerenciar Dependentes");

                Console.WriteLine("\nEscolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());


                switch (opcao)
                {
                    case 1:
                        ExecutarMenuFuncionarios();
                        break;

                    case 2:
                        ExecutarMenuDependentes();
                        break;

                    default:
                        Console.WriteLine("Verifique valor desejado!");
                        break;
                }
                ExecutarRecursividade(args);
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }



        }

        private static void ExecutarMenuFuncionarios()
        {
            Console.WriteLine("\n .:: CONTROLE DE FUNCIONARIOS ::. \n");
            Console.WriteLine("(1) Cadastrar Funcionário");
            Console.WriteLine("(2) Atualizar Funcionário");
            Console.WriteLine("(3) Excluir Funcionário");
            Console.WriteLine("(4) Consultar todos os Funcionário");
            Console.WriteLine("(5) Consultar Funcionário por ID");

            FuncionarioRepository repository = new FuncionarioRepository();

            try
            {
                Console.Write("\nInforme a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarFuncionario(repository);

                        break;

                    case 2:
                        AtualizarFuncionario(repository);
                        break;

                    case 3:
                        ExcluirFuncionario(repository);
                        break;
                    case 4:
                        ConsultarFuncionarios(repository);
                        break;

                    case 5:
                        ConsultarFuncionarioID(repository);
                        break;

                    default:
                        Console.WriteLine("Verifique valor desejado!");
                        break;
                }

                
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }


        private static void ExecutarMenuDependentes()
        {
            Console.WriteLine("\n .:: CONTROLE DE DEPENDENTES ::. \n");
            Console.WriteLine("(1) Cadastrar Dependentes");
            Console.WriteLine("(2) Atualizar Dependentes");
            Console.WriteLine("(3) Excluir Dependentes");
            Console.WriteLine("(4) Consultar todos os Dependentes");
            Console.WriteLine("(5) Consultar todos os Dependentes por ID");


            DependentesRepository dependentesRepository = new DependentesRepository();
             
            try
            {
                Console.Write("\nInforme a opção desejada: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarDependentes(dependentesRepository);

                        break;

                    case 2:
                        AtualizarDependentes(dependentesRepository);
                        break;

                    case 3:
                        ExcluirDependentes(dependentesRepository);
                        break;
                    case 4:
                        ConsultarDependentes(dependentesRepository);
                        break;
                    case 5:
                        ConsultarDependentesID(dependentesRepository);
                        break;

                    default:
                        Console.WriteLine("Verifique valor desejado!");
                        break;
                }

                
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
        }

        private static void ExecutarRecursividade(string[] args)
        {
            Console.WriteLine("Deseja realizar outra operação? S|N):");
            string escolha = Console.ReadLine();

            if (escolha.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.WriteLine("Bye!");
            }
        }

        private static void CadastrarFuncionario(FuncionarioRepository repository)
        {
            Console.WriteLine("\n .:: CADASTRO DE FUNCIONARIOS ::. \n");
            Funcionario funcionario = new Funcionario();

            Console.Write("Nome do Funcionario..............:");
            funcionario.Nome = Console.ReadLine();

            Console.Write("Salario do Funcionario...........:");
            funcionario.Salario = decimal.Parse(Console.ReadLine());

            Console.Write("Data de Admissao do Funcionario..:");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

            repository.Inserir(funcionario);

            Console.WriteLine("Funcionario cadastrado com sucesso!");
            
        }

        private static void AtualizarFuncionario(FuncionarioRepository repository)
        {
            Console.WriteLine("\n .:: ATUALIZACAO DE FUNCIONARIOS ::. \n");
            Funcionario funcionario = new Funcionario();

            Console.Write("Informe o ID do Funcionario..............:");
            funcionario.IdFuncionario = int.Parse(Console.ReadLine());

            Console.Write("Nome do Funcionario..............:");
            funcionario.Nome = Console.ReadLine();

            Console.Write("Salario do Funcionario...........:");
            funcionario.Salario = decimal.Parse(Console.ReadLine());

            Console.Write("Data de Admissao do Funcionario..:");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

            repository.Atualizar(funcionario);

            Console.WriteLine("Funcionario Atualizado com sucesso!");
           
        }

        private static void ExcluirFuncionario(FuncionarioRepository repository)
        {
            Console.WriteLine("\n .:: EXCLUIR FUNCIONARIOS ::. \n");

            Console.Write("Informe o ID do Funcionario..............:");
            int IdFuncionario = int.Parse(Console.ReadLine());

            repository.Excluir(IdFuncionario);

            Console.WriteLine("Funcionario Excluído com sucesso!");

        }

        private static void ConsultarFuncionarios(FuncionarioRepository repository)
        {

            List<Funcionario> lista = repository.ObterTodos();

            foreach (var funcionario in lista)
            {
                Console.WriteLine("\n .:: CONSULTAR FUNCIONARIOS ::. \n");
                Console.WriteLine("Id Funcionario.....:\t" + funcionario.IdFuncionario);
                Console.WriteLine("Nome...............:\t" + funcionario.Nome);
                Console.WriteLine("Salario............:\t" + funcionario.Salario);
                Console.WriteLine("Data Admissao......:\t" + funcionario.DataAdmissao);

            }

        }

        private static void ConsultarFuncionarioID(FuncionarioRepository repository)
        {
            Console.WriteLine("\n .:: CONSULTAR DE FUNCIONARIOS POR ID ::. \n");

            Console.Write("Informe o ID do Funcionario..............:");
            int IdFuncionario = int.Parse(Console.ReadLine());

            Funcionario funcionario = repository.ObterPorId(IdFuncionario);

            if (funcionario != null)
            {
                Console.WriteLine("\n .:: CONSULTAR DE FUNCIONARIOS ::. \n");
                Console.WriteLine("Id Funcionario.....:\t" + funcionario.IdFuncionario);
                Console.WriteLine("Nome...............:\t" + funcionario.Nome);

                Console.WriteLine("Salario............:\t" + funcionario.Salario);
                Console.WriteLine("Data Admissao......:\t" + funcionario.DataAdmissao.ToString("dd/mm/yyyy"));
            }
            else
            {
                Console.WriteLine("Funcionario não Localizado");

            }


        }

        private static void CadastrarDependentes(DependentesRepository dependentesRepository)
        {
            Console.WriteLine("\n .:: CADASTRO DE DEPENDENTES ::. \n");
            Dependentes dependentes = new Dependentes();
            dependentes.Funcionario = new Funcionario();

            Console.Write("Nome do Dependente ..................:");
            dependentes.Nome = Console.ReadLine();

            Console.Write("Data de Nascimento do Funcionario ..:");
            dependentes.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe o ID do Funcionario..............:");
            dependentes.Funcionario.IdFuncionario = int.Parse(Console.ReadLine());

            dependentesRepository.Inserir(dependentes);

            Console.WriteLine("Dependente cadastrado com sucesso!");
          
        }

        private static void AtualizarDependentes(DependentesRepository dependentesRepository)
        {
            Console.WriteLine("\n .:: ATUALIZACAO DE FUNCIONARIOS ::. \n");
            Dependentes dependentes = new Dependentes();
            dependentes.Funcionario = new Funcionario();

            Console.Write("Informe o ID do Dependente ........:");
            dependentes.IdDependentes = int.Parse(Console.ReadLine());

            Console.Write("Nome do Dependente.................:");
            dependentes.Nome = Console.ReadLine();

            Console.Write("Data de Nascimento do Funcionario..:");
            dependentes.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe o ID do Funcionario..............:");
            dependentes.Funcionario.IdFuncionario = int.Parse(Console.ReadLine());

            dependentesRepository.Atualizar(dependentes);

            Console.WriteLine("Dependente Atualizado com sucesso!");

        }

        private static void ExcluirDependentes(DependentesRepository dependentesRepository)
        {
            Console.WriteLine("\n .:: EXCLUIR DEPENDENTE ::. \n");

            Console.Write("Informe o ID do Dependente..............:");
            int IdDependente = int.Parse(Console.ReadLine());

            dependentesRepository.Excluir(IdDependente);

            Console.WriteLine("Dependente Excluído com sucesso!");

        }

        private static void ConsultarDependentes(DependentesRepository dependentesRepository)
        {

            List<Dependentes> lista = dependentesRepository.ObterTodos();

            foreach (var dependentes in lista)
            {
                Console.WriteLine("\n .:: CONSULTAR DEPENDENTES ::. \n");
                Console.WriteLine("Id Dependente......:\t" + dependentes.IdDependentes);
                Console.WriteLine("Nome Dependente....:\t" + dependentes.Nome);
                Console.WriteLine("Data Nascimento....:\t" + dependentes.DataNascimento);

                Console.WriteLine("Id Funcionario.....:\t" + dependentes.Funcionario.IdFuncionario);
                Console.WriteLine("Salario............:\t" + dependentes.Funcionario.Nome);
                Console.WriteLine("Salario............:\t" + dependentes.Funcionario.Salario);
                Console.WriteLine("Data Admissao......:\t" + dependentes.Funcionario.DataAdmissao);

            }

        }

        private static void ConsultarDependentesID(DependentesRepository dependentesRepository)
        {

            Console.WriteLine("\n .:: CONSULTAR DE DEPENDENTES POR ID ::. \n");

            Console.Write("Informe o ID do Dependente..............:");
            int IdDependente = int.Parse(Console.ReadLine());

            Dependentes dependentes = dependentesRepository.ObterTodosPorID(IdDependente);

            if (dependentes != null)
            {
                Console.WriteLine("\n .:: CONSULTAR DEPENDENTES ::. \n");
                Console.WriteLine("Id Dependente......:\t" + dependentes.IdDependentes);
                Console.WriteLine("Nome Dependente....:\t" + dependentes.Nome);
                Console.WriteLine("Data Nascimento....:\t" + dependentes.DataNascimento);

                Console.WriteLine("Id Funcionario.....:\t" + dependentes.Funcionario.IdFuncionario);
                Console.WriteLine("Salario............:\t" + dependentes.Funcionario.Nome);
                Console.WriteLine("Salario............:\t" + dependentes.Funcionario.Salario);
                Console.WriteLine("Data Admissao......:\t" + dependentes.Funcionario.DataAdmissao);

            }
            else
            {
                Console.WriteLine("Dependente não Localizado");
            }

        }


    }
}
