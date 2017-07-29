using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TextMatch.Models
{
    public class TextSearchViewModel
    {
        [Required(ErrorMessage ="Please enter text here")]
        [DisplayName ("Long Text")]
        public string LongText { get; set; }

        [Required(ErrorMessage = "Please enter search text here")]
        [DisplayName("Search Text")]
        public string SearchText { get; set; }

        public string Result { get; set; }

    }
}