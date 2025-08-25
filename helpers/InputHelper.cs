using System.Globalization;
namespace Gerenc_Alunos.helpers
{
    class InputHelper
    {
        public static string LerString(string frase)
        {
            while (true)
            {
                Console.Write(frase);
                string? valor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(valor))
                {
                    return valor;
                }
                Console.WriteLine("Valor inválido. Tente novamente!!");
            }
        }

        public static float LerFloat(string frase)
        {
            while (true)
            {
                string valor = LerString(frase);

                if (float.TryParse(valor, NumberStyles.Float, CultureInfo.InvariantCulture, out float valorFloat))
                {
                    return valorFloat;
                }
                Console.WriteLine("Valor inválido. Iforme apenas números!!");
            }
        }

        public static int LerInt(string frase)
        {
            while (true)
            {
                string valor = LerString(frase);

                if (int.TryParse(valor, out int valorInt))
                {
                    return valorInt;
                }

                Console.WriteLine("Valor inválido. Informe apenas números inteiros!!");
            }
        }
    }
}