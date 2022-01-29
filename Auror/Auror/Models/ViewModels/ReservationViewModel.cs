using Auror.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auror.Models.ViewModels
{
    public class ReservationViewModel : IValidatableObject
    {
        [Required]
        public DateTime CheckIn { get; set; }
        [Required]
        public DateTime CheckOut { get; set; }
        public int PeopleCount { get; set; }
        public int? RoomId { get; set; }
        public decimal TotalPrice { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int GenderId { get; set; }
        public List<Gender> Gender { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CheckOut < CheckIn)
            {
                yield return new ValidationResult(
                    errorMessage: "Check In date must be greater than Check Out",
                    memberNames: new[] { "CheckOut" }
               );
            }
        }
    }
}
