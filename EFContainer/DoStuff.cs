using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFContainer
{
    class DoStuff
    {
        public DoStuff()
        {
            var rand = new Random();
            using (var ctx = new FooContext())
            {
                ctx.Bars.Add(new Bar()
                {
                    Name = Bars[rand.Next(Bars.Length)]
                });
                ctx.SaveChanges();
            }
        }

        private static string[] Bars = {
            "Tales and Spirits",
            "Zensai",
            "Cicchetti Bar at Piccolino",
            "iKandy",
            "Wink",
            "Beaufort Bar",
            "Jefrey's",
            "Little Red Pocket",
            "Hyde & Co",
            "Strange Wolf"
        };
    }
}
