using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SenthilTask.Models
{
    public class UserClass
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Please Enter FirstName..")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter LastName..")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        //[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; } = "";
        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string? MobileNo { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8,
        ErrorMessage = "Password must have min length of 8 and max Length of 16")]
        [RegularExpression(@"^([A-Za-z]*[-._!@#$%^&*][A-Za-z]*)(?:[1-9]|0[1-9]|10)$", ErrorMessage = "Password should contain 1 Special and 1 Numeric character!")]
       
        
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
