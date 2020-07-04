using Microsoft.EntityFrameworkCore;
using SUREBusiness.Data;
using SUREBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SUREBusiness.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext context;
        public NoteRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        //get all notities
        public async Task<List<NoteModel>> GetAllNotes()
        {
            var allNotities = context.Notes
                .Select(p => new NoteModel
                {
                    NoteId = p.NoteId,
                    DateTime = p.DateTime,
                    CategoryName = p.CategoryName,
                    CustomerName = p.CustomerName,
                    IsCompleted = p.IsCompleted,
                    ManagerName = p.ManagerName
                });
            return await allNotities.OrderBy(m => m.DateTime).ToListAsync();
        }
        //find one notitie
        public async Task<NoteModel> GetNoteById(int id)
        {
            var note = await context.Notes.Where(p => p.NoteId == id).SingleOrDefaultAsync();

            return new NoteModel
            {
                NoteId = note.NoteId,
                DateTime = note.DateTime,
                CategoryName = note.CategoryName,
                CustomerName = note.CustomerName,
                IsCompleted = note.IsCompleted,
                ManagerName = note.ManagerName
            };
        }
        public async Task CreateNote(NoteModel model)
        {
            Note newNote = new Note()
            {
                NoteId = model.NoteId,
                DateTime = DateTime.Now,
                CategoryName = model.CategoryName,
                CustomerName = model.CustomerName,
                IsCompleted = model.IsCompleted,
                ManagerName = model.ManagerName
            };

            context.Notes.Add(newNote);
            await context.SaveChangesAsync();
        }
        public async Task<Note> ChangeStatus(NoteModel model)
        {
            Note note = await context.Notes.Where(p => p.NoteId == model.NoteId).SingleOrDefaultAsync();
            note.IsCompleted = model.IsCompleted;
            await context.SaveChangesAsync();
            return note;
        }
    }
}
