using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Wordy.Database;

namespace Wordy.Commands
{
    class StartCommand : Command
    {
        public override string Name => "/start";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            Console.WriteLine("Executing " + Name + "Command");
            ChatId id = message.Chat.Id;

            await client.SendTextMessageAsync(id, "Здравствуйте." +
                "\nЧтобы добавить слово напишите комманду:" +
                "\n \"/add слово перевод\"" +
                "\n" +
                "\nЧтобы просмотреть список добавленных слов введите:" +
                "\n \"/showWords\"" +
                "\n" +
                "\nЧтобы практиковаться введите комманду" +
                "\n \"/ask\"");

            //Creating a new user
            using(DictionaryContext db = new DictionaryContext())
            {
                db.Users.Load();

                foreach(BotUser u in db.Users)
                {
                    if(u.Chat == id.Identifier)
                    {
                        return;
                    }
                }

                db.Users.Add(new BotUser { Chat = id.Identifier });
                db.SaveChanges();
            }
        }
    }
}
