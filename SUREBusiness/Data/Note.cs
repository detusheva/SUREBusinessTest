using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SUREBusiness.Data
{
    [Table("Note")]
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public DateTime DateTime { get; set; }
        [ForeignKey("AspNetUser")]
        public string CustomerId { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public string CategoryName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
