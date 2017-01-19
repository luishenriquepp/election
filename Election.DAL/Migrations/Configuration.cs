namespace Election.DAL.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;
   

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Restaurant.AddOrUpdate(
                new Restaurant { Id = 1, Name = "McDonalds", Adress = "Rua Silva Só", Neighborhood = "Centro " },
                new Restaurant { Id = 2, Name = "Burguer King", Adress = "Bento Gonçalves", Neighborhood = "Santa Marta" },
                new Restaurant { Id = 3, Name = "Subway", Adress = "Avenida Praia de Belas", Neighborhood = "Praia de Belas" },
                new Restaurant { Id = 4, Name = "Bobs", Adress = "Avenida dos Carvalhos", Neighborhood = "Santana" },
                new Restaurant { Id = 5, Name = "Cenoura Pastéis", Adress = "Rua dos Parques", Neighborhood = "Praiana" }
            );
        }
    }
}
