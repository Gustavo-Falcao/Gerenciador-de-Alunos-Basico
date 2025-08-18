class AlunoController
{
    private List<Aluno> alunos;

    public AlunoController()
    {
        alunos = new List<Aluno>();
    }

    public List<Aluno> ListarAlunos()
    {
        return alunos;
    }

    public void AdicionarAluno(Aluno aluno)
    {
        alunos.Add(aluno);
    }
}