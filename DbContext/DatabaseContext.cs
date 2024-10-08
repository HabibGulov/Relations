using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Passport> Passports { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Course> Courses{get; set;}
    public DbSet<Student> Students{get; set;}
    public DbSet<StudentCourse> StudentCourses{get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=relations_db;Username=postgres;Password=12345;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
                    .HasOne(x => x.Passport)
                    .WithOne(x => x.Person)
                    .HasForeignKey<Passport>(x => x.PersonId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>()
                    .HasMany(x => x.Products)
                    .WithOne(x => x.Category)
                    .HasForeignKey(x => x.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Course>()
                    .HasMany(x => x.StudentCourses)
                    .WithOne(x => x.Course)
                    .HasForeignKey(x => x.CourseId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
                    .HasMany(x => x.StudentCourses)
                    .WithOne(x => x.Student)
                    .HasForeignKey(x => x.StudentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);
    }
}