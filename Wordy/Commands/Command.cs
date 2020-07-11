using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Wordy.Commands
{
    abstract class Command
    {
        public abstract string Name { get; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool ContainsIn(string command) 
        {
            return command.Contains(this.Name) && command.Contains(AppSettings.Name);
        }
    }
}
