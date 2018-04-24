using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TeleTwitterLink.Data.Models.Abstract;

namespace TeleTwitterLink.Data.Models
{
    public class User : IdentityUser, IDeletable, IAuditable
    {
        public string TestName { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public ICollection<UserTwitterUser> TwitterUsers { get; set; }
    }
}
