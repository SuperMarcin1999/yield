using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yield
{
    internal class Viewer
    {
        public bool CanGiveLike { get; set; }
        public bool CanGiveComment { get; set; }
        public bool CanGiveAView { get; set; }
        public string Name { get; set; }

        public Viewer(bool canGiveLike, bool canGiveComment, bool canGiveAView, string name)
        {
            CanGiveComment = canGiveComment;
            CanGiveAView = canGiveAView;
            CanGiveLike = canGiveLike;
            Name = name;


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Stworzyłem Viewer: {Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
