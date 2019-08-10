using System;
using System.Linq;
using GemCard.Shell;

namespace MyApp
{
    class Program
    {
        private static readonly object SyncLocker = new object();

        static void Main(string[] args)
        {
            Log(ConsoleColor.White, "Программа запущена");

            ISmartReaderListener listener = new SmartReaderListener();
            listener.CardInserted += Listener_CardInserted;
            listener.CardRemoved += Listener_CardRemoved;

            while (true)
            {
                string cmdLine = Console.ReadLine()?.ToUpper();
                var segments = cmdLine?.Split(' ') ?? new string[0];
                string cmd = segments.First();

                switch (cmd)
                {
                    case "W":
                    case "WRITE":
                        bool isValue = !int.TryParse(segments.Last(), out var newValue);
                        if (segments.Length != 2 && isValue)
                        {
                            Log(ConsoleColor.DarkYellow, "Должен быть указан один аргумент-число");
                            break;
                        }

                        Log(ConsoleColor.DarkYellow, $"Попытка записи значения {newValue} в карту");
                        bool isSuccess = listener.WriteValue(newValue);
                        if (isSuccess)
                            Log(ConsoleColor.DarkGreen, $"[УДАЧА] Значение {newValue} было записано в карту");
                        else
                            Log(ConsoleColor.DarkRed, $"[НЕУДАЧА] Значение {newValue} не было записано в карту");
                        break;
                    default:
                        Log(ConsoleColor.DarkYellow, "Неизвестная команда");
                        break;
                }
            }
        }

        private static void Listener_CardRemoved(object sender, EventArgs e)
            => Log(ConsoleColor.White, "[UNLOAD] Карта была удалена");

        private static void Listener_CardInserted(object sender, CardInsertedEventArgs e)
        {
            if (e.Value.HasValue)
                Log(ConsoleColor.DarkGreen, $"[LOAD] Карта c ID == {e.Value}");
            else
                Log(ConsoleColor.DarkRed, "[LOAD] Не удалось считать значение карты");
        }

        private static void Log(ConsoleColor color, string text)
        {
            lock (SyncLocker)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}