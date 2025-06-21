using Microsoft.EntityFrameworkCore;
//using kol.Models;
namespace kol.Data;

public class KolDbContext : DbContext {
    
    
    protected KolDbContext() { }
    public KolDbContext(DbContextOptions options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        // Seed
       // modelBuilder.Entity<>().HasData()
        
    }
}




// *** Notatki do bazy danych **

// tabele db, w dbcontext -> public DbSet<Student> Students {get; set;}

// relacje
// 1 - *
// w StudentGroup -> public ICollection<Students> {get; set;}
// w Student -> public int IdStudentGroup {get;set;}
//              [ForeignKey(nameof(IdStudentGroup))]
//              public StudentGroup StudentGroup {get; set;}