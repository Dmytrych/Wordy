using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Wordy.Database;

namespace Wordy.Commands
{
    class QuestionAnswerCommand : Command
    {
        public override string Name => "/answ";

        public override void Execute(Message message, TelegramBotClient client)
        {
            Console.WriteLine("Executing " + Name + "Command");
            ChatId id = message.Chat.Id;

            using(DictionaryContext db = new DictionaryContext())
            {
                db.Words.Load();
                var user = db.Users.FirstOrDefault(x => x.Chat == id.Identifier);
                if(user == null)
                {
                    user = new BotUser { Chat = id.Identifier };
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                if (user.LastQuizWord == null)
                {
                    return;
                }

                string answer = message.Text.Replace(Name + " ", "");
                string reply = "";
                if (user.LastQuizWord.EnglishVersion.ToLower() == answer.ToLower())
                {
                    reply = "Правильно! Чтобы продолжить введите \"/ask\"";
                }
                else
                {
                    reply = $"Правильный ответ:  {user.LastQuizWord.EnglishVersion}" +
                        $"\nВаш ответ:  {answer}";
                }

                Bot.Get().SendTextMessageAsync(id, reply);

                user.LastQuizWord = null;
                db.SaveChanges();
            }
        }
    }
}
