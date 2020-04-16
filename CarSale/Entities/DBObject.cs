using Entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarSale.Entities
{
    public class DBObject
    {
        public static void Initial(DBContext content, IServiceProvider services, IHostingEnvironment env,
            IConfiguration config)
        {
            if (!content.Users.Any())
            {
                var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var managerUser = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var managerRole = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                string roleName = "Admin";
                var role = managerRole.FindByNameAsync(roleName).Result;
                if (role == null)
                {
                    role = new IdentityRole
                    {
                        Name = roleName
                    };
                    var addRoleResult = managerRole.CreateAsync(role).Result;
                }
                roleName = "User";
                role = managerRole.FindByNameAsync(roleName).Result;
                if (role == null)
                {
                    role = new IdentityRole
                    {
                        Name = roleName
                    };
                    var addRoleResult = managerRole.CreateAsync(role).Result;
                }
                var listUsers = new List<AppUser>()
                {

                    new AppUser
                   {   Email="robert@gmail.com",
                       Name = "Robert",
                       Surname = "Deniro",
                       Country = "USA",
                       City = "New York",
                       Img = "https://img.icons8.com/officel/2x/user.png",
                       UserName="robert@gmail.com",
                       PhoneNumber="380986654128"
                   },
                     new AppUser
                     {
                         Email="Bob@gmail.com",
                         Name = "Bob",
                         Surname = "Marley",
                         Country = "Jamaica",
                         City = "Nine Mile",
                         Img = "https://img.icons8.com/officel/2x/user.png",
                         UserName="Bob@gmail.com",
                                                PhoneNumber="380986664228"

                     },
                       new AppUser
                       {
                           Name = "Jon",
                           Surname = "Show",
                           Country = "Westeros",
                           City = " Winterfell",
                           Img = "https://img.icons8.com/officel/2x/user.png",
                           Email="Jon@gmail.com",
                           UserName="Jon@gmail.com",
                                                  PhoneNumber="384486654128"

                       },
                         new AppUser
                         {
                             Name = "John",
                             Surname = "Sparrow",
                             Country = "Great Britain",
                             City = "London",
                             Img = "https://img.icons8.com/officel/2x/user.png",
                             Email="John@gmail.com",
                             UserName="John@gmail.com",
                                                                               PhoneNumber="380986653418"

                         }
            };
                var roles = new List<string> { { "Admin" }, { "User" } };
                int i = 0;
                foreach (var item in listUsers)
                {

                    var user = managerUser.FindByEmailAsync(item.Email).Result;
                    if (user == null)
                    {
                        var result = managerUser.CreateAsync(item, "Qwerty1-").Result;
                        if (result.Succeeded)
                        {
                            if (i == 3)
                                result = managerUser.AddToRoleAsync(item, roles[1]).Result;
                            else
                                result = managerUser.AddToRoleAsync(item, roles[0]).Result;

                        }
                    }
                    i++;
                }



            }

        }

    }
}
