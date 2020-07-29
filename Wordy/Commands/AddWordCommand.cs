using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.IO;
using Wordy.Database;
using System.Linq;
using System.Data.Common;

namespace Wordy.Commands
{
    class AddWordCommand : Command
    {
        public override string Name => "/add";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            Console.WriteLine("Executing " + Name + "Command");
            ChatId id = message.Chat.Id;

            //Splitting message "/add word definition"
            string[] messageArgs = message.Text.Split();

            //If input is not correct
            if(messageArgs.Length != 3)
            {
                string errorMessage = "Неправильный формат комманды" +
                    "\nПроверьте, или комманда соответствует шаблону \"/add слово перевод\"";
                await client.SendTextMessageAsync(id, errorMessage);
                return;
            }

            //TODO: move user creating and db operations to separate class
            using(DictionaryContext db = new DictionaryContext())
            {
                //Checking if user already exists in database, creating new if not
                var user = db.Users.FirstOrDefault(x => x.Chat == id.Identifier);
                if(user == null)
                {
                    user = new BotUser { Chat = id.Identifier};
                    db.Users.Add(user);
                }

                //Adding word to users dictionary
                Word word = new Word(messageArgs[1], messageArgs[2]);
                user.Words.Add(word);

                //Updating data in database
                db.SaveChanges();
            }

            await Bot.Get().SendTextMessageAsync(id, "Новое слово добавлено в ваш словарь" +
                "\nEnglish: " + messageArgs[1] +
                "\nПеревод: " + messageArgs[2]);
        }
    }
}
