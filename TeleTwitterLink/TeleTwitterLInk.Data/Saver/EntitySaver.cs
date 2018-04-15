using System;
using System.Collections.Generic;
using System.Text;

namespace TeleTwitterLInk.Data.Saver
{
    public class EntitySaver : ISaver
    {
        private readonly TeleTwitterLinkDbContext context;

        public EntitySaver(TeleTwitterLinkDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
