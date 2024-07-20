using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {

        public int StudentId { get; set; }

      /*  [Required(ErrorMessage = "StudentName is required.")]
        [StringLength(30, ErrorMessage = "StudentName can't be longer than 30 characters.")]*/
        public string StudentName { get; set;} = string.Empty;


   /*     [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [StringLength(50, ErrorMessage = "Email can't be longer than 50 characters.")]*/
        public string StudentEmail { get; set; } = string.Empty;


     /*   [DataType(DataType.Date), Display(Name = "DateofBirth"), 
         DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]*/
    /*    public DateTime DateofBirth { get; set; }*/


/*
        [Required(ErrorMessage = "Course is required.")]
        [StringLength(30, ErrorMessage = "Course can't be longer than 30 characters.")]*/
        public string Course { get; set; } = string.Empty;


     /*   [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number must contain only digits.")]*/
        public required string PhoneNumber {  get; set; }

      
    }
}
