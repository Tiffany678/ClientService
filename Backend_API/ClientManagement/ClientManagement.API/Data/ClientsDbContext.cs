using ClientManagement.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace ClientManagement.API.Data
{
    public class ClientsDbContext:DbContext
    {
        public ClientsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<HelpService> HelpServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

      
            var helpServices = new List<HelpService>()
            {
                new HelpService()
                {
                    Id = Guid.Parse("54466f17-02af-48e7-8ed3-5a4a8bfacf6f"),
                    ServiceName = "Addiction Treatment Services",
                    Description = "Family Service League provides prevention and comprehensive addiction treatment services to Suffolk county adults and adolescents—along with help and support to the families who love them. Our program features screenings, assessments and evaluations to determine the level of care needed to support outpatient recovery and abstinence."
                },
                new HelpService()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    ServiceName = "Children Services",
                    Description = "Family Service League provides a wide range of children and family services to help ensure that every child in Suffolk county has the opportunity to excel and choose the right path no matter their home situation."
                },
                new HelpService()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    ServiceName = "Training & Employment",
                    Description = "Chronic unemployment and underemployment are often at the root of individual and family hardship and dysfunction. Family Service League has a series of proven job training and vocational programs designed to build skills and confidence."
                }
            };

            modelBuilder.Entity<HelpService>().HasData(helpServices);



         
         var clients = new List<Client>
         {
             new Client
             {
                 Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                 FirstName = "Tiffany",
                 LastName = "Yang",
                 DateOfBirth = DateTime.Parse("2000-05-21"),
                  Email = "52Tiffany.Yang@gmaill.com",
                 Mobile = 91254684566,
                 ProfileImageUrl = null,
                 HelpServiceId = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434")
             },
            new Client
            {
                Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = DateTime.Parse("1990-05-21"),
                Email = "John.Doe@gmail.com",
                Mobile = 91254684586,
                ProfileImageUrl = null,
                HelpServiceId = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434")
            },
            
        };
         modelBuilder.Entity<Client>().HasData(clients);
        }
    }
}
