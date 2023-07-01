using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalizer
{
    public class WordDecliner
    {
        public static string Decline(int num, string nominative, string singular, string plural)
        {
            if (num > 10 && ((num % 100) / 10) == 1) return plural;

            switch (num % 10)
            {
                case 1:
                    return nominative;
                case 2:
                case 3:
                case 4:
                    return singular;
                default: // case 0, 5-9
                    return plural;
            }
        }
    }
}
