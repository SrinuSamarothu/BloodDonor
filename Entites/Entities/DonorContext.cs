using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities
{
    public class DonorContext : DbContext
    {
        public DonorContext(DbContextOptions<DonorContext> options) : base(options) { }

        public DbSet<Donor> donor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donor>(entity =>
            {
                entity.HasKey(e => e.id).HasName("Pk_ID");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");
                entity.Property(e => e.age)
                    .IsRequired()
                    .HasColumnName("age");
                entity.Property(e => e.phnumber)
                    .IsRequired()
                    .HasColumnName("phnumber");
                entity.Property(e => e.city)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("city");
                entity.Property(e => e.bloodGroup)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("bloodGroup");
                entity.Property(e => e.profession)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("profession");
                entity.Property(e => e.height)
                    .IsRequired()
                    .HasColumnName("height");
                entity.Property(e => e.weight)
                    .IsRequired()
                    .HasColumnName("weight");
            });
        }
    }
}
