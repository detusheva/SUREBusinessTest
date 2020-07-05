using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SUREBusiness.Models
{
    public class NoteModel
    {
        public int NoteId { get; set; }
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Een naam is verplicht")]
        [DisplayName("Achternaam")]
        public string CustomerName { get; set; }
        public string ManagerName { get; set; }
        public string CategoryName { get; set; }
        public bool IsCompleted { get; set; }
        [Required(ErrorMessage = "Een telefoonnummer is verplicht")]
        [DisplayName("Telefoonnummer")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geen geldig telefoonnummer")]
        public string MobileNumber { get; set; }
        public string Description { get; set; }
    }
}
