using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

//o For the Rating field, use a dropdown menu (G, PG, PG-13, R).
//o For the Edited field, we want that to be a yes/no (true/false) option.
//o The “Edited”, “Lent To”, and “Notes” fields are optional. All other fields must be entered.
//o Notes should be limited to 25 characters

