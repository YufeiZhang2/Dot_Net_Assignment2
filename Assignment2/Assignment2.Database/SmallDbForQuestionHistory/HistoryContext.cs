namespace Assignment2.Database.SmallDbForQuestionHistory
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HistoryContext : DbContext
    {
        public HistoryContext()
            : base("name=HistoryContext")
        {
        }

        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.Question)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.Answer)
                .IsUnicode(false);
        }
    }
}
