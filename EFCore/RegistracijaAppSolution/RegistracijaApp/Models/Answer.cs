using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistracijaApp.Models
{
    public class Answer : Entity
    {
        public string Value { get; set; }
        [Required]
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
