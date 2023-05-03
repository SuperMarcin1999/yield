using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    internal class DataAwfulGenerator
    {
        public static IEnumerable<Viewer> GetViewers()
        {
            var viewers = new List<Viewer>
            {
                new Viewer(false, true, false, "Janek"),
                new Viewer(true, true, false, "Ala"),
                new Viewer(true, false, true, "Wanda")
            };

            return viewers;
        }
        


    }
}
