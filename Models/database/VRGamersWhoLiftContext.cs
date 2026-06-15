using Microsoft.EntityFrameworkCore;
using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.users;

namespace VRGamersWhoLift.Models.database
{
    public class VRGamersWhoLiftContext : DbContext //After installing EF Core
    {
        public VRGamersWhoLiftContext(DbContextOptions<VRGamersWhoLiftContext> options) : base (options)
        {  }

        public DbSet<User> Users { get; set; } = null!; //DbSet<Entity> class enables DbContext class to work with the collections of my entity classes
        //Any property in your entity with a name of Id (or ID) or the entity name followed by Id (or ID) is a primary key
        //bare minimum up to here is in

        //Seeding my tables with sample data

        //More useful info on how many DbContexts to use/have for the db -> https://stackoverflow.com/questions/16248074/how-many-dbcontexts-should-i-have
        protected override void OnModelCreating(ModelBuilder modelBuilder) //called by the EF Core framework when the context is created, Can override it to configure context manually - as I am doing here
        {
            modelBuilder.Entity<Member>().HasBaseType<User>();
            modelBuilder.Entity<Admin>().HasBaseType<User>();
            modelBuilder.Entity<Coach>().HasBaseType<User>(); //Expicitly define the subclasses of the entity in the OnModelCreating() method https://stackoverflow.com/questions/37398141/ef7-migrations-the-corresponding-clr-type-for-entity-type-is-not-instantiab
            //p2 https://stackoverflow.com/questions/46027385/derived-types-in-entity-framework

            modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                UserID = 1, //When using the HasData() method you must provide vals for the id properties, even ones configed as identity cols
                FirstName = "Robert",
                MiddleName = "Charles",
                LastName = "Arends",
                Email = "robert.arends100@gitmail.com",
                Password = "Password",
                UserType = "a"

            }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    UserID = 2, //When using the HasData() method you must provide vals for the id properties, even ones configed as identity cols
                    FirstName = "Samantha",
                    MiddleName = "Eve",
                    LastName = "Wilkins",
                    Email = "Samantha.Wilkins@gitmail.com",
                    Password = "Password",
                    UserType = "m"
                }    
            );

            modelBuilder.Entity<Coach>().HasData(
                new Coach
                {
                    UserID = 3,
                    FirstName = "Nolan",
                    MiddleName = "",
                    LastName = "Greyson",
                    Email = "nolan.Greyson@viltrum.planet",
                    Password = "Password",
                    UserType = "c"
                }
            );
            

        }




    }
}
