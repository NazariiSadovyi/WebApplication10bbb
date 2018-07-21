using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10bbb.MapGraph
{
    public class NodeConnection
    {
        internal Node Target { get; private set; }
        internal double Distance { get; private set; }

        internal NodeConnection(Node target, double distance)
        {
            Target = target;
            Distance = distance;
        }
    }
}
