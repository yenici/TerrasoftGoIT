using System;
using System.Text;

namespace Assignment_08_0
{
    class Chat
    {
        static void Main(string[] args)
        {
            Chat.StartChat();
        }
        public static void StartChat()
        {
            byte item;
            ChatBot bot = null;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Select the language you want to speak with the Bot.\n");
                Console.WriteLine("Оберіть мову для спілкування з Ботом.\n");
                Console.WriteLine("Выберите язык для общения с Ботом.\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1. English");
                Console.WriteLine("2. Українська");
                Console.WriteLine("3. Русский");
                Console.WriteLine("4. Quit / Вихід / Выход\n");
                Byte.TryParse(Console.ReadLine(), out item);
                if (item > 0 && item <= 4)
                {
                    switch (item)
                    {
                        case 1:
                            bot = new ChatBotEN();
                            bot.Name = "Assistant";
                            break;
                        case 2:
                            bot = new ChatBotUA();
                            bot.Name = "Помічник";
                            break;
                        case 3:
                            bot = new ChatBotRU();
                            bot.Name = "Помощник";
                            break;
                        case 4:
                            break;
                    }
                    if (item < 4)
                        Chat.StartConversation(bot);
                    else
                        break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Wrong input / Невірно введено номер / Некорректно введен номер");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Press any key to continue / Натисніть будь-яку клавішу / Нажмите любую клавишу");
                    Console.ReadKey();
                }
            }
        }
        public static void StartConversation(ChatBot bot)
        {
            Console.Clear();
            Mode mode = Mode.Undefined;
            String responseMessage;
            ChatBot.PrintBotMessage(bot, bot.SayHello());
            while (mode != Mode.Goodbye)
            {
                mode = ChatBot.AnalyzeInput(bot, ChatBot.ReadMessage());
                switch (mode)
                {
                    case Mode.Hello:
                        responseMessage = bot.SayHello();
                        break;
                    case Mode.Goodbye:
                        responseMessage = bot.SayGoodby();
                        break;
                    case Mode.HowAreYou:
                        responseMessage = bot.SayHowAreYou();
                        break;
                    default:
                        responseMessage = bot.SayDontGot();
                        break;
                }
                ChatBot.PrintBotMessage(bot, responseMessage);
                if (mode == Mode.Goodbye)  // Wait for a key press in case of goodbye
                    Console.ReadKey();
            }
        }
    }
}
