using DAL.Entities;
using System;
using System.Linq;

namespace DAL.DataContext
{
    public class DbSeeder
    {

        public static  void Initialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();
        }
        public static void SeedData(DataBaseContext context)
        {
            int ResourcesCount = context.Resources.Count();
            Random r = new Random();
            if (ResourcesCount < 10)
            {
                for (int i = 1; i <= 10- ResourcesCount; i++)
                {
                    Resource temp = new Resource
                    {
                        Id = (i + ResourcesCount),
                        Name = $"Resource number {(i + ResourcesCount)}",
                        Quantity = r.Next(10, 100)
                    };
                    context.Add(temp);
                    context.SaveChanges();
                }
            }
        }
    }
}
