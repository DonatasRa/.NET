﻿using System.Collections.Generic;

namespace RegistracijaApp.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Answer> Answers { get; set; }
    }
}