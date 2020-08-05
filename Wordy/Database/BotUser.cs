using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace Wordy.Database
{
    class BotUser
    {
        public int Id { get; set; }
        public long? Chat { get; set; }

        public Word LastQuizWord { get; set; }
        public ICollection<Word> Words { get; set; }
        public BotUser()
        {
            Words = new List<Word>();
        }
    }
}
