using Gerenc_Alunos.controller;
using Gerenc_Alunos.model;
namespace Gerenc_Alunos.view
{
    class AlunoView
    {
        private AlunoController alunoController;

        public AlunoView(AlunoController alunoController)
        {
            this.alunoController = alunoController;
        }

        public void CadastrarAlunoComNotas()
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a matricula do aluno: ");
            string matricula = Console.ReadLine();

            Console.Write("Digite a primeira nota: ");
            float nota1 = float.Parse(Console.ReadLine());

            Console.Write("Digite a segunda nota: ");
            float nota2 = float.Parse(Console.ReadLine());

            CriarAlunoEadicionarComNotas(nome, matricula, nota1, nota2);
        }

        private void CriarAlunoEadicionarComNotas(string nome, string matricula, float nota1, float nota2)
        {
            alunoController.AdicionarAluno(new Aluno(nome, matricula, nota1, nota2));
        }

        public void CadastrarAlunoSemNotas()
        {
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a matricula do aluno: ");
            string matricula = Console.ReadLine();

            CriarAlunoEadicionarSemNotas(nome, matricula);
        }

        private void CriarAlunoEadicionarSemNotas(string nome, string matricula)
        {
            alunoController.AdicionarAluno(new Aluno(nome, matricula));
        }

        public void MostrarAlunos()
        {
            List<Aluno> alunos = alunoController.ListarAlunos();

            Console.WriteLine("\n\n<< -- Alunos cadastrados -- >>");
            if (alunos.Count == 0)
            {
                Console.WriteLine(">> Nenhum aluno cadastrado ainda...");
            }
            else
            {
                foreach (Aluno aluno in alunos)
                {
                    aluno.MostrarInfo();
                    Console.WriteLine("-------------------------------------");
                }
            }
        }

        public void AcessarAluno(string matricula)
        {
            Aluno aluno = alunoController.BuscarAlunoOrNull(matricula);
            if (aluno is null)
            {
                Console.WriteLine($"\n>> O aluno com a matricula {matricula} não foi encontrado!!");
            }
            else
            {
                int opcaoAtualizarAluno;
                do
                {
                    Console.WriteLine("\n\n-----------------------------------------------");
                    Console.WriteLine($"<<-- Informações do aluno {aluno.Nome} -->>");
                    aluno.MostrarInfo();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine(">> Opções");
                    Console.WriteLine("  [1]- Atualizar nota 1");
                    Console.WriteLine("  [2]- Atualizar nota 2");
                    Console.WriteLine("  [0]- Voltar");
                    Console.WriteLine("-------------------------------------");
                    Console.Write("#>> Escolha uma opcao: ");
                    opcaoAtualizarAluno = int.Parse(Console.ReadLine());
                    TratarOpAtualizarAluno(opcaoAtualizarAluno, aluno);
                } while (opcaoAtualizarAluno != 0);
            }
        }

        private void TratarOpAtualizarAluno(int opcao, Aluno aluno)
        {
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("\n\n----------------------------");
                    Console.WriteLine("<<-- Atualizar nota 1 -->>");
                    Console.Write(">> Digite a nova nota: ");
                    float nota1 = float.Parse(Console.ReadLine());
                    aluno.Nota1 = nota1;
                    break;
                case 2:
                    Console.WriteLine("\n\n----------------------------");
                    Console.WriteLine("<<-- Atualizar nota 2 -->>");
                    Console.Write(">> Digite a nova nota: ");
                    float nota2 = float.Parse(Console.ReadLine());
                    aluno.Nota2 = nota2;
                    break;
                case 0:
                    Console.WriteLine("Voltando...");
                    break;
                default:
                    Console.WriteLine("Digite um opção válida!!!");
                    break;
            }
        }

    }
}
