using Microsoft.EntityFrameworkCore;
using RegistracijaApp.Data;
using RegistracijaApp.DTOs;
using RegistracijaApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace RegistracijaApp.Repositories
{
    public class FormRepository : RepositoryBase<CreateForm>
    {

        public FormRepository(DataContext context) : base(context)
        {
        }

        //public new List<CreateForm> GetAll()
        //{
        //    return _context.Questions.Include(a => a.Answers).ToList();
        //}

    }
}
