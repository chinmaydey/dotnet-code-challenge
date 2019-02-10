using dotnet_code_challenge.Contexts;
using dotnet_code_challenge.Models;
using System.IO;
using System.Reflection;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            // get xml file path
            var info = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            var xmlFilePath = Path.Combine(info.Parent.Parent.Parent.FullName, @"FeedData\Caulfield_Race1.xml");
            var jsonFilePath = Path.Combine(info.Parent.Parent.Parent.FullName, @"FeedData\Wolferhampton_Race1.json");

            var horsexmlcontext = new XMLDataContext<Horse>(xmlFilePath);
            var horsexmlcontextdata = horsexmlcontext.GetAll();

            var pricexmlcontext = new XMLDataContext<Price>(xmlFilePath);
            var pricexmlcontextdata =  pricexmlcontext.GetAll();

            var horsejsoncontext = new JSONDataContext<Horse>(jsonFilePath);
            var horsejsoncontextdata = horsejsoncontext.GetAll();

            var pricejsoncontext = new JSONDataContext<Price>(jsonFilePath);
            var pricejsoncontextdata = pricejsoncontext.GetAll();
        }
    }
}
