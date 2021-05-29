using System.Linq;
using AccountService.DataAccess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccountService.Init
{
    public class DataLoader
    {

        private readonly AccountDbContext dbContext;

        public DataLoader(AccountDbContext context)
        {
            dbContext = context;
        }

        public void Seed(IConfiguration configuration)
        {
            // dbContext.Database.EnsureCreated();
            // if (dbContext.Products.Any())
            // {
            //     return;
            // }

            // dbContext.Products.Add(DemoProductFactory.Travel());
            // dbContext.Products.Add(DemoProductFactory.House());
            // dbContext.Products.Add(DemoProductFactory.Farm());
            // dbContext.Products.Add(DemoProductFactory.Car());

            // dbContext.SaveChanges();
            var useInMemoryDatabase = configuration.GetSection("Settings").GetValue<bool>("UseInMemoryDatabase");
            if(useInMemoryDatabase)
            {
                return;
            }
            System.Console.WriteLine("Applying migrations");
            dbContext.Database.Migrate();
        }
    }
}
