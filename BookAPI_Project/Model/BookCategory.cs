﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI_Project.Model
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public Book Book { get; set; }
        public Category Category { get; set; }
    }
}
