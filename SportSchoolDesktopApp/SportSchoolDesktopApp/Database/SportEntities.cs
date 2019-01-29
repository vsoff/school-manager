namespace SportSchoolDesktopApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SportEntities : DbContext
    {
        public SportEntities()
            : base("name=SportEntities1")
        {
        }

        public SportEntities(string cs)
            : base(cs)
        {
        }

        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsInSessions> StudentsInSessions { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<Trainers> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Groups>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Schedule)
                .WithRequired(e => e.Groups)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Sessions)
                .WithRequired(e => e.Groups)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Groups)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Schedule>()
                .Property(e => e.Days)
                .IsUnicode(false);

            modelBuilder.Entity<Sessions>()
                .HasMany(e => e.StudentsInSessions)
                .WithRequired(e => e.Sessions)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.StudentsInSessions)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Students>()
                .HasMany(e => e.Subscriptions)
                .WithRequired(e => e.Students)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainers>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainers>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Trainers>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.Trainers)
                .WillCascadeOnDelete(false);
        }
    }
}
