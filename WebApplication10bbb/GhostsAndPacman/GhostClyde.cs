using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10bbb.GhostsAndPacman
{
    public class GhostClyde:Ghost
    {
        public GhostClyde()
        {
            run_point_x = 29;
            run_point_y = 1;
            initial_score_limit = 20;
        }
    }
}
