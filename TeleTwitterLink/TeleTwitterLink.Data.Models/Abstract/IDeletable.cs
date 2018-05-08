using System;

namespace TeleTwitterLink.Data.Models.Abstract
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
