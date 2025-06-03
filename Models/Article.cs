using System.ComponentModel.DataAnnotations;

namespace HygeeaMind.Models
{
    public class Article
    {
        public int Id { get; set; }

        // Proprietati
        [Required(ErrorMessage = "Titlul este obligatoriu.")]
        [StringLength(200, ErrorMessage = "Titlul nu poate depăși 200 de caractere.")]
        [Display(Name = "Titlu Articol")]
        public required string Title { get; set; } 

        [Required(ErrorMessage = "Conținutul este obligatoriu.")]
        [Display(Name = "Conținut Articol")]
        public required string Content { get; set; }

        [Display(Name = "Imagine (URL)")]
        [Url(ErrorMessage = "Adresa URL a imaginii nu este validă.")]
        public string? ImageUrl { get; set; } 
                                             

        [Display(Name = "Data Publicării")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; } = DateTime.Now;
    }
}