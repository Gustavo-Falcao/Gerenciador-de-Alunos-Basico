using Gerenc_Alunos.model;
namespace Gerenc_Alunos.controller
{
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

        public Aluno? BuscarAlunoOrNull(string matricula)
        {
            foreach (Aluno aluno in alunos)
            {
                if (aluno.Matricula == matricula)
                {
                    return aluno;
                }
            }
            return null;
        }

        public bool RemoverAluno(string matricula)
        {
            Aluno aluno = BuscarAlunoOrNull(matricula);
            if(aluno is not null)
            {
                alunos.Remove(aluno);
                return true;
            } else 
            {
                return false;
            }
        }
    }
}
