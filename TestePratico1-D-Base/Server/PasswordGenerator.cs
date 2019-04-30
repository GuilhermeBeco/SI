using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class PasswordGenerator
    {
        public static string GeneratePassword(int numberOfCharacters)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random((int)DateTime.Now.Ticks);
            const string special = "!@#$%^&*_-=+";
            for (int i = 0; i < numberOfCharacters; i++)
            {
                char character = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                // Uppercase | Lowercase
                if (random.Next(2) == 0)
                {
                    builder.Append(character.ToString().ToLower());
                }
                else
                {
                    builder.Append(character);
                }
                // Numbers
                if (i % 3 == 0 && i + 1 < numberOfCharacters)
                {
                    int num = random.Next(9);
                    builder.Append(num);
                    i++;
                }
                // Symbols
                if (i % 4 == 0 && i + 1 < numberOfCharacters)
                {
                    builder.Append(special[random.Next(special.Count())]);
                }
            }
            return builder.ToString();
        }

    }
}
