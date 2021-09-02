using System;
using System.Globalization;
using System.Linq;
using Domain.People;

namespace HeartBeats.Cli
{
    public class RegistrationCli
    {
        public static Person ReadPersonData()
        {
            (string id, string name) = AskDataWithoutValidation();
            return new Person(id, name, AskAge(), AskGenre());
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

        private static Genre AskGenre()
        {
            while (true)
            {
                Console.Write("Ingresa tu género [F/M]: ");
                try
                {
                    return MapCharToGenre(Console.ReadLine()
                        ?.ToUpper(CultureInfo.InvariantCulture).FirstOrDefault());
                }
                catch (InvalidGenreException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static Genre MapCharToGenre(char? letter)
        {
            return letter switch
            {
                'F' => Genre.Female,
                'M' => Genre.Male,
                _ => throw new InvalidGenreException("Genero inválido.")
            };
        }
    }
}
