using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SUREBusiness.Models;
using SUREBusiness.Models.ViewModels;
using SUREBusiness.Repository;

namespace SUREBusiness.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepo;
        private readonly IUserRepository _userRepo;
        private readonly IManagerRepository _managerRepo;

        public NoteController(
            INoteRepository noteRepo,
            IUserRepository userRepo,
            IManagerRepository managerRepo)
        {
            _noteRepo = noteRepo;
            _userRepo = userRepo;
            _managerRepo = managerRepo;
        }

         List<SelectListItem> categories = new List<SelectListItem>
            {
                new SelectListItem{Value = "Terugbellen", Text = "Terugbellen"},
                new SelectListItem{Value = "Terugbellen spoed", Text = "Terugbellen spoed"}
            };

        [HttpGet]
        public async Task<IActionResult> CreateNote()
        {
            ViewBag.ManagerNames = _managerRepo.GetManagerList();
            ViewBag.CategoriesName = categories;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateNote(CreateNoteModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.CategoriesName = categories;
            ViewBag.ManagerNames = _managerRepo.GetManagerList();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.UserInfo.UserId = userId;
            if (model.UserInfo.UserId != null)
            {
                await _noteRepo.CreateNote(model.NoteInfo);
                await _userRepo.UpdateUser(model.UserInfo);
                return RedirectToRoute(new { controller = "Note", action = "Index" });
            }
            return RedirectToRoute(new { controller = "Note", action = "Index" });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}