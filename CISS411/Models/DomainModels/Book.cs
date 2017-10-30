﻿using System.ComponentModel.DataAnnotations;

namespace CISS411.Models.DomainModels
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsCurrent { get; set; }
        public string ImageFilename { get; set; }
        public string Description { get; set; }
        public string AmazonLink { get; set; }
    }
}
