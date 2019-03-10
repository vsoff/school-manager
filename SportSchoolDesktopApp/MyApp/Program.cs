using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSmartcard;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program is executed");
            try
            {
                SmartReaderController src = new SmartReaderController(SmartReaderType.Reader, PublicThings);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SmartReaderController initializing exception: {ex}");
            }
            Console.ReadLine();
            //src.DestroyObject();
        }

        static void PublicThings(int id)
        {
            if (id == -1)
                Console.WriteLine("No card here!");
            else
                Console.WriteLine("Inserted id == " + id);
        }
    }
}
