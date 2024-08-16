using System.ComponentModel.DataAnnotations;

namespace RazorPagesFilmes.Model
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        
        [Display (Name = "Release Data")]
        [DataType(DataType.Date)]
        public DateTime ReleaseData { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}