using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFMultiSchemaVersionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading assemblies...");

            var loadedAssemblies = new Dictionary<string, Assembly>();
            
            var filesToLoad = Directory.GetFiles(Directory.GetCurrentDirectory(), "EFContainer*.dll");
            //filesToLoad = filesToLoad.Reverse().ToArray();    // Why does this make it work???
            foreach (var file in filesToLoad)
            {
                var assembly = Assembly.LoadFile(file);
                var filename = Path.GetFileName(file);
                loadedAssemblies.Add(filename, assembly);
                Console.WriteLine("Loaded {0} from {1}", assembly.FullName, filename);
            }

            Console.WriteLine("Assemblies loaded. Press any key to insert a new row.");
            Console.ReadKey();
            Console.WriteLine("Inserting a new row in the Bars table.");

            try
            {
                // Initializing an instance of this class should insert a new row in the Bars table
                var dostuffer = loadedAssemblies["EFContainer.2.0.0.0.dll"].CreateInstance("EFContainer.DoStuff");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Exception while inserting new row: " + ex.ToString());
            }

            Console.WriteLine("Done");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
