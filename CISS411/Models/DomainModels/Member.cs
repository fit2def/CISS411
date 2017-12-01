using Microsoft.AspNetCore.Identity;
using System;
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
        public int BookID { get; set; }
        public DateTime? DateDue { get; set; }
        
    }

    public enum Major
    {
        Undecided,
        GeneralStudies,
        BusinessMarketing,
        ComputerScienceMath,
        CriminalJusticeHumanServices,
        Education,
        FineArtsMusic,
        HistoryPhilosophyPoliSci,
        EnglishLiteratureCommunication,
        ScienceNursing, 
        PsychologySociology
    }
}
