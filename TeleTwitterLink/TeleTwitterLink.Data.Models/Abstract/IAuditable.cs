using System;
using System.Collections.Generic;
using System.Text;

namespace TeleTwitterLink.Data.Models.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
