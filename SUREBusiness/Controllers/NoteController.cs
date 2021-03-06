﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUREBusiness.Data;
using SUREBusiness.Models;
using SUREBusiness.Repository;

namespace SUREBusiness.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepo;

        public NoteController(
            INoteRepository noteRepo)
        {
            _noteRepo = noteRepo;
        }

         List<SelectListItem> categories = new List<SelectListItem>
            {
                new SelectListItem{Value = "Terugbellen", Text = "Terugbellen"},
                new SelectListItem{Value = "Terugbellen spoed", Text = "Terugbellen spoed"}
            };

        List<SelectListItem> managers = new List<SelectListItem>
            {
                new SelectListItem{Value = "Ellis", Text = "Ellis"},
                new SelectListItem{Value = "Julian", Text = "Julian"}
            };

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.ManagerNames = managers;
            ViewBag.CategoriesName = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(NoteModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.CategoriesName = categories;
            ViewBag.ManagerNames = managers;

            await _noteRepo.Add(model);
            return RedirectToRoute(new { controller = "Note", action = "GetAllNotes" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            List<NoteModel> result = await _noteRepo.GetAllNotes();
            return View(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetNoteDetails (int NoteId)
        {
            NoteModel result = await _noteRepo.GetNoteById(NoteId);
            return View(result);
        }
        [HttpPost]
        public async Task<JsonResult> ChangeStatus ([FromBody] NoteModel model)
        {
            Note note = await _noteRepo.ChangeStatus(model);

            return Json(note);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}