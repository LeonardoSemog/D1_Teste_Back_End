using AppD1.Models;
using System;
using System.Data.Entity;

namespace AppD1.WebApp.Models
{
    public class AppD1Context : DbContext
    {
        public AppD1Context() : base("AppD1ConnectionString")
        {
            Database.SetInitializer<AppD1Context>(new AppD1ContextInitializer());
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }

    public class AppD1ContextInitializer : DropCreateDatabaseIfModelChanges<AppD1Context>
    {
        protected override void Seed(AppD1Context context)
        {
            context.Clients.Add(new Client { Id = 1, DateOfBirth = DateTime.Parse("10/25/1979"), Name = "Leonardo Gomes", Rg = 220819142, Cpf = 21269518801 });
            context.SaveChanges();

            context.Phones.Add(new Phone { Id = 1, PhoneTypeId = 0, PhoneNumber = "011981418629",ClientId=1 });
            context.SaveChanges();
            base.Seed(context);

            
        }

        
    }


}