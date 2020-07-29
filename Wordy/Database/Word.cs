using System;
using System.Collections.Generic;
using System.Text;

namespace Wordy.Database
{
    class Word
    {
        public int Id { get; set; }
        public int? BotUserId { get; set; }
        public BotUser BotUser { get; set; }

        public string EnglishVersion { get; set; }
        public string RussianVersion { get; set; }

        public Word() 
        { 

        }
        public Word(string english, string russian)
        {
            EnglishVersion = english;
            RussianVersion = russian;
        }
    }
}
