namespace Gerenc_Alunos.model
{
    class Aluno
    {
        public string Nome {get; set;}
        public string Matricula {get; set;}
        public float? Nota1 {get; set;}
        public float? Nota2 {get; set;}

        public Aluno(string nome, string matricula, float nota1, float nota2)
        {
            Nome = nome;
            Matricula = matricula;
            Nota1 = nota1;
            Nota2 = nota2;
        }

        public Aluno(string nome, string matricula)
        {
            Nome = nome;
            Matricula = matricula;
        }
    }
}
