using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todolist.Models;

namespace todolist.Data
{
    public class ToDoListDBContext:DbContext
    {
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) :base()
        {

        }

        public DbSet<Card> Card { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Card");
        }
    }
}
