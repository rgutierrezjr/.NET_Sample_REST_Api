using System.ComponentModel.DataAnnotations;

namespace RESTApiSample.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "First Name is too long. First name cannot exceed 10 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Last Name is too long. Last name cannot exceed 10 characters.")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public User(int id, string firstName, string lastName, string email, string password)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}