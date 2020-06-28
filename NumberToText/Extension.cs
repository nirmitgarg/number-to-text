using System;
using System.Collections.Generic;
using System.Text;

namespace NumberToText
{
    public static class Extension
    {
        static IDictionary<int, string> numberToTextMapping = new Dictionary<int, string>
            {
                { 0, " zero " } ,
                { 1,  " one "  },
                { 2,  " two "  },
                { 3,  " three "  },
                { 4,  " four "  },
                { 5,  " five "  },
                { 6,  " six "  },
                { 7,  " seven "  },
                { 8,  " eight "  },
                { 9,  " nine "  },
                { 10,  " ten "  },
                { 11,  " eleven "  },
                { 12,  " twelve "  },
                { 13,  " thirteen "  },
                { 14,  " fourteen "  },
                { 15,  " fifteen "  },
                { 16,  " sixteen "  },
                { 17,  " seventeen "  },
                { 18,  " eighteen "  },
                { 19,  " nineteen "  },
                { 20,  " twenty "  },
                { 30,  " thirty "  },
                { 40,  " forty "  },
                { 50,  " fifty "  },
                { 60,  " sixty "  },
                { 70,  " seventy "  },
                { 80,  " eighty "  },
                { 90,  " ninety "  },
                { 100, " hundred " },
                { 1000, " thousand " },
                { 1000000, " million " }
        };

        public static string NumberToText(this int number)
        {
            var words = string.Empty;

            List<int> divideByList = new List<int> { 1000000, 1000, 100 };

            foreach (var divideBy in divideByList)
            {
                GetRemainderAndText(divideBy, ref number, ref words);
            }

            if (number > 0)
            {
                if (words != "")
                    words += " and ";

                if (number < 20)
                    words += numberToTextMapping[number];
                else
                {
                    words += numberToTextMapping[(number / 10) * 10];

                    if ((number % 10) > 0)
                        words += numberToTextMapping[number % 10];
                }
            }
            return words;
        }

        private static void GetRemainderAndText(int divideBy, ref int number, ref string words)
        {
            if ((number / divideBy) > 0)
            {
                words += NumberToText(number / divideBy) + numberToTextMapping[divideBy];
                number %= divideBy;
            }
        }
    }
}
