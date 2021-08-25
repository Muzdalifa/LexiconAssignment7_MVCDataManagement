﻿using LexiconAssignment7_MVCDataManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LexiconAssignment7_MVCDataManagement.ViewModels
{
    public class CreatePersonViewModel
    {
        
        public Person Person { get; set; }

        [DisplayName("Name : ")]
        [Required(ErrorMessage = "You need to fill out name field!")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("City : ")]
        [Required(ErrorMessage = "You need to fill out city field!")]
        [StringLength(50)]
        public string City { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone number : ")]
        [Required(ErrorMessage = "You need to fill out phone number field!")]
        public string PhoneNumber { get; set; }
        InMemoryPeopleRepo InMemoryPeopleRepo { get; set; }

}
}