using System;
using System.Collections.Generic;
using System.Text;

namespace TeleTwitterLink.Data.Models.Abstract
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
