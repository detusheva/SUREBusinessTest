using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUREBusiness.Models.ViewModels
{
    public class CreateNoteModel
    {
        public UserModel UserInfo { get; set; }
        public NoteModel NoteInfo { get; set; }
    }
}
