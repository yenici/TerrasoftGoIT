using System;
using System.Collections.Generic;

namespace Assignment_08_0
{
    class ChatBotEN : ChatBot
    {
        private static List<String> helloAnswers = new List<String>()
        {
            "Hello!",
            "Hi!",
            "Good morning.",
            "Good afternoon.",
            "Good evening.",
            "Hi there!"
        };
        private static List<String> goodbyeAnswers = new List<String>()
        {
            "Good-bye!",
            "Bye.",
            "So long!",
            "Bye-bye!",
            "Cheerio!",
            "Good night!",
            "Night.",
            "See you soon!",
            "See you tomorrow",
            "See you.",
            "See you later.",
            "See you sometime.",
            "See you around.",
            "All the best!",
            "Good luck!"
        };
        private static List<String> howAreYouAnswers = new List<String>()
        {
            "Fine, thank you.",
            "I'm very well, thanks!",
            "Not bad, thank you!",
            "The same as usual, thank you!",
            "So-so.",
            "All the better for seeing you!"
        };
        private static List<String> dontGotAnswers = new List<String>()
        {
            "Excuse me. What do you mean?",
            "I didn't understand you.",
        };
        private static Dictionary<Mode, HashSet<String>> phraseWords = new Dictionary<Mode, HashSet<String>>
        {
             {
                Mode.Hello,
                ChatBot.GetWordsSet(ChatBotEN.helloAnswers)
             },
             {
                Mode.Goodbye,
                ChatBot.GetWordsSet(ChatBotEN.goodbyeAnswers)
             },
             {
                Mode.HowAreYou,
                ChatBot.GetWordsSet(
                    new List<String>()
                    {
                        "How are you",
                        "How do you do?",
                        "How are you doing?",
                        "What's up?",
                        "How's it going?",
                        "How goes it?",
                        "Howdy friend?"
                    }
                )
             }
        };
        private Random random = new Random();
        override public String SayHello()
        {
            return ChatBotEN.helloAnswers[random.Next(helloAnswers.Count)];
        }
        override public String SayGoodby()
        {
            return ChatBotEN.goodbyeAnswers[random.Next(goodbyeAnswers.Count)];
        }
        override public String SayHowAreYou()
        {
            return ChatBotEN.howAreYouAnswers[random.Next(howAreYouAnswers.Count)];
        }
        override public String SayDontGot()
        {
            return ChatBotEN.dontGotAnswers[random.Next(dontGotAnswers.Count)];
        }
        override public Dictionary<Mode, HashSet<String>> GetDictionary()
        {
            return ChatBotEN.phraseWords;
        }
    }
}
