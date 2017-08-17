using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel;

namespace DataAccess.Entities
{
    public class User : IdentityUser
    {
        [DisplayName("AddressId")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
