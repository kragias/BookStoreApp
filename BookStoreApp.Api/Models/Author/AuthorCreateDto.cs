using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Api.Models.Author
{
    public class AuthorCreateDto
    {
        [Required]
        [StringLength(60)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(60)]
        public string LastName { get; set; }
        public string Bio { get; set; }

    }
}
