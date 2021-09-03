using System;
using System.Globalization;
using System.Linq;

namespace HeartBeats.Cli
{
    public record PersonData(string Id, string Name, int Age, char Genre);

    public class RegistrationCli
    {
        public static PersonData ReadPersonData()
        {
            (string id, string name) = AskDataWithoutValidation();
            return new PersonData(id, name, AskAge(), AskGenre());
        }

        private static (string, string) AskDataWithoutValidation()
        {
            Console.Write("Ingrese su id: ");
            string id = Console.ReadLine();
            Console.Write("Ingrese su nombre: ");
            string name = Console.ReadLine();

            return (id, name);
        }

        private static TNumeric AskNumericData<TNumeric>(string question,
            Func<string, CultureInfo, TNumeric> parsing)
        {
            while (true)
            {
                Console.Write(question);
                try
                {
                    return parsing(Console.ReadLine(), CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nSólo ingrese valores númericos.");
                }
            }
        }

        private static int AskAge()
        {
            return AskNumericData("Ingresa tu edad: ", Convert.ToInt32);
        }

        private static char AskGenre()
        {
            while (true)
            {
                Console.Write("Ingresa tu género [F/M]: ");
                try
                {
                    return CheckForGenre(Console.ReadLine()
                        ?.ToUpper(CultureInfo.InvariantCulture).FirstOrDefault());
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static char CheckForGenre(char? letter) => letter switch
        {
            'F' => 'F',
            'M' => 'M',
            _ => throw new InvalidOperationException("Genero inválido.")
        };
    }
}
