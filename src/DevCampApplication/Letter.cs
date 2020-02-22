using System;
using System.Collections.Generic;

namespace DevCampApplication
{
    public abstract class Letter
    {
        public int Thickness { get; private set; }

        public string SpacingString { get; private set; }

        public char FillingCharacter { get; private set; }


        protected Letter(int thickness = 3, string spacingString = "-", char fillingCharacter = '*')
        {
            SetValues(thickness, spacingString, fillingCharacter);
        }

        public void SetValues(int thickness = 3, string spacingString = "-", char fillingCharacter = '*')
        {
            Thickness = thickness;
            SpacingString = spacingString ?? throw new ArgumentNullException(nameof(spacingString));
            FillingCharacter = fillingCharacter;
        }

        public abstract List<List<string>> GetParsedMessage(int letterCount);
    }
}
