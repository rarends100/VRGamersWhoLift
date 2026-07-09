using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRGamersWhoLift.Models.Abstract;
using VRGamersWhoLift.Models.users;

namespace VRGamersWhoLift.Models.database
{
    public class VRGamersWhoLiftContext : IdentityDbContext //After installing EF Core
    {
        public VRGamersWhoLiftContext(DbContextOptions<VRGamersWhoLiftContext> options) : base (options)
        {  }

        public DbSet<Profile> Profile { get; set; } = null!;

        public DbSet<Image> Image { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!; //DbSet<Entity> class enables DbContext class to work with the collections of my entity classes
        //Any property in your entity with a name of Id (or ID) or the entity name followed by Id (or ID) is a primary key
        //bare minimum up to here is in

        //Seeding my tables with sample data

        //More useful info on how many DbContexts to use/have for the db -> https://stackoverflow.com/questions/16248074/how-many-dbcontexts-should-i-have

        protected override void OnModelCreating(ModelBuilder modelBuilder) //called by the EF Core framework when the context is created, Can override it to configure context manually - as I am doing here
        {
            // Bug — unable to create DbContext of type '' The entity type 'IdentityUserLogin<string>' requires a primary key to be defined -> err occurred when Add-Migration executed
            // Soln — The entity type 'IdentityUserLogin<string>' requires a primary key to be defined -> https://stackoverflow.com/questions/40703615/the-entity-type-identityuserloginstring-requires-a-primary-key-to-be-defined
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasBaseType<User>();
            modelBuilder.Entity<Admin>().HasBaseType<User>();
            modelBuilder.Entity<Coach>().HasBaseType<User>(); //Expicitly define the subclasses of the entity in the OnModelCreating() method https://stackoverflow.com/questions/37398141/ef7-migrations-the-corresponding-clr-type-for-entity-type-is-not-instantiab
            //p2 https://stackoverflow.com/questions/46027385/derived-types-in-entity-framework -> also apparently pg 656 that I missed when reading

            //one to one rel behavior fk_User_profile
            modelBuilder.Entity<Profile>()
                .HasKey(p => p.ProfileUsernameID);
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.ProfileUsernameID)
                .IsRequired()
                .HasPrincipalKey<User>(u => u.UserName)
                .OnDelete(DeleteBehavior.Cascade);

            //NOTE: With Identity framework integrated, had to move this logic to the ConfigureIdentity.cs class for proper user inserts and Password Hashing
            /*modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    UserName = "rarends", //When using the HasData() method you must provide vals for the id properties, even ones configed as identity cols
                    NormalizedUserName = "RARENDS",
                    FirstName = "Robert",
                    MiddleName = "Charles",
                    LastName = "Arends",
                    Email = "robert.arends100@gitmail.com",
                    Password = "Password_1",
                }
            );

            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    UserName = "swilkins", //When using the HasData() method you must provide vals for the id properties, even ones configed as identity cols
                    NormalizedUserName = "SWILKINS",
                    FirstName = "Samantha",
                    MiddleName = "Eve",
                    LastName = "Wilkins",
                    Email = "Samantha.Wilkins@gitmail.com",
                    Password = "Password_1",
                }
            );

            modelBuilder.Entity<Coach>().HasData(
                new Coach
                {
                    UserName = "ngreyson",
                    NormalizedUserName = "NGREYSON",
                    FirstName = "Nolan",
                    MiddleName = "",
                    LastName = "Greyson",
                    Email = "nolan.Greyson@viltrum.planet",
                    Password = "Password_1",
                }
            ); 

            //Profile data
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Name = "robert_arends",
                    ProfileUsernameID = "rarends"
                },
                new Profile
                {
                    Name = "samantha_wilkins",
                    ProfileUsernameID = "swilkins"
                },
                new Profile
                {
                    Name = "nolan_greyson",
                    ProfileUsernameID = "ngreyson"
                }
            );*/ // Now covered in the 'ConfigureIdentity.cs' class because IdentityFrameWorkCore is inherited by User now
            

        }




    }
}
