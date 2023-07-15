using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todolist.Models;

namespace todolist.Data
{
    public class DbInitializer
    {
        public static void Initialize(ToDoListDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any cards.
            if (context.Card.Any())
            {
                return;   // DB has been seeded
            }

            var cards = new Card[]
            {
            new Card{id=1,name="Card 4",content="Verify defect 4",create_at=DateTime.Now},
            new Card{id=2,name="Card 6",content="Verify defect 6",create_at=DateTime.Now},
            };
            foreach (Card s in cards)
            {
                context.Card.Add(s);
            }
            context.SaveChanges();
        }

    }
}
