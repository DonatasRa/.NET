using RegistracijaApp.Models;
using RegistracijaApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RegistracijaApp.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer>
    {
        public AnswerRepository(DataContext context) : base(context)
        {
        }

        public new List<Answer> GetAll()
        {
            return _context.Answers.Include(q => q.QuestionId).ToList();
        }
    }
}
