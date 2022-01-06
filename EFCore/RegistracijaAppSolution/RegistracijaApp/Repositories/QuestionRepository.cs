using Microsoft.EntityFrameworkCore;
using RegistracijaApp.Data;
using RegistracijaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistracijaApp.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>
    {
        public QuestionRepository(DataContext context) : base(context)
        {
        }
            public new List<Question> GetAll()
            {
            return _context.Questions.ToList();
            }
    }
}
