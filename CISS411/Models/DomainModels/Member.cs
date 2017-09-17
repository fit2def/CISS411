﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CISS411.Models.DomainModels
{
    public class Member : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Major Major { get; set; }
        List<string> Interests { get; set; }
        public Book CurrentBook { get; set; }
        public int EventsAttended { get; set; } 
        
    }

    public enum Major
    {
        NoneGiven,
        Undecided,
        Science, 
        Math,
        English
    }
}