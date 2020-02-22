using System;
using System.Collections.Generic;
using System.Text;

namespace DevCampApplication
{
    public class Message
    {
        public List<Letter> Letters { get; private set; } = new List<Letter>();

        private byte lettersCount;
        public byte LettersCount
        {
            get
            {
                if (byte.TryParse(lettersCountString, out byte lettersCount))
                {
                    this.lettersCount = Math.Clamp(lettersCount, (byte)0, byte.MaxValue);
                }
                else
                {
                    Console.WriteLine("Invalid value!");
                    this.lettersCount = 0;
                }

                return this.lettersCount;
            }
        }

        private readonly string lettersCountString;


        public Message()
        {
            Letter letter;


            Console.Write("Choose a letter for the logo (only M implemented): ");
            string letterString = Console.ReadLine().ToLower();
            switch (letterString)
            {
                case "m":
                    letter = new LetterM();
                    break;
                default:
                    Console.WriteLine("The letter has not been implemented yet!");
                    return;
            }

            Console.Write("Enter the size of the logo (letters count, e.g. 2 -> MM): ");
            lettersCountString = Console.ReadLine();
            lettersCount = LettersCount;

            int thickness;
            Console.Write("Choose letter thickness (odd number between 3 and 9999 incl.): ");
            string thicknessString = Console.ReadLine();
            while (!int.TryParse(thicknessString, out thickness) || thickness % 2 == 0 || thickness < 3 || thickness > 9999)
            {
                Console.Write("Invalid value.\nChoose letter thickness (odd number between 3 and 9999 incl.): ");
                thicknessString = Console.ReadLine();
            }

            Console.Write("Choose a spacing string (recommended '-'): ");
            string spacingString = Console.ReadLine();

            char fillingCharacter;
            Console.Write("Choose a filling character (recommended '*'): ");
            string fillingCharacters = Console.ReadLine();
            while (!char.TryParse(fillingCharacters, out fillingCharacter))
            {
                Console.Write("Invalid value.\nChoose a filling character (recommended '*': ");
                fillingCharacters = Console.ReadLine();
            }

            letter.SetValues(thickness, spacingString, fillingCharacter);

            for (int i = 0; i < lettersCount; i++)
            {
                Letters.Add(letter);
            }
        }

        public void Print()
        {
            var tempLetter = Letters[0];
            if (tempLetter == null)
            {
                Console.WriteLine("Invalid letter type");
                return;
            }

            var stringBuilder = new StringBuilder();
            var message = tempLetter.GetParsedMessage(lettersCount);

            foreach (var row in message)
            {
                stringBuilder.AppendLine(string.Join("", row.ToArray()));
            }

            Console.Clear();

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
