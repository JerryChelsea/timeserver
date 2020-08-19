using Microsoft.EntityFrameworkCore;
using TimeData;
using TimeData.Data;



namespace OnTimeData
{
    public partial class TimeDataContext : DbContext
    {
        private readonly string conn =
            "Data Source=sql2k802.discountasp.net;Initial Catalog=SQL2008_741027_jerry;Persist Security Info=True;User ID=SQL2008_741027_jerry_user;Password=Gianluca12!";
        public TimeDataContext()
        {

        }
        public TimeDataContext(DbContextOptions<TimeDataContext> options)
            : base(options)
        {
        }
        public virtual DbSet<OnTimeCustomers> OnTimeCustomers { get; set; }
        public virtual DbSet<OnTimeCustomersProjects> OnTimeCustomersProjects { get; set; }
        public virtual DbSet<OnTimeFeatures> OnTimeFeatures { get; set; }
        public virtual DbSet<OnTimeProjects> OnTimeProjects { get; set; }
        public virtual DbSet<OnTimeWorkLog> OnTimeWorkLogs { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OnTimeCustomersProjects>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProjectId });
            });

            modelBuilder.Entity<OnTimeFeatures>(entity =>
            {
                entity.HasKey(e => e.FeatureId)
                    .HasName("PK_OnTimeTasks");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<OnTimeProjects>(entity =>
            {
                entity.Property(e => e.ProjectId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Path).IsUnicode(false);
            });

            modelBuilder.Entity<OnTimeWorkLog>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);
            });

  
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
