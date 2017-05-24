using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterfaces.Entities
{
    public interface IEntity
    {
        int Id { get; }
        byte[] RowVersion { get; }
    }
}
