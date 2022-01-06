using System.Collections.Generic;

namespace RegistracijaApp.Models
{
    public class Question : Entity
    {
        public string Title { get; set; }

        public int? AnswerId { get; set; }

        public List<Answer> PossibleAnswers { get; set; }

        public int FormId { get; set; }
    }
}
