using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUREBusiness.Models
{
    public class NoteModel
    {
        public int NoteId { get; set; }
        public DateTime DateTime { get; set; }
        public string CustomerId { get; set; }
        public int ManagerId { get; set; }
        public string CategoryName { get; set; }
        public bool IsCompleted { get; set; }

        public IEnumerable<SelectListItem> Managers { get; set; }
    }
}
