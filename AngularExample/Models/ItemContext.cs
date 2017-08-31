using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AngularExample.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
    }

    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemId { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}