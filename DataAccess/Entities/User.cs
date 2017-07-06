using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess.Entities
{
    public class User : IdentityUser
    {

        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
