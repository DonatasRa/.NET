using RegistracijaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistracijaApp.DTOs
{
    public class CreateForm
    {
        public Question Question { get; set; }

        public List<int> SelectedAnswerId { get; set; }

        public List<Answer> Answers { get; set;}
    }
}
