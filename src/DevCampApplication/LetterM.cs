using System.Collections.Generic;

namespace DevCampApplication
{
    public class LetterM : Letter
    {
        public LetterM(int thickness = 3, string spacingString = "-", char fillingCharacter = '*') : base(thickness, spacingString, fillingCharacter)
        {

        }


        public override List<List<string>> GetParsedMessage(int letterCount)
        {
            var message = new List<List<string>>();

            for (int i = 0; i <= Thickness; i++)
            {
                var rowString = new List<string>();
                for (int j = 0; j < letterCount; j++)
                {
                    for (int t = 0; t < Thickness * 5; t++)
                    {
                        rowString.Add(IsFillingCharacter(i, t) ? FillingCharacter.ToString() : SpacingString);
                    }
                }
                message.Add(rowString);
            }

            return message;
        }

        private bool IsFillingCharacter(int thicknessIndex, int column)
        {
            var currentPoints = new List<int>();
            currentPoints.Add(Thickness - 1 - thicknessIndex);
            currentPoints.Add(Thickness - 1 + thicknessIndex);
            currentPoints.Add(3 * Thickness - 1 - thicknessIndex);
            currentPoints.Add(3 * Thickness - 1 + thicknessIndex);

            return GetCurrentPoint(currentPoints[0], column) ||
                GetCurrentPoint(currentPoints[1], column) ||
                GetCurrentPoint(currentPoints[2], column) ||
                GetCurrentPoint(currentPoints[3], column);
        }

        private bool GetCurrentPoint(int initialPoint, int column)
        {
            return column > initialPoint && column <= (initialPoint + Thickness);
        }

    }
}