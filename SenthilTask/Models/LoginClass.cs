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
    public class LoginClass
    {

        [Required(ErrorMessage = "Email is required")]
        //[RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; } = "";


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        //[StringLength(16, MinimumLength = 8,
        //ErrorMessage = "Password must have min length of 8 and max Length of 16")]
        //[RegularExpression(@"^([A-Za-z]*[-._!@#$%^&*][A-Za-z]*)(?:[1-9]|0[1-9]|10)$")]


        public string? Password { get; set; }
    }
}
