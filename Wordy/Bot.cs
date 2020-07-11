using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Wordy
{
    class Bot
    {
        public TelegramBotClient botClient;
        public Bot()
        {
            botClient = new TelegramBotClient("1159601816:AAEvbVVXheEKOI4rO8tHL0FRZCYjZgWYREs");
            botClient.OnMessage += HandleMessage;
            botClient.StartReceiving();
        }
        public void HandleMessage(object sender, MessageEventArgs messageEventArgs)
        {
            ChatId currentChatId = messageEventArgs.Message.Chat.Id;
            botClient.SendTextMessageAsync(currentChatId, "Ok");
            Console.WriteLine(messageEventArgs.Message.Text);
        }
    }
}
