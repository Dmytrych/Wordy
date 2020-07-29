using System;
using System.Collections.Generic;
using System.Text;
using Wordy.Database;
using System.Data.Common;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Data.Entity;
using System.Linq;
using System.Net.WebSockets;

namespace Wordy.Commands
{
    class ShowUserWordsCommand : Command
    {
        public override string Name => "/showWords";

        public override void Execute(Message message, TelegramBotClient client)
        {
            Console.WriteLine("Executing " + Name + "Command");
            ChatId id = message.Chat.Id;

            using (DictionaryContext db = new DictionaryContext())
            {
                //Checking if user already exists in database, creating new if not
                var user = db.Users.FirstOrDefault(x => x.Chat == id.Identifier);
                db.Words.Load();

                if (user == null || user.Words.Count == 0)
                {
                    Bot.Get().SendTextMessageAsync(id, "Вы ещё не добавили слов." +
                        "\nЧтобы добавить слово напишите команду \"/add слово перевод\"");
                    return;
                }

                string replyMessage = "Все добавленные вами слова:\n";
                foreach (Word w in user.Words)
                {
                    replyMessage += $" {w.EnglishVersion} - {w.RussianVersion}\n";
                }

                Bot.Get().SendTextMessageAsync(id, replyMessage);
            }
        }
    }
}
