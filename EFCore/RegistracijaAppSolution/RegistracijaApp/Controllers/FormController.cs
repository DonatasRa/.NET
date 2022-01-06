using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistracijaApp.Data;
using RegistracijaApp.Models;
using RegistracijaApp.Repositories;
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

        //private AnswerRepository _answerRepository;

        //private QuestionRepository _questionRepository;

        //private FormRepository _formRepository;

        //

        //public FormController(AnswerRepository answerRepository, QuestionRepository questionRepository, FormRepository formRepository)
        //{
        //    _answerRepository = answerRepository;
        //    _questionRepository = questionRepository;
        //    _formRepository = formRepository;
        //}

        public IActionResult Index()
        {
            var forms = _context.Forms
                .Include(f => f.Questions)
                .ThenInclude(a => a.PossibleAnswers).ToList();

            return View(forms);
        }
    }
}
