using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AnnotationExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author = new Author();
            Console.WriteLine("Enter First Name");
            author.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            author.LastName = Console.ReadLine();
            Console.WriteLine("Enter Phone Number #");
            author.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Email ID");
            author.Email = Console.ReadLine();
            Console.WriteLine();

            ValidationContext context = new ValidationContext(author, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(author, context, validationResults, true);
            if (!valid)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine("{0}", validationResult.ErrorMessage);
                }
            }
            else
            {
                Console.WriteLine("First Name :" + author.FirstName);
                Console.WriteLine("Last Name :" + author.LastName);
                Console.WriteLine("Phone Number :" + author.PhoneNumber);
                Console.WriteLine("Email ID :" + author.Email);

            }
            Console.ReadKey();
        }
    }

    public class Author
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FirstName should be minimum 3 characters and maximum 50 characters")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter of the first name should be capital and only characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "FirstName should be minimum 3 characters and maximum 50 characters")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "The first letter of the lastname should be capital and only characters")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid Email ID")]
        public string Email { get; set; }
    }
}
