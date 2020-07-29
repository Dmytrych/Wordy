using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Wordy.Commands
{
    class ButtonTestCommand : Command
    {
        public override string Name => "/testButton";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            Console.WriteLine("Executing " + Name + "Command");
            ChatId id = message.Chat.Id;
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Ok", "https://ru.stackoverflow.com/questions/789457/c-%D0%9E%D0%B1%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%BA%D0%B0-%D0%BD%D0%B0%D0%B6%D0%B0%D1%82%D0%B8%D1%8F-inline-%D0%B8-reply-%D0%BA%D0%BD%D0%BE%D0%BF%D0%BE%D0%BA-%D0%B4%D0%BB%D1%8F-%D0%B1%D0%BE%D1%82%D0%B0-telegram"));
            await client.SendTextMessageAsync(id, "Press OK", replyMarkup: markup);
        }
    }
}
