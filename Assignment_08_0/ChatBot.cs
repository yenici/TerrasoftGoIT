using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Assignment_08_0
{
    abstract public class ChatBot
    {
        public String Name { get; set; }
        private static readonly byte MIN_WORD_LENGTH = 3;
        abstract public String SayHello();
        abstract public String SayGoodby();
        abstract public String SayHowAreYou();
        abstract public String SayDontGot();
        abstract public Dictionary<Mode, HashSet<String>> GetDictionary();
        protected static HashSet<String> GetWordsSet(String message)
        {
            var pattern = new Regex(
              @"([^\W_\d]          # starting with a letter
                                   # followed by a run of either...
              ([^\W_\d] |          #   more letters or
                [-'](?=[^\W_\d])   #   ', - followed by a letter
              )*
              [^\W_\d]              # and finishing with a letter
              )",
            RegexOptions.IgnorePatternWhitespace);
            HashSet<String> set = new HashSet<String>();
            foreach (Match m in pattern.Matches(message))
                if (m.Groups[1].Value.Length >= ChatBot.MIN_WORD_LENGTH)
                    set.Add(m.Groups[1].Value.ToLower());
            return set;
        }
        protected static HashSet<String> GetWordsSet(List<String> messages)
        {
            HashSet<String> set = new HashSet<String>();
            foreach (String message in messages)
                set.UnionWith(ChatBot.GetWordsSet(message));
            return set;
        }
        public static Mode AnalyzeInput(ChatBot bot, String message)
        {
            Mode mode = Mode.Undefined;
            int intersectionCnt = 0;
            int intersectionCntTmp;
            String response = bot.SayDontGot();
            HashSet<String> messageSet = ChatBot.GetWordsSet(message);
            Dictionary<Mode, HashSet<String>> dictionary = bot.GetDictionary();
            foreach(Mode m in dictionary.Keys)
            {
                intersectionCntTmp = dictionary[m].Intersect(messageSet).Count();
                if (intersectionCntTmp > intersectionCnt)
                {
                    intersectionCnt = intersectionCntTmp;
                    mode = m;
                }
            }
            return mode;
        }
        public static void PrintBotMessage(ChatBot bot, String message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("{0}: ", bot.Name);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
        }
        public static String ReadMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.Green;
            return Console.ReadLine();
        }
    }
    public enum Mode
    {
        Undefined = 0,
        Hello = 1,
        HowAreYou = 2,
        Goodbye = 3
    }
}
