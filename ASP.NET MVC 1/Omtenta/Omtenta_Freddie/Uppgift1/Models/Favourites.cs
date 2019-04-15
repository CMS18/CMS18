using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Uppgift1.Models
{
    public class Favourites
    {
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Range(13, 99)]
        [Required(ErrorMessage = "Enter an age between 13 and 99")]
        public int Age { get; set; }



        [Required(ErrorMessage = "Pick a season")]
        public string Season { get; set; }
        [Required(ErrorMessage = "Candy is required")]
        public string Candy { get; set; }


        public List<string> Candies { get; set; }
        public List<string> Seasons { get; set; }


        public Favourites()
        {
            Seasons = new List<string>();
            Candies = new List<string>();
        }

    }
}
