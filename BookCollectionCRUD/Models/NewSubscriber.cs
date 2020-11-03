using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookCollectionCRUD.Models
{
    public class NewSubscriber
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string BookAuthor { get; set; }

        public int BookYear { get; set; }

        public int Price { get; set; }

        public string SubscriberName { get; set; }

        public string SubscriberEmail { get; set; }
    }
}
