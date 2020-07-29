using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace Wordy.Database
{
    class DictionaryContext : DbContext
    {
        public DictionaryContext() : base("WordDB") 
        { }

        public DbSet<BotUser> Users { get; set; }
        public DbSet<Word> Words { get; set; }
    }
}
