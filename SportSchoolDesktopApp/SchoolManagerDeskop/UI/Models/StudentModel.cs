﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.UI.Models
{
    public interface IDisplayableModel
    {
        string ItemCaption { get; }
    }

    public class StudentModel : IDisplayableModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? Birdth { get; set; }
        public string Phone { get; set; }

        public string ItemCaption => $"[{Id}] {FirstName} {MiddleName} {LastName}";
    }
}