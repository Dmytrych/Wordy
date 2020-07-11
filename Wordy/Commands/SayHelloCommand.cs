using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Wordy.Commands
{
    class SayHelloCommand : Command
    {
        public override string Name => "/hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            Console.WriteLine("Executing " + Name + "Command");
            ChatId id = message.Chat.Id;
            await client.SendTextMessageAsync(id, "Oh, hi Mark!");
        }
    }
}
