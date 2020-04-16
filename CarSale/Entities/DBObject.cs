using CarSale.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarSale.Entities
{
    public class DBObject
    {
        private  readonly UserManager<AppUser> userManager;
        AspNetRoleManager<IdentityRole> roleManager;
        public static void Initial(DBContext content)
        {
            //if (!content.Users.Any())
            //{
            //    content.AddRange(
            //       new AppUser
            //       {
            //          Email = "robert@gmail.com",
            //          PhoneNumber = "0987654321",
            //          Name = "Robert",
            //          Surname= "Deniro",
            //          Country = "USA",
            //          City = "New York",
            //          Img = "https://img.icons8.com/officel/2x/user.png"

            //       },
            //         new AppUser
            //         {
            //             Email = "bob@gmail.com",
            //             PhoneNumber = "0879645231",
            //             Name = "Bob",
            //             Surname = "Marley",
            //             Country = "Jamaica",
            //             City = "Nine Mile",
            //             Img = "https://img.icons8.com/officel/2x/user.png"
            //         },
            //           new AppUser
            //           {
            //               Email = "jon@gmail.com",
            //               PhoneNumber = "0654329864",
            //               Name = "Jon",
            //               Surname = "Show",
            //               Country = "Westeros",
            //               City = " Winterfell",
            //               Img = "https://img.icons8.com/officel/2x/user.png"
            //           },
            //             new AppUser
            //             {
            //                 Email = "john@gmail.com",
            //                 PhoneNumber = "0504567123",
            //                 Name = "John",
            //                 Surname = "Sparrow",
            //                 Country = "Great Britain",
            //                 City = "London",
            //                 Img = "https://img.icons8.com/officel/2x/user.png"
            //             }
            //    );
            //    content.SaveChanges();
            //}
            SeedUsers(userManager, roleManager);
        }
        public static void SeedUsers(UserManager<AppUser> userManager, AspNetRoleManager<IdentityRole> roleManager)
        {
            string roleName = "Admin";
            var role = roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                role = new IdentityRole
                {
                    Name = roleName
                };
                var addRoleResult = roleManager.CreateAsync(role).Result;
            }
            roleName = "User";
            role = roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                role = new IdentityRole
                {
                    Name = roleName
                };
                var addRoleResult = roleManager.CreateAsync(role).Result;
            }
            var userEmail = "admin@gmail.com";
            var user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new AppUser
                {
                    Email = userEmail,
                    PhoneNumber = "0987654321",
                    Name = "Yura",
                    Surname = "Deniro",
                    Country = "USA",
                    City = "New York",
                    Img = "https://img.icons8.com/officel/2x/user.png"
                };
                var result = userManager.CreateAsync(user, "Qwerty1-").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, "Admin").Result;
                }
            }
            userEmail = "maks123@gmail.com";
            user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new AppUser
                {
                    Email = userEmail,
                    PhoneNumber = "0879645231",
                    Name = "max",
                    Surname = "Marley",
                    Country = "Jamaica",
                    City = "Nine Mile",
                    Img = "https://img.icons8.com/officel/2x/user.png"
                };
                var result = userManager.CreateAsync(user, "max12478-Q").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, roleName).Result;
                }
            }
            userEmail = "zaharjoker@gmail.com";
            user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new AppUser
                {
                    Email = userEmail,
                    PhoneNumber = "0504567123",
                    Name = "Zahar",
                    Surname = "Sparrow",
                    Country = "Great Britain",
                    City = "London",
                    Img = "https://img.icons8.com/officel/2x/user.png"
                };
                var result = userManager.CreateAsync(user, "zahardeadinside!39-R").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, roleName).Result;
                }
            }
            userEmail = "invoker@ukr.net";
            user = userManager.FindByEmailAsync(userEmail).Result;
            if (user == null)
            {
                user = new AppUser
                {
                    Email = userEmail,
                    PhoneNumber = "0654329864",
                    Name = "Jon",
                    Surname = "Show",
                    Country = "Westeros",
                    City = " Winterfell",
                    Img = "https://img.icons8.com/officel/2x/user.png"
                };
                var result = userManager.CreateAsync(user, "quaswexQ-11").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, roleName).Result;
                }
            }
        }
    }
}
