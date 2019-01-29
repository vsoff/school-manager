namespace SportSchoolDesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentsInSessions
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SessionId { get; set; }

        public virtual Sessions Sessions { get; set; }

        public virtual Students Students { get; set; }
    }
}
