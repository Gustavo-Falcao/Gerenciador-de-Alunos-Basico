namespace Gerenc_Alunos.model
{
    class Aluno
    {
        /*
        private string nome;
        private string matricula;
        private float? nota1;
        private float? nota2;
        */

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

    /*    public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        public float? Nota1
        {
            get { return nota1; }
            set { nota1 = value; }
        }

        public float? Nota2
        {
            get { return nota2; }
            set { nota2 = value; }
        }
*/
        public float? CalcularMedia()
        {
            if (Nota1 != null && Nota2 != null)
            {
                return (Nota1.Value + Nota2.Value) / 2;
            }
            else
            {
                return null;
            }
        }

        private bool IsNotaNull(float? nota)
        {
            return nota is null;
        }

        private string GerarSituacao(float media)
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

        public void MostrarInfo()
        {
            Console.WriteLine($"\nNome: {Nome}");
            Console.WriteLine($"Matrícula: {Matricula}");
            string msgOuNota;
            msgOuNota = IsNotaNull(Nota1) ? "Não informado" : Nota1.Value.ToString();
            Console.WriteLine($"Nota 1: {msgOuNota}");
            msgOuNota = IsNotaNull(Nota2) ? "Não informado" : Nota2.Value.ToString();
            Console.WriteLine($"Nota 2: {msgOuNota}");
            if (CalcularMedia() is not null)
            {
                float media = CalcularMedia().Value;
                Console.WriteLine($"Media: {media:F2}");
                Console.WriteLine($"Situação: {GerarSituacao(media)}");
            }
            else
            {
                Console.WriteLine($"Media: Em espera");
                Console.WriteLine($"Situação: Em observação");
            }
        } //Linha 85
    }
}
