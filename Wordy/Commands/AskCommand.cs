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
    class AskCommand : Command
    {
        public override string Name => "/ask";

        public override void Execute(Message message, TelegramBotClient client)
        {
            Console.WriteLine("Executing " + Name + "Command");
            ChatId id = message.Chat.Id;

            using (DictionaryContext db = new DictionaryContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Chat == id.Identifier);
                db.Words.Load();

                if (user.Words.Count == 0)
                {
                    Bot.Get().SendTextMessageAsync(id, "Вы ещё не добавили слов." +
                        "\nЧтобы добавить слово напишите команду \"/add слово перевод\"");
                    return;
                }

                Random rand = new Random();
                Word randWord = user.Words.ToArray()[rand.Next(0, user.Words.Count)];

                user.LastQuizWord = randWord;
                db.SaveChanges();

                Bot.Get().SendTextMessageAsync(id, $"Русская версия слова: {randWord.RussianVersion}" +
                    "\n\nОтправьте ответ в виде \"/answ ответ\".");
            }
        }
    }
}
