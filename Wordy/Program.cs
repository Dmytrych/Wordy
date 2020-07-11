using System;

namespace Wordy
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            while(true)
            {
                bot.botClient.StartReceiving();
            }
        }
    }
}
