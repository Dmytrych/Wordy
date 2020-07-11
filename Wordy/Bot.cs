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

            commands = new List<Command>();
            commands.Add(new SayHelloCommand());
            commands.Add(new ButtonTestCommand());

            botClient.StartReceiving();
        }

        public static TelegramBotClient Get()
        {
            Start();
            return botClient;
        }
    }
}
