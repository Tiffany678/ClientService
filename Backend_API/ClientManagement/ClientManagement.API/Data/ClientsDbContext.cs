using ClientManagement.API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace ClientManagement.API.Data
{
    public class ClientsDbContext:DbContext
    {
        public ClientsDbContext(DbContextOptions<ClientsDbContext> dbContextOptions) : base(dbContextOptions)
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
                    Description = "Family Service League provides prevention and comprehensive addiction treatment services to Suffolk county adults and adolescents—along with help and support to the families who love them. Our program features screenings, assessments and evaluations to determine the level of care needed to support outpatient recovery and abstinence. Each person who enters a FSL medically supervised program—either voluntarily or via mandate—is prescribed a plan to fit their specific needs."
                },
                new HelpService()
                {
                    Id = Guid.Parse("ea294873-7a8c-4c0f-bfa7-a2eb492cbf8c"),
                    ServiceName = "Children Services",
                    Description = "Family Service League provides a wide range of children and family services to help ensure that every child in Suffolk county has the opportunity to excel and choose the right path no matter their home situation. Programs and resources available offer professional guidance, counseling and positive, character-building recreational activities to support those in need and who may be most at risk."
                },
                new HelpService()
                {
                    Id = Guid.Parse("f808ddcd-b5e5-4d80-b732-1ca523e48434"),
                    ServiceName = "Training & Employment",
                    Description = "Chronic unemployment and underemployment are often at the root of individual and family hardship and dysfunction. Family Service League has a series of proven job training and vocational programs designed to build skills and confidence. Offering job skill improvement, job search services and placement assistance, these programs help those who have had difficulty finding and maintaining regular employment, as well as job seekers who are battling mental illness."
                },
                new HelpService()
                {
                    Id = Guid.Parse("65da73d1-5564-41f4-a49b-5de53e9218ff"),
                    ServiceName = "Family & Community Support",
                    Description = "Family Service League offers numerous programs and services to help families in need in Suffolk county. Our professionally trained staff and volunteers are available to assist everyone from at-risk youth to expectant and new parents with education, counseling and referrals to helpful resources."
                },
                new HelpService()
                {
                    Id = Guid.Parse("7ee9b631-d9ff-466a-8730-54a83337cf7c"),
                    ServiceName = "Housing & Homeless Services",
                    Description = "Family Service League’s housing programs focus on providing emergency housing and supportive services to chronically homeless individuals and families throughout Suffolk county. Homelessness is often the result of a disability, mental illness or substance abuse, and it can be a daunting task to overcome the effects of these crippling conditions while attempting to become self-sufficient. We’re here to help."
                },
                new HelpService()
                {
                    Id = Guid.Parse("1b634fa4-4eff-42f1-9784-f0a14112e2b7"),
                    ServiceName = "Mental health & Integrated Care",
                    Description = "Family Service League is one of the foremost providers of mental health services on Long Island, treating all aspects of psychiatric illness and emotional distress for every age group and socioeconomic background. Our expert staff works collaboratively with healthcare providers and care management services to achieve true integrated healthcare for individuals impacted by mental illness—and the families who love them."
                }
            };

            modelBuilder.Entity<HelpService>().HasData(helpServices);



         
         var clients = new List<Client>
         {
             new Client
             {
                 Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
                 FirstName = "Corene",
                 LastName = "Wall",
                 DateOfBirth = DateTime.Parse("2000-05-21"),
                  Email = "Corene.Wall@gmaill.com",
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
