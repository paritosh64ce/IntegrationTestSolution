using DAL;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var conn = ConfigurationManager.ConnectionStrings["companyConn"].ConnectionString;
            Repository.Initiate();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}

