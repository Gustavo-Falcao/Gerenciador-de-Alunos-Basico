using Gerenc_Alunos.controller;
using Gerenc_Alunos.view;
namespace Gerenc_Alunos
{
    class Program
    {
        public static void Main()
        {
            AlunoController alunoController = new AlunoController();
            AlunoView alunoView = new AlunoView(alunoController);
            int opcao;

            do
            {
                Console.WriteLine("\n\n\n+ ------------------------------------- +");
                Console.WriteLine("|  << -- Gerenciamento de Alunos -- >>  |");
                Console.WriteLine("+ ------------------------------------- +");
                Console.WriteLine("|                                       |");
                Console.WriteLine("|          [1]- Cadastrar Aluno         |");
                Console.WriteLine("|          [2]- Consultar Aluno         |");
                Console.WriteLine("|          [3]- Listar Alunos           |");
                Console.WriteLine("|          [0]- Sair                    |");
                Console.WriteLine("|                                       |");
                Console.WriteLine("+ ------------------------------------- +");
                Console.Write("==>> Escolha uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("\n\nComo deseja cadastrar o aluno ?");
                        Console.WriteLine(" [1]- Cadastrar o aluno informando as notas");
                        Console.WriteLine(" [2]- Cadastrar o aluno e informar as notas depois");
                        Console.WriteLine("-----------------------------------------------");
                        Console.Write("==>> Escolha uma opção: ");
                        int opcaoCadastro = int.Parse(Console.ReadLine());
                        if (opcaoCadastro == 1)
                        {
                            alunoView.CadastrarAlunoComNotas();
                        }
                        else if (opcaoCadastro == 2)
                        {
                            alunoView.CadastrarAlunoSemNotas();
                        }
                        else
                        {
                            Console.WriteLine("Opcao inválida!!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("\n\nDigite a matricula do aluno desejado: ");
                        string matriculaBusca = Console.ReadLine();
                        
                        break;
                    case 3:
                        alunoView.MostrarAlunos();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Escolha uma opção válida!!");
                        break;
                }
            } while (opcao != 0);
        }
    }
}

