using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarSale.Entities
{
    public class DBObject
    {
        public static void Initial(DBContext content)
        {
            if (!content.Users.Any())
            {
                content.AddRange(
                   new AppUser
                   {
                       Name = "Robert",
                       Surname = "Deniro",
                       Country = "USA",
                       City = "New York",
                       Img = "https://img.icons8.com/officel/2x/user.png"

                   },
                     new AppUser
                     {
                         Name = "Bob",
                         Surname = "Marley",
                         Country = "Jamaica",
                         City = "Nine Mile",
                         Img = "https://img.icons8.com/officel/2x/user.png"
                     },
                       new AppUser
                       {
                           Name = "Jon",
                           Surname = "Show",
                           Country = "Westeros",
                           City = " Winterfell",
                           Img = "https://img.icons8.com/officel/2x/user.png"
                       },
                         new AppUser
                         {
                             Name = "John",
                             Surname = "Sparrow",
                             Country = "Great Britain",
                             City = "London",
                             Img = "https://img.icons8.com/officel/2x/user.png"
                         }
                );
                content.SaveChanges();
            }

        }
        private static void SeedFilters(DBContext context, IHostingEnvironment _env,
    IConfiguration _config)
        {
            #region tblFilterNames - Назви фільтрів
            string[] filterNames = { "Тип авто", "Пальне", "Модель", "Колір" };
            foreach (var type in filterNames)
            {
                if (context.FilterNames.SingleOrDefault(f => f.Name == type) == null)
                {
                    context.FilterNames.Add(
                        new Entities.FilterName
                        {
                            Name = type
                        });
                    context.SaveChanges();
                }
            }
            #endregion


            #region tblFilterValues - Значення фільтрів
            List<string[]> filterValues = new List<string[]> {
                new string [] { "Кросовер", "Легковий", "Вантажний" },
                new string [] { "Дизель", "Бензин", "Газ"},
                new string [] {"C6","SPACETOURER","C4 SEDAN","BERLINGO","C-CROSSER","CR-V","PILOT","PASSPORT","FIT","ACCORD","KAMIQ",
                 "YETI","ROOMSTER","OCTAVIA","CITIGO","FORESTER","JUSTY","ASCENT",
                 "TRIBECA","STELLA","TWINGO","TALISMAN","SANDERO","LATITUDE","KOLEOS","ESPACE","VIVARO","CORSA","FRONTERA",
                 "ANTARA","ADAM","GENESIS","SONATA","CRETA","GRANDEUR","KONA","TERRACAN","SENTRA",
                 "PATROL","ALMERA","GT-R","LAFESTA","LINEA","TORO","TIPO","PANDA","MOBI","BRAVO",
                 "508 RXH","TRAVELLER","208","PEUGEOT 1007","308 GT","EXPERT","TAURUS",
                 "MUSTANG","FOCUS RS","FIESTA","EXPLORER","ALERO","ORLANDO","VIVA","CORVETTE","COBALT","TOURAN","PASSAT",
                 "ATLAS","GOLF","CAMRY","SIENNA","GT 86","S-CLASS CABRIOLET","M-CLASS","V-CLASS","A SEDAN",
                 "AMG GT S","TTS","S3","Q2","A5","Axela","Tribute","MX-5","X5","750iL","3-series Coupe"},
                 new string []{"Зелений","Червоний","Синій","Чорний","Білий","Сірий"}
            };

            foreach (var items in filterValues)
            {
                foreach (var value in items)
                {
                    if (context.FilterValues
                        .SingleOrDefault(f => f.Name == value) == null)
                    {
                        context.FilterValues.Add(
                            new Entities.FilterValue
                            {
                                Name = value
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            #region tblFilterNameGroups - Групування по групах фільтрів

            for (int i = 0; i < filterNames.Length; i++)
            {
                foreach (var value in filterValues[i])
                {
                    var nId = context.FilterNames
                        .SingleOrDefault(f => f.Name == filterNames[i]).Id;
                    var vId = context.FilterValues
                        .SingleOrDefault(f => f.Name == value).Id;
                    if (context.FilterNameGroups
                        .SingleOrDefault(f => f.FilterValueId == vId &&
                        f.FilterNameId == nId) == null)
                    {
                        context.FilterNameGroups.Add(
                            new Entities.FilterNameGroup
                            {
                                FilterNameId = nId,
                                FilterValueId = vId
                            });
                        context.SaveChanges();
                    }
                }
            }
            #endregion

            #region tblCars - Автомобілі
            List<string> cars = new List<string>{
             "154muv2f", "154m2fas"
            };
            foreach (var item in cars)
            {
                string path = Path.Combine("images", item);

                if (context.Cars.SingleOrDefault(f => f.UniqueName == item) == null)
                {
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    context.Cars.Add(
                        new Car
                        {
                            UniqueName = item,
                            Date = DateTime.Now,
                            Price = 20000,
                            Mileage = 20,
                            Name = "BMW X5"
                        });
                    context.SaveChanges();
                }
            }
            #endregion

            #region tblFilters -Фільтри
            Filter[] filters =
            {
                new Filter { FilterNameId = 1, FilterValueId=1, CarId=1 },
                new Filter { FilterNameId = 2, FilterValueId=5, CarId=1 },
                new Filter { FilterNameId = 3, FilterValueId=7, CarId=1 },
                new Filter { FilterNameId = 4, FilterValueId=93, CarId=1 },

                new Filter { FilterNameId = 1, FilterValueId=2, CarId=2 },
                new Filter { FilterNameId = 2, FilterValueId=6, CarId=2 },
                new Filter { FilterNameId = 3, FilterValueId=8, CarId=2 },
                new Filter { FilterNameId = 4, FilterValueId=94, CarId=2 }
            };
            foreach (var item in filters)
            {
                var f = context.Filters.SingleOrDefault(p => p == item);
                if (f == null)
                {
                    context.Filters.Add(new Filter { FilterNameId = item.FilterNameId, FilterValueId = item.FilterValueId, CarId = item.CarId });
                    context.SaveChanges();
                }
            }
            #endregion
            MakesAndModels[] makesAndModels =
            {
                new MakesAndModels { FilterMakeId = 18, FilterValueId=7 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=8 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=9 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=10 },
                new MakesAndModels { FilterMakeId = 18, FilterValueId=11},

                new MakesAndModels { FilterMakeId = 17, FilterValueId=12 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=13 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=14 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=15 },
                new MakesAndModels { FilterMakeId = 17, FilterValueId=16 },

                new MakesAndModels { FilterMakeId = 16, FilterValueId=17 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=18 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=19 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=20 },
                new MakesAndModels { FilterMakeId = 16, FilterValueId=21 },

                new MakesAndModels { FilterMakeId = 15, FilterValueId=22 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=23 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=24 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=25 },
                new MakesAndModels { FilterMakeId = 15, FilterValueId=26 },


                new MakesAndModels { FilterMakeId = 14, FilterValueId=27 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=28 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=29 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=30 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=31 },
                new MakesAndModels { FilterMakeId = 14, FilterValueId=32 },

                new MakesAndModels { FilterMakeId = 13, FilterValueId=33 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=34 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=35 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=36 },
                new MakesAndModels { FilterMakeId = 13, FilterValueId=37 },

                new MakesAndModels { FilterMakeId = 12, FilterValueId=38 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=39 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=40 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=41 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=42 },
                new MakesAndModels { FilterMakeId = 12, FilterValueId=43 },

                new MakesAndModels { FilterMakeId = 11, FilterValueId=44 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=45 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=46 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=47 },
                new MakesAndModels { FilterMakeId = 11, FilterValueId=48 },

                new MakesAndModels { FilterMakeId = 10, FilterValueId=49 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=50 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=51 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=52 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=53 },
                new MakesAndModels { FilterMakeId = 10, FilterValueId=54 },

                new MakesAndModels { FilterMakeId = 9, FilterValueId=55 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=56 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=57 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=58 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=59 },
                new MakesAndModels { FilterMakeId = 9, FilterValueId=60 },

                new MakesAndModels { FilterMakeId = 8, FilterValueId=61 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=62 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=63 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=64 },
                new MakesAndModels { FilterMakeId = 8, FilterValueId=65 },

                new MakesAndModels { FilterMakeId = 7, FilterValueId=66 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=67 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=68 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=69 },
                new MakesAndModels { FilterMakeId = 7, FilterValueId=70 },

                new MakesAndModels { FilterMakeId = 6, FilterValueId=71 },
                new MakesAndModels { FilterMakeId = 6, FilterValueId=72 },
                new MakesAndModels { FilterMakeId = 6, FilterValueId=73 },
                new MakesAndModels { FilterMakeId = 6, FilterValueId=74 },

                new MakesAndModels { FilterMakeId = 5, FilterValueId=75 },
                new MakesAndModels { FilterMakeId = 5, FilterValueId=76 },
                new MakesAndModels { FilterMakeId = 5, FilterValueId=77 },

                new MakesAndModels { FilterMakeId = 4, FilterValueId=78 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=79 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=80 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=81 },
                new MakesAndModels { FilterMakeId = 4, FilterValueId=82 },


                new MakesAndModels { FilterMakeId = 3, FilterValueId=83 },
                new MakesAndModels { FilterMakeId = 3, FilterValueId=84 },
                new MakesAndModels { FilterMakeId = 3, FilterValueId=85 },
                new MakesAndModels { FilterMakeId = 3, FilterValueId=86 },

                new MakesAndModels { FilterMakeId = 2, FilterValueId=87 },
                new MakesAndModels { FilterMakeId = 2, FilterValueId=88 },
                new MakesAndModels { FilterMakeId = 2, FilterValueId=89 },

                new MakesAndModels { FilterMakeId = 1, FilterValueId=90 },
                new MakesAndModels { FilterMakeId = 1, FilterValueId=91 },
                new MakesAndModels { FilterMakeId = 1, FilterValueId=92 },
            };
            foreach (var item in makesAndModels)
            {
                var f = context.MakesAndModels.SingleOrDefault(p => p == item);
                if (f == null)
                {
                    context.MakesAndModels.Add(new MakesAndModels { FilterMakeId = item.FilterMakeId, FilterValueId = item.FilterValueId });
                    context.SaveChanges();
                }
            }
        }
    }
}
