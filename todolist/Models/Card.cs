using System;
using System.ComponentModel.DataAnnotations;

namespace todolist.Models
{
    public class Card
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Id is required")]

        public string name { get; set; }

        public string content { get; set; }

        public DateTime create_at { get; set; } = DateTime.Now;
    }
}
