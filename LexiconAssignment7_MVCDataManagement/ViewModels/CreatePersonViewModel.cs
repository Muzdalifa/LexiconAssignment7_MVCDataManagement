using LexiconAssignment7_MVCDataManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CreatePersonViewModel
    {

        //[DisplayName("Name : ")]
        [Required(ErrorMessage = "You need to fill out name field!")]
        [StringLength(50)]
        public string Name { set; get; }

        //[DisplayName("City : ")]
        [Required(ErrorMessage = "You need to fill out city field!")]
        [StringLength(50)]
        public string City { set; get; }

        [DataType(DataType.PhoneNumber)]
        //[DisplayName("Phone number : ")]
        [Required(ErrorMessage = "You need to fill out phone number field!")]
        [RegularExpression(@"[+][0-9]*$", ErrorMessage = "Please start with country code ")]
        public string PhoneNumber { set; get; }

    }
}