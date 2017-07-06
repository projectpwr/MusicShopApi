using DataAccessInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }

        public int Name { get; set; }

    }
}
