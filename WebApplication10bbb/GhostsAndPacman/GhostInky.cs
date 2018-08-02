using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10bbb.GhostsAndPacman
{
    public class GhostInky:Ghost
    {
        public int pacman_position_plus_two_x;
        public int pacman_position_plus_two_y;

        public GhostInky()
        {
            run_point_x = 29;
            run_point_y = 26;
        }
    }
}
