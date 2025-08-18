class Aluno
{
    private string nome;
    private string matricula;
    private float? nota1;
    private float? nota2;

    public Aluno(string nome, string matricula, float nota1, float nota2)
    {
        this.nome = nome;
        this.matricula = matricula;
        this.nota1 = nota1;
        this.nota2 = nota2;
    }

    public Aluno(string nome, string matricula)
    {
        this.nome = nome;
        this.matricula = matricula;
    }

    public string Nome
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

    public float? CalcularMedia()
    {
        if (nota1 != null && nota2 != null)
        {
            return (nota1.Value + nota2.Value) / 2;
        }
        else
        {
            return null;
        }
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"\nNome: {nome}");
        Console.WriteLine($"Matrícula: {matricula}");
        if (nota1 == null) {
            Console.WriteLine("Nota 1: Não informado");
        }
        else
        {
            Console.WriteLine($"Nota 1: {nota1}");
        }
        if (nota2 == null)
        {
            Console.WriteLine("Nota 2: Não informado");
        }
        else
        {
            Console.WriteLine($"Nota 2: {nota2}");   
        }
    }

}