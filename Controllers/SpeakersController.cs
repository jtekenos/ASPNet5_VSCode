using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using mvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace mvc5.Controllers
{
    public class SpeakersController : Controller {
      private SpeakersContext _context { get; set; }
    
    
      public SpeakersController(SpeakersContext context) {
          _context = context;
      }
    
      public IActionResult Index() {
          return View(_context.Speakers.ToList());
      }
    
      public ActionResult Create() {
          ViewBag.Items = GetSpeakersListItems();
          return View();
      }
    
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> Create(Speaker speaker) {
          if (ModelState.IsValid) {
              _context.Speakers.Add(speaker);
              await _context.SaveChangesAsync();
              return RedirectToAction("Index");
          }
          return View(speaker);
      }
    
      public ActionResult Details(int id) {
          Speaker speaker = _context.Speakers
              .Where(b => b.SpeakerId == id)
              .FirstOrDefault();
          if (speaker == null) {
              return HttpNotFound();
          }
          return View(speaker);
      }
    
      private IEnumerable<SelectListItem> GetSpeakersListItems(int selected = -1) {
          var tmp = _context.Speakers.ToList();
    
          // Create authors list for <select> dropdown
          return tmp
              .OrderBy(s => s.FirstName)
              .Select(s => new SelectListItem
              {
                  Text = String.Format("{0}, {1}", s.FirstName),
                  Value = s.SpeakerId.ToString(),
                  Selected = s.SpeakerId == selected
              });
      }

 
  }

}
