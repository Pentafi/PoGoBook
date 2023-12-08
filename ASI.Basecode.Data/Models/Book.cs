﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASI.Basecode.Data.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }


        // Many-to-Many relationship 
        public virtual ICollection<AuthorBooks> AuthorBooks { get; set; } = new List<AuthorBooks>();
        public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
