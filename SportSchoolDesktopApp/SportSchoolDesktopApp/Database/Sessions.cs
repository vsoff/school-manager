namespace SportSchoolDesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sessions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sessions()
        {
            StudentsInSessions = new HashSet<StudentsInSessions>();
        }

        [Key]
        public int SessionId { get; set; }

        public int GroupId { get; set; }

        public TimeSpan Time { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Groups Groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsInSessions> StudentsInSessions { get; set; }
    }
}
