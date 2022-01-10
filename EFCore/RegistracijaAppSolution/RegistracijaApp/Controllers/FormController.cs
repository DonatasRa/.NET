using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistracijaApp.Data;
using RegistracijaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistracijaApp.Controllers
{
    public class FormController : Controller
    {
        private DataContext _context;

        public FormController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int regId)
        {
            var forms = _context.Forms
                .Include(f => f.Questions)
                .ThenInclude(a => a.PossibleAnswers).ToList();

            return View(forms);
        }

        [HttpPost]
        public void Update(Form forms)
        {
            _context.Forms.Update(forms);
            _context.SaveChanges();
        }
    }
}
