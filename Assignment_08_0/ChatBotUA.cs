using System;
using System.Collections.Generic;

namespace Assignment_08_0
{
    class ChatBotUA : ChatBot
    {
        private static List<String> helloAnswers = new List<String>()
        {
            "Добрий день!",
            "Доброго дня!",
            "Добридень!",
            "На добридень!",
            "Здрастуй!",
            "Здрастуйте!",
            "Здоровенькі були!",
            "Здоров!",
            "Привіт!",
            "Доброго здоров'я!",
            "Моє шанування!",
            "Моє шануваннячко!",
            "Моє вшанування!",
            "Моє вітання!",
            "Дозвольте привітати Вас!",
            "Радий вітати Вас!",
            "Вітаю Вас!"
            //"Добрий ранок!",
            //"Доброго ранку!",
            //"Я бажаю Вам доброго ранку!",
            //"Я зичу Вам доброго ранку!",
            //"З добрим ранком Вас!",
            //"Добрий вечір!",
            //"Вечір добрий!",
            //"Добривечір!"
        };
        private static List<String> goodbyeAnswers = new List<String>()
        {
            "До побачення",
            "До зустрічі",
            "Бувай",
            "Бувай здоров",
            "Побачимося",
            "Зустрінемося",
            "Прощавай"
        };
        private static List<String> howAreYouAnswers = new List<String>()
        {
            "Дякую, все гаразд.",
            "Добре. Дякую.",
            "Все добре. Сподіваюсь, в тебе також."
        };
        private static List<String> dontGotAnswers = new List<String>()
        {
            "Перепрошую...",
            "Перепрошую, сформулюй свою фразу по-іншому",
            "Вибач, але я тебе не розумію.",
            "Нажаль, я не на стільки разумний. Я не зрозумів тебе."
        };
        private static Dictionary<Mode, HashSet<String>> phraseWords = new Dictionary<Mode, HashSet<String>>
        {
             {
                Mode.Hello,
                ChatBot.GetWordsSet(ChatBotUA.helloAnswers)
             },
             {
                Mode.Goodbye,
                ChatBot.GetWordsSet(ChatBotUA.goodbyeAnswers)
             },
             {
                Mode.HowAreYou,
                ChatBot.GetWordsSet(
                    new List<String>()
                    {
                        "Як твої справи?",
                        "Як справи?",
                        "Як ся маєш?"
                    }
                )
             }
        };
        private Random random = new Random();
        override public String SayHello()
        {
            return ChatBotUA.helloAnswers[random.Next(helloAnswers.Count)];
        }
        override public String SayGoodby()
        {
            return ChatBotUA.goodbyeAnswers[random.Next(goodbyeAnswers.Count)];
        }
        override public String SayHowAreYou()
        {
            return ChatBotUA.howAreYouAnswers[random.Next(howAreYouAnswers.Count)];
        }
        override public String SayDontGot()
        {
            return ChatBotUA.dontGotAnswers[random.Next(dontGotAnswers.Count)];
        }
        override public Dictionary<Mode, HashSet<String>> GetDictionary()
        {
            return ChatBotUA.phraseWords;
        }
    }
}
