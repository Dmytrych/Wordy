using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Wordy.Commands;
using System.Threading.Tasks;

namespace Wordy
{
    static class Bot
    {
        private static TelegramBotClient botClient;

        private static List<Command> commands;

        public static IReadOnlyCollection<Command> GetCommands { get => commands.AsReadOnly(); }

        public static void Start()
        {
            if(botClient != null)
            {
                return;
            }

            botClient = new TelegramBotClient(AppSettings.APIToken);
            botClient.OnMessage += CommandProcessor.RunCommand;

            //Add new commands here
            commands = new List<Command>();
            commands.Add(new SayHelloCommand());
            commands.Add(new AddWordCommand());
            commands.Add(new ShowUserWordsCommand());

            botClient.StartReceiving();
        }

        public static TelegramBotClient Get()
        {
            Start();
            return botClient;
        }
    }
}
