using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication10bbb.MapGraph;
using System.Threading.Tasks;

namespace WebApplication10bbb.MapGraph
{
    public class Init
    {
        public Graph graph = new Graph();

        public GameMap gameMap = new GameMap();

        public Init()
        {

        }

        private void AddDefoultNodeAndConnection()
        {
            for (int i = 0; i < 31; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    if (gameMap.map[i, j] == 'c')
                    {
                        string first = (i + 100).ToString() + "_" + (j + 100).ToString();
                        graph.AddNode(first);
                        
                        int lengh_right = 1;
                        int lengh_bottom = 1;
                                                
                        if (gameMap.map[i + lengh_bottom, j] != 'w')
                        {
                            while ((gameMap.map[i + lengh_bottom, j] == ' '))
                            {
                                lengh_bottom++;
                            }
                                                        
                            string second = (i + lengh_bottom + 100).ToString() + "_" + (j + 100).ToString();
                                                       
                            graph.AddNode(second);

                            graph.AddConnection(first, second, lengh_bottom, true);

                        }

                        if (gameMap.map[i, j + lengh_right] != 'w')
                        {
                            while ((gameMap.map[i, j + lengh_right] == ' '))
                            {
                                lengh_right++;
                            }
                            
                            string second = (i + 100).ToString() + "_" + (j + lengh_right + 100).ToString();
                                                        
                            graph.AddNode(second);

                            graph.AddConnection(first, second, lengh_bottom, true);
                        }
                    }
                };

            }

        }

        public Tuple<int,int> Inite(int pacmanX,int pacmanY, int blinkyX, int blinkyY)
        {
            string pacman_position = (pacmanX + 100).ToString() + "_" + (pacmanY + 100).ToString();
            string blinki_position = (blinkyX + 100).ToString() + "_" + (blinkyY + 100).ToString();


            gameMap.map[pacmanX, pacmanY] = 'c';
            gameMap.map[blinkyX, blinkyY] = 'c';


            AddDefoultNodeAndConnection();

            //graph.cant_back(ghost_move_y, ghost_move_x, blinki_position);
                      
            var target_connection = graph.Nodes.Values.ToList().Find(x => x.Name == blinki_position);

            var calculator = new DistanceCalculator();

            double lengthhhh = 1000;
            string minlength = "";

            int moveX = 0;
            int moveY = 0;

           

            foreach (var a in target_connection.Connections)
            {
                var t = a.Target.Name.ToString();

                var distances = calculator.CalculateDistances(graph, t);

                foreach (var d in distances)
                {
                    if (d.Key == pacman_position)
                    {                        
                        if (d.Value + a.Distance < lengthhhh)
                        {
                            minlength = t;
                            lengthhhh = d.Value + a.Distance;
                        }
                    }
                }

            }

            var nx = Convert.ToInt32(minlength[1].ToString() + minlength[2].ToString());
            var ny = Convert.ToInt32(minlength[5].ToString() + minlength[6].ToString());

            var cx = Convert.ToInt32(blinki_position[1].ToString() + blinki_position[2].ToString());
            var cy = Convert.ToInt32(blinki_position[5].ToString() + blinki_position[6].ToString());

             

            if (nx < cx)
            {
                moveX = -1;
            }
            else if (nx > cx)
            {
                moveX = 1;
            }

            if (ny > cy)
            {
                moveY = 1;
            }
            else if (ny < cy)
            {
                moveY = -1;
            }

            
            int UpOrDown = moveX;
            int LeftOrRight = moveY;



            return Tuple.Create(UpOrDown, LeftOrRight);

        }
        
        public Tuple<int, int> Inite2(int pacmanX, int pacmanY, int blinkyX, int blinkyY, int ghost_move_x, int ghost_move_y)
        {
            string pacman_position = (pacmanX + 100).ToString() + "_" + (pacmanY + 100).ToString();
            string blinki_position = (blinkyX + 100).ToString() + "_" + (blinkyY + 100).ToString();


            gameMap.map[pacmanX, pacmanY] = 'c';
            gameMap.map[blinkyX, blinkyY] = 'c'; 
            
            graph.cant_back(ghost_move_y, ghost_move_x, blinki_position);
            
            AddDefoultNodeAndConnection();


            var target_connection = graph.Nodes.Values.ToList().Find(x => x.Name == blinki_position);

            var calculator = new DistanceCalculator();

            double lengthhhh = 1000;
            string minlength = "";

            int moveX = 0;
            int moveY = 0;

                    

                foreach (var a in target_connection.Connections)
                {
                    var t = a.Target.Name.ToString();

                    var distances = calculator.CalculateDistances(graph, t);

                    foreach (var d in distances)
                    {
                        if (d.Key == pacman_position)
                        {
                            if (d.Value + a.Distance < lengthhhh)
                            {
                                minlength = t;
                                lengthhhh = d.Value + a.Distance;
                            }
                        }
                    }

                }

                var nx = Convert.ToInt32(minlength[1].ToString() + minlength[2].ToString());
                var ny = Convert.ToInt32(minlength[5].ToString() + minlength[6].ToString());

                var cx = Convert.ToInt32(blinki_position[1].ToString() + blinki_position[2].ToString());
                var cy = Convert.ToInt32(blinki_position[5].ToString() + blinki_position[6].ToString());

           

                if (nx < cx)
                {
                    moveX = -1;
                }
                else if (nx > cx)
                {
                    moveX = 1;
                }

                if (ny > cy)
                {
                    moveY = 1;
                }
                else if (ny < cy)
                {
                    moveY = -1;
                }

          

            int UpOrDown = moveX;
            int LeftOrRight = moveY;



            return Tuple.Create(UpOrDown, LeftOrRight);

        }

        public int Shortest_way(int pacmanX, int pacmanY, int blinkyX, int blinkyY, int ghost_move_x, int ghost_move_y)
        {
            string pacman_position = (pacmanX + 100).ToString() + "_" + (pacmanY + 100).ToString();
            string blinki_position = (blinkyX + 100).ToString() + "_" + (blinkyY + 100).ToString();
            
            graph.cant_back(ghost_move_y, ghost_move_x, blinki_position);
            
            AddDefoultNodeAndConnection();

            var target_connection = graph.Nodes.Values.ToList().Find(x => x.Name == blinki_position);

            var calculator = new DistanceCalculator();

            double lengthhhh = 1000;
            string minlength = "";

            foreach (var a in target_connection.Connections)
            {
                var t = a.Target.Name.ToString();

                var distances = calculator.CalculateDistances(graph, t);

                foreach (var d in distances)
                {
                    if (d.Key == pacman_position)
                    {
                        if (d.Value + a.Distance < lengthhhh)
                        {
                            minlength = t;
                            lengthhhh = d.Value + a.Distance;
                        }
                    }
                }

            }

            return Convert.ToInt32(lengthhhh);

        }

        
    }
}
