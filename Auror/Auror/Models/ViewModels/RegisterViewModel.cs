using Auror.Models.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string GenderId { get; set; }
        public List<Gender> Gender { get; set; }
        [NotMapped]
        public IFormFile ProfilePicture { get; set; }
    }
}
