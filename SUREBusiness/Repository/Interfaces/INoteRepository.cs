﻿using SUREBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUREBusiness.Repository
{
    public interface INoteRepository
    {
        Task CreateNote(NoteModel model);
        Task<List<NoteModel>> GetAllNotes();
        Task<NoteModel> GetNoteById(int id);
    }
}