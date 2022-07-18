using System.Linq;
using Test_React_ASPnet.Domain.Entity;

namespace Tess_React_ASPnet.DAL
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext db)
        {
            SeedUsers(db);
            SeedTools(db);
            SeedTools_Users(db);
            db.SaveChangesAsync();
        }

        #region SeedUsers
        private static void SeedUsers(ApplicationDbContext db)
        {
            if (!db.Users.Any())
            {
                db.AddRangeAsync(
                    new User
                    {
                        Name = "Вася"
                    },
                    new User
                    {
                        Name = "Петя"
                    },
                    new User
                    {
                        Name = "Саша"
                    });
                db.SaveChangesAsync().Wait();
            }
        }
        #endregion

        #region SeedTools
        private static void SeedTools(ApplicationDbContext db)
        {
            if (!db.Tools.Any())
            {
                db.AddRangeAsync(
                    new Tool
                    {
                        Name = "Молоток",
                        Count = 40
                    },
                    new Tool
                    {
                        Name = "Ножницы",
                        Count = 25
                    },
                    new Tool
                    {
                        Name = "Рубанок",
                        Count = 30
                    });
                db.SaveChangesAsync().Wait();
            }
        }
        #endregion

        #region SeedTools_Users
        private static void SeedTools_Users(ApplicationDbContext db)
        {
            if (!db.Tool_User.Any())
            {
                db.AddRangeAsync(
                    new Tool_User
                    {
                        User_id = db.Users.FirstOrDefault(
                            x => x.Name == "Вася").Id,
                        Tool_id = db.Tools.FirstOrDefault(
                            x => x.Name == "Молоток").Id,
                        CountTools = 5
                    },
                    new Tool_User
                    {
                        User_id = db.Users.FirstOrDefault(
                            x => x.Name == "Вася").Id,
                        Tool_id = db.Tools.FirstOrDefault(
                            x => x.Name == "Рубанок").Id,
                        CountTools = 2
                    },
                    new Tool_User
                    {
                        User_id = db.Users.FirstOrDefault(
                            x => x.Name == "Петя").Id,
                        Tool_id = db.Tools.FirstOrDefault(
                            x => x.Name == "Молоток").Id,
                        CountTools = 10
                    },
                    new Tool_User
                    {
                        User_id = db.Users.FirstOrDefault(
                            x => x.Name == "Саша").Id,
                        Tool_id = db.Tools.FirstOrDefault(
                            x => x.Name == "Ножницы").Id,
                        CountTools = 2
                    });
                db.SaveChangesAsync().Wait();
            }
        }
        #endregion

    }
}
