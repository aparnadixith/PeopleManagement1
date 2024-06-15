using System.ComponentModel.DataAnnotations;

namespace PeopleManagement.Models.ViewModel
{
    public class CreatePersonViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Phone]
        public int PhoneNumber { get; set; }   
        [Required]
        public string City { get; set; }

    }
}
