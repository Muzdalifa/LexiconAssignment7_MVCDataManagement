using LexiconAssignment7_MVCDataManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required(ErrorMessage = "You need to fill out name field!")]
        [RegularExpression(@"[A-zöåä]*", ErrorMessage = "Use only alphabets.")]
        [MinLength(2),MaxLength(50)]
        //[StringLength(50)]
        public string Name { set; get; }

        [Required(ErrorMessage = "You need to fill out city field!")]
        [RegularExpression(@"[0-9A-zåäö-]*", ErrorMessage = "You can not use special character.")]
        [MinLength(2), MaxLength(50)]
        public string City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MinLength(12), MaxLength(13)]
        [Required(ErrorMessage = "You need to fill out phone number field!")]
        [RegularExpression(@"[+][0-9]*$", ErrorMessage = "Please start with country code(+) and include numbers only ")]
        public string PhoneNumber { set; get; }

    }
}