namespace Gerenc_Alunos.helpers
{
    class Media
    {
        public static float? GerarMedia(float? nota1, float? nota2)
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

        public static string GerarSituacao(float media)
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
}