namespace Assignment2.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DataDrivenRules> DataDrivenRules { get; set; }
        public virtual DbSet<FixedRules> FixedRules { get; set; }
        public virtual DbSet<WeatherInfo> WeatherInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<DataDrivenRules>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRules>()
                .Property(e => e.QuestionColumn)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRules>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRules>()
                .Property(e => e.AnswerColumn)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRules>()
                .Property(e => e.CurrentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<DataDrivenRules>()
                .Property(e => e.LastEditorID)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRules>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRules>()
                .Property(e => e.Answer)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRules>()
                .Property(e => e.CurrentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<FixedRules>()
                .Property(e => e.LastEditorID)
                .IsUnicode(false);

            modelBuilder.Entity<WeatherInfo>()
                .Property(e => e.LastMaintainerId)
                .IsUnicode(false);
        }
    }
}
