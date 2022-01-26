using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string Content { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
        public string Message { get; set; }

    }
}
