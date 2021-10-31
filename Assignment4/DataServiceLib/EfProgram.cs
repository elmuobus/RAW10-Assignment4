using System;
using System.Linq;
using DataServiceLib.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLib
{
    class EfProgram
    {
        static void Main(string[] args)
        {
            var dataService = DataService.CreateInstance();

            foreach (var category in dataService.GetCategories())
            {
                Console.WriteLine(category);
            }
        }
    }
}