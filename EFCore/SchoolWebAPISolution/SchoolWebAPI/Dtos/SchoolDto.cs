using SchoolWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebAPI.Dtos
{
    public class SchoolDto
    {
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public List<Student> Students { get; set; }
    }
}
