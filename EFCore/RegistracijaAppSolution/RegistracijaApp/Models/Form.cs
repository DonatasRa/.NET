using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistracijaApp.Models
{
    public class Form : Entity
    {
        public string Title { get; set; }
        public List<Question> Questions { get; set; }

    }
}
