using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bookkeeping.API
{
    public static class SeedData
    {
        private  static string InitialScript => "initialScript";

        public static async Task ExecuteScriptAsync(BookkeepingContext context)
        {
            foreach (var script in LoadAllScripts)
            {
                var isExsitMenu = await context.YearMonthIncomeExpenses.AnyAsync();

                if (!isExsitMenu)
                {
                   var resource = ReadResource.Read(script);
                   await context.Database.ExecuteSqlRawAsync(resource);
                }
            }
        }
        public static IEnumerable<string> LoadAllScripts => new List<string>
        {
            InitialScript
        };
           
    }
    internal static class ReadResource
    {
        public static string AssemblyName => "Bookkeeping.API.Scripts";
        public static string Read(string procname)
        {
            var resourceFullName = $"{AssemblyName}.{procname}.sql";
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(resourceFullName);
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
