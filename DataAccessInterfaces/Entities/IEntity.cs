using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterfaces.Entities
{
    interface IEntity
    {
        int Id { get; set; }
        byte[] RowVersion { get; set; }
    }
}
