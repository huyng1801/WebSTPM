using System;
using System.ComponentModel.DataAnnotations;

namespace WebSTPM.Models
{
    public class NewsEvent
    {
        public int NewsEventID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }
        public int Views { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
