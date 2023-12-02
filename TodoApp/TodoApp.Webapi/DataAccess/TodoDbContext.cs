using Microsoft.EntityFrameworkCore;

namespace TodoApp.Webapi.DataAccess
{
    public class TodoDbContext: DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Todo>().HasData(new List<Todo>()
            {
                new Todo()
                {
                    Id = Guid.NewGuid(),
                    Title = "Excercise"
                },
                new Todo()
                {
                    Id = Guid.NewGuid(),
                    Title = "Cooking"
                }
            });
        }
    }

    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;                                                                               
        public DateTime? UpdatedDate { get; set;}
        public bool IsDeleted { get; set; }
    }
}
