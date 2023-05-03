using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    internal class DataBetterGenerator
    {
        public static IEnumerable<Viewer> GetViewers()
        {
            yield return new Viewer(false, true, false, "Janek");
            yield return new Viewer(true, true, false, "Ala");
            yield return new Viewer(true, false, true, "Wanda");
        }
    }
}
