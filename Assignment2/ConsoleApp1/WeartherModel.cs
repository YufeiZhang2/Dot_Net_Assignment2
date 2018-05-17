namespace ConsoleApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WeartherModel : DbContext
    {
        public WeartherModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<DataDrivenRule> DataDrivenRules { get; set; }
        public virtual DbSet<FixedRule> FixedRules { get; set; }
        public virtual DbSet<WeatherInfo> WeatherInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<DataDrivenRule>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRule>()
                .Property(e => e.QuestionColumn)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRule>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRule>()
                .Property(e => e.AnswerColumn)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRule>()
                .Property(e => e.CurrentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRule>()
                .Property(e => e.LastEditorID)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRule>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRule>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRule>()
                .Property(e => e.CurrentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRule>()
                .Property(e => e.LastEditorID)
                .IsUnicode(false);

            modelBuilder.Entity<WeatherInfo>()
                .Property(e => e.LastMaintainerID)
                .IsUnicode(false);
        }
    }
}
