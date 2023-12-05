
﻿using System;
﻿using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASI.Basecode.Data.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string content { get; set; }
        public int Rating { get; set; }
        public string BookId { get; set; }
        public DateTime dateReviewed { get; set; }
        public virtual Book Book { get; set; }
    }
}

