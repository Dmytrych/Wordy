using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Wordy.Commands;

namespace Wordy
{
    static class CommandProcessor
    {
        public static void RunCommand(object sender, MessageEventArgs e)
        {
            var client = Bot.Get();
            string incomingCommand = e.Message.Text;
            
            foreach(Command command in Bot.GetCommands)
            {
                if (command.ContainsIn(incomingCommand))
                {
                    command.Execute(e.Message, client);
                    break;
                }
            }
        }
    }
}
