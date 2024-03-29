﻿using System;

namespace CompanyEcosystem.PL.Models
{
    public class QuestionnaireViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public byte[] PhotoBytes { get; set; }
        public string AboutMyself { get; set; }
        public string LinkToLinkedIn { get; set; }

        public string Email { get; set; }
        public string Position { get; set; }
    }
}
