using Data;
using Data.Entities;
using System;
using System.Linq;

namespace DAL
{
    public class Repository
    {
        public static void Initiate()
        {
            using (var context = new CompanyDBContext())
            {
                var list = context.Departments.ToList();
                for (var i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i].Name);
                }
            }
            Console.ReadKey();
        }
    }
}
