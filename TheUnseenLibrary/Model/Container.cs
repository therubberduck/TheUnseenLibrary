using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUnseenLibrary.Model
{
    public class Container
    {
        public int ContainerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Page> Pages { get; set; }
    }
}
