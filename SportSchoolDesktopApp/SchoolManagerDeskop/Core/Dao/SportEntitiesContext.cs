using SchoolManagerDeskop.Core.Dao.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerDeskop.Core.Dao
{
    public class SportEntitiesContext : DbContext
    {
        public SportEntitiesContext() : base("name=DefaultConnection")
        {
        }

        public SportEntitiesContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<ScheduleSubject> ScheduleSubjects { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<StudentInSession> StudentsInSessions { get; set; }
    }
}
