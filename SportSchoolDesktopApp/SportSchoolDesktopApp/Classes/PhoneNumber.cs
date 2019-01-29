using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSchoolDesktopApp.Classes
{
    public class PhoneNumber
    {
        public string Operator { get; set; }
        public string Part1 { get; set; }
        public string Part2 { get; set; }

        public PhoneNumber(string phone)
        {
            Operator = phone.Substring(2, 3);
            Part1 = phone.Substring(6, 3);
            Part2 = phone.Substring(10, 4);
        }

        public PhoneNumber(string Operator, string Part1, string Part2)
        {
            this.Operator = Operator;
            this.Part1 = Part1;
            this.Part2 = Part2;
        }

        public override string ToString()
        {
            return $"8({Operator}){Part1}-{Part2}";
        }

        public static bool IsCorrect(string Operator, string Part1, string Part2)
        {
            if (Operator.Length != 3 ||Part1.Length != 3 || Part2.Length != 4)
                return false;
            int[] d = new int[3];
            bool[] isNum = new bool[] {
                    int.TryParse(Operator, out d[0]),
                    int.TryParse(Part1, out d[1]),
                    int.TryParse(Part2, out d[2])
                    };
            if (!isNum[0] || !isNum[1] || !isNum[2])
                return false;
            return true;
        }
    }
}
