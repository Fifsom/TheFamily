using System.ComponentModel.DataAnnotations;

namespace TheFamily.Entities
{
    public class Player
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required and has to be less than 50 characters.")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string FavFood { get; set; }
        public string ImgName { get; set; }
        public int? Wins { get; set; }
        public int? Loses { get; set; }
    }
}
