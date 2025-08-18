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

        foreach (Aluno aluno in alunos)
        {
            aluno.MostrarInfo();
            if (aluno.CalcularMedia() != null)
            {
                float media = aluno.CalcularMedia().Value;
                Console.WriteLine($"Media: {media:F2}");
                Console.WriteLine($"Situação: {GerarSituacaoAluno(media)}");
            }
            else
            {
                Console.WriteLine($"Media: Em espera");
                Console.WriteLine($"Situação: Em observação");
            }
            Console.WriteLine("-------------------------------------");
        }
    }

    private string GerarSituacaoAluno(float media)
    {
        if (media < 4)
        {
            return "Reprovado";
        }
        else if (media <= 6.9)
        {
            return "Exame";
        }
        else
        {
            return "Aprovado";
        }
    }
}