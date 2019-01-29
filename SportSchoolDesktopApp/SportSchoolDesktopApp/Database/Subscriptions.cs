namespace SportSchoolDesktopApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscriptions
    {
        [Key]
        public int SubscriptionId { get; set; }

        public int StudentId { get; set; }

        public int GroupId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime BuyTime { get; set; }

        public bool IsUnlimited { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStart { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEnd { get; set; }

        public int? SubHoursMax { get; set; }

        public int SubHoursLeft { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual Students Students { get; set; }
    }
}
