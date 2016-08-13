using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_08_0
{
    class ChatBotRU : ChatBot
    {
        private static List<String> helloAnswers = new List<String>()
        {
            "Добрый день!",
            "Доброго дня!",
            "Привет!",
            "Здравствуйте!",
            "Здравствуй!",
            "Рад Вас видеть!",
            "Моё почтение!",
            "Здравия желаю!"
        };
        private static List<String> goodbyeAnswers = new List<String>()
        {
            "До свидания!",
            "Пока!",
            "Увидимся!",
            "До встречи!",
            "До скорых встреч!",
            "Удачи!",
            "До скорого!"
        };
        private static List<String> howAreYouAnswers = new List<String>()
        {
            "Спасибо, всё хорошо.",
            "Всё хорошо, спасибо.",
            "Лучше всех!",
            "Спасибо, просто отлично!"
        };
        private static List<String> dontGotAnswers = new List<String>()
        {
            "Извините, я Вас не понял.",
            "К сожалению, я Вас не понимаю.",
            "Попробуйте сформулировать Вашу мысль иначе.",
            "Мой интеллект не позволяет Вас понять."
        };
        private static Dictionary<Mode, HashSet<String>> phraseWords = new Dictionary<Mode, HashSet<String>>
        {
             {
                Mode.Hello,
                ChatBot.GetWordsSet(ChatBotRU.helloAnswers)
             },
             {
                Mode.Goodbye,
                ChatBot.GetWordsSet(ChatBotRU.goodbyeAnswers)
             },
             {
                Mode.HowAreYou,
                ChatBot.GetWordsSet(
                    new List<String>()
                    {
                        "Как дела?",
                        "Как успехи?",
                        "Как жизнь?"
                    }
                )
             }
        };
        private Random random = new Random();
        override public String SayHello()
        {
            return ChatBotRU.helloAnswers[random.Next(helloAnswers.Count)];
        }
        override public String SayGoodby()
        {
            return ChatBotRU.goodbyeAnswers[random.Next(goodbyeAnswers.Count)];
        }
        override public String SayHowAreYou()
        {
            return ChatBotRU.howAreYouAnswers[random.Next(howAreYouAnswers.Count)];
        }
        override public String SayDontGot()
        {
            return ChatBotRU.dontGotAnswers[random.Next(dontGotAnswers.Count)];
        }
        override public Dictionary<Mode, HashSet<String>> GetDictionary()
        {
            return ChatBotRU.phraseWords;
        }
    }
}
