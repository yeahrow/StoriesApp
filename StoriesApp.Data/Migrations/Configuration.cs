namespace StoriesApp.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoriesApp.Data.DataAccess.Repositories.EF.StoriesDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StoriesApp.Data.DataAccess.Repositories.EF.StoriesDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Users.AddOrUpdate(
              p => p.Id,
              new DataAccess.Repositories.EF.Stories.User { Name = "user1", Password = "123", GroupId = 1 },
              new DataAccess.Repositories.EF.Stories.User { Name = "user2", Password = "123", GroupId = 2 }
            );

            context.Groups.AddOrUpdate(
              p => p.Id,
              new DataAccess.Repositories.EF.Stories.Group { Name = "C#", Description = "It was developed by Microsoft within its .NET initiative and later approved as a standard by Ecma (ECMA-334) and ISO (ISO/IEC 23270:2006). C# is one of the programming languages designed for the Common Language Infrastructure. C# is a general-purpose, object-oriented programming language." },
              new DataAccess.Repositories.EF.Stories.Group { Name = "JavaScript", Description = "JavaScript is a high-level, dynamic, untyped, and interpreted programming language. It has been standardized in the ECMAScript language specification." },
              new DataAccess.Repositories.EF.Stories.Group { Name = "Java", Description = "Java is a general-purpose computer programming language that is concurrent, class-based, object-oriented" },
              new DataAccess.Repositories.EF.Stories.Group { Name = "Html", Description = "Hypertext Markup Language (HTML) is the standard markup language for creating web pages and web applications. With Cascading Style Sheets (CSS) and JavaScript it forms a triad of cornerstone technologies for the World Wide Web." }
            );

        }
    }
}
