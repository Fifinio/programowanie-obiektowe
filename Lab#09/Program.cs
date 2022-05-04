using Microsoft.EntityFrameworkCore;

static void Main(string[] args)
{
    System.Console.WriteLine("Hello World!");

    DatabaseContext context = new DatabaseContext();
    context.Database.EnsureCreated();
    context.Students.Add(new Student { Name = "John", Age = 20 });
    context.SaveChanges();


}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
}
public class DatabaseContext : DbContext
{
    // onconfigure
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=Database.db");
    }
    // onmodelcreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("students");
    }

}