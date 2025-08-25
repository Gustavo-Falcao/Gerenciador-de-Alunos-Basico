using Gerenc_Alunos.controller;
using Gerenc_Alunos.model;
using System.Globalization;
using Gerenc_Alunos.helpers;
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
            string nome = InputHelper.LerString("Digite o nome do aluno: ");

            string matricula = InputHelper.LerString("Digite a matricula do aluno: ");

            float nota1 = InputHelper.LerFloat("Digite a primeira nota: ");

            float nota2 = InputHelper.LerFloat("Digite a segunda nota: ");

            CriarAlunoEadicionarComNotas(nome, matricula, nota1, nota2);
        }

        private void CriarAlunoEadicionarComNotas(string nome, string matricula, float nota1, float nota2)
        {
            alunoController.AdicionarAluno(new Aluno(nome, matricula, nota1, nota2));
        }

        public void CadastrarAlunoSemNotas()
        {
            string nome = InputHelper.LerString("Digite o nome do aluno: ");

            string matricula = InputHelper.LerString("Digite a matricula do aluno: ");

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
                    MostrarInfoAluno(aluno);
                    Console.WriteLine("-------------------------------------");
                }
            }
        }

        private bool IsNotaNull(float? nota)
        {
            return nota is null;
        }

        public void MostrarInfoAluno(Aluno aluno)
        {
            Console.WriteLine($"\nNome: {aluno.Nome}");
            Console.WriteLine($"Matrícula: {aluno.Matricula}");
            Console.WriteLine($"Nota1: {(IsNotaNull(aluno.Nota1) ? "Não informado" : $"{aluno.Nota1}")}");
            Console.WriteLine($"Nota2: {(IsNotaNull(aluno.Nota2) ? "Não informado" : $"{aluno.Nota2}")}");
            float? media = Media.GerarMedia(aluno.Nota1, aluno.Nota2);
            if (media is not null)
            {
                Console.WriteLine($"Media: {media:F2}");
                Console.WriteLine($"Situação: {Media.GerarSituacao(media.Value)}");
            }
            else
            {
                Console.WriteLine("Media: esperando notas...");
                Console.WriteLine("Situação: Em observação");
            }
        }

        public void AcessarAluno(string matricula)
        {
            Aluno? aluno = alunoController.BuscarAlunoOrNull(matricula);
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
                    MostrarInfoAluno(aluno);
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine(">> Opções");
                    Console.WriteLine("  [1]- Atualizar nota 1");
                    Console.WriteLine("  [2]- Atualizar nota 2");
                    Console.WriteLine("  [0]- Voltar");
                    Console.WriteLine("-------------------------------------");
                    opcaoAtualizarAluno = InputHelper.LerInt("#>> Escolha uma opcao: ");
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
                    float nota1 = InputHelper.LerFloat(">> Digite a nova nota: ");
                    aluno.Nota1 = nota1;
                    break;
                case 2:
                    Console.WriteLine("\n\n----------------------------");
                    Console.WriteLine("<<-- Atualizar nota 2 -->>");
                    float nota2 = InputHelper.LerFloat(">> Digite a nova nota: ");
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

        public void DeletarAluno() 
        {
            Console.WriteLine("\n\n-------------------------------");
            Console.WriteLine("  << Deletar Aluno >>");    
            string matriculaDelete = InputHelper.LerString("##-> Informe a matricula: ");
            if(alunoController.RemoverAluno(matriculaDelete))
            {
                Console.WriteLine("Aluno removido com sucesso ...");
            } else 
            {
                Console.WriteLine("Aluno não encontrado!!");
            }
        }
    }
}
