using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Models
{
    public class TalkModel
    {
        public int TalkId { get; set; }
        [Required]
        [StringLength(40,MinimumLength=10)]
        public string Title { get; set; }
        [Required]
        [StringLength(200,MinimumLength = 10)]
        public string Abstract { get; set; }
        [Range(100,400)]
        public int Level { get; set; }
        public SpeakerModel Speaker { get; set; }
    }
}
