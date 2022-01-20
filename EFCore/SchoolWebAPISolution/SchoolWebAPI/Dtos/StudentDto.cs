using SchoolWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebAPI.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int SchoolId { get; set; }
    }
}
