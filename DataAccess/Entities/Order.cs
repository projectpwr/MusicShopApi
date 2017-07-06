using DataAccessInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Order : IEntity
    {

        public int Id { get; set; }
        public byte[] RowVersion { get; set; }

            
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public List<Product> Products { get; set; }

        public double OrderTotal { get; set; }



    }
}
