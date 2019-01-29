namespace SportSchoolDesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string Days { get; set; }

        public int TimeStart { get; set; }

        public int Hall { get; set; }

        public bool IsPeriodic { get; set; }

        public int GroupId { get; set; }

        public virtual Groups Groups { get; set; }
    }
}
