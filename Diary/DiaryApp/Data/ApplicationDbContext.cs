using Microsoft.EntityFrameworkCore;
using DiaryApp.Models;

namespace DiaryApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; } // creates a table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                
                new DiaryEntry
                {   
                    Id = 1,
                    Title = "Today I baked a cake", 
                    Content = "I baked a tasty chocolate cake",
                    Created = new DateTime(2025,2,3)
                },

                new DiaryEntry
                {
                    Id = 2,
                    Title = "Swam in my pool",
                    Content = "Today I swam in my pool, it was awesome",
                    Created = new DateTime(2025, 2, 3)
                },
                new DiaryEntry
                {
                    Id = 3,
                    Title = "Went to the movies",
                    Content = "I went to the movies with jane today, we watched minions",
                    Created = new DateTime(2025, 2, 3)
                }


                );
        }
    }
}
