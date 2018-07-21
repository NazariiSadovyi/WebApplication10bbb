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

        public Init()
        {

        }

        public Tuple<int,int> Inite(int pacmanX,int pacmanY, string pacman_left, string pacman_right, int length1, int length2,int blinkyX, int blinkyY, int ghost_move_x, int ghost_move_y)
        {
            string pacman_position = (pacmanX + 100).ToString() + "_" + (pacmanY + 100).ToString();
            string blinki_position = (blinkyX + 100).ToString() + "_" + (blinkyY + 100).ToString();



            graph.AddNode(pacman_position);
            graph.AddNode("101_101");
            graph.AddNode("101_106");
            graph.AddNode("101_112");
            graph.AddNode("101_115");
            graph.AddNode("101_121");
            graph.AddNode("101_126");

            graph.AddNode("105_101");
            graph.AddNode("105_106");
            graph.AddNode("105_109");
            graph.AddNode("105_112");
            graph.AddNode("105_115");
            graph.AddNode("105_118");
            graph.AddNode("105_121");
            graph.AddNode("105_126");

            graph.AddNode("108_101");
            graph.AddNode("108_106");
            graph.AddNode("108_109");
            graph.AddNode("108_112");
            graph.AddNode("108_115");
            graph.AddNode("108_118");
            graph.AddNode("108_121");
            graph.AddNode("108_126");


            graph.AddNode("111_109");
            graph.AddNode("111_112");
            graph.AddNode("111_115");
            graph.AddNode("111_118");


            graph.AddNode("114_106");
            graph.AddNode("114_109");
            graph.AddNode("114_118");
            graph.AddNode("114_121");


            graph.AddNode("117_109");
            graph.AddNode("117_118");


            graph.AddNode("120_101");
            graph.AddNode("120_106");
            graph.AddNode("120_109");
            graph.AddNode("120_112");
            graph.AddNode("120_115");
            graph.AddNode("120_118");
            graph.AddNode("120_121");
            graph.AddNode("120_126");


            graph.AddNode("123_101");
            graph.AddNode("123_103");
            graph.AddNode("123_106");
            graph.AddNode("123_109");
            graph.AddNode("123_112");
            graph.AddNode("123_115");
            graph.AddNode("123_118");
            graph.AddNode("123_121");
            graph.AddNode("123_124");
            graph.AddNode("123_126");


            graph.AddNode("126_101");
            graph.AddNode("126_103");
            graph.AddNode("126_106");
            graph.AddNode("126_109");
            graph.AddNode("126_112");
            graph.AddNode("126_115");
            graph.AddNode("126_118");
            graph.AddNode("126_121");
            graph.AddNode("126_124");
            graph.AddNode("126_126");


            graph.AddNode("129_101");
            graph.AddNode("129_112");
            graph.AddNode("129_115");
            graph.AddNode("129_126");



            graph.cant_back(ghost_move_y, ghost_move_x, blinki_position);


            //Connections
            graph.AddConnection(pacman_left, pacman_position, length1, true);
            graph.AddConnection(pacman_right, pacman_position, length2, true);
            graph.AddConnection("101_101", "101_106", 5, true);
            graph.AddConnection("101_101", "105_101", 4, true);
            graph.AddConnection("101_106", "101_112", 6, true);
            graph.AddConnection("101_106", "105_106", 4, true);
            graph.AddConnection("101_112", "105_112", 4, true);
            graph.AddConnection("105_101", "108_101", 3, true);
            graph.AddConnection("105_101", "105_106", 5, true);
            graph.AddConnection("105_106", "105_109", 3, true);
            graph.AddConnection("105_106", "108_106", 3, true);
            graph.AddConnection("108_101", "108_106", 5, true);
            graph.AddConnection("108_109", "105_109", 3, true);
            graph.AddConnection("105_109", "105_112", 3, true);

            graph.AddConnection("105_112", "105_115", 3, true);
            graph.AddConnection("108_109", "108_112", 3, true);
            graph.AddConnection("105_115", "101_115", 4, true);
            graph.AddConnection("105_115", "105_118", 3, true);
            graph.AddConnection("105_118", "108_118", 3, true);
            graph.AddConnection("105_118", "105_121", 3, true);
            graph.AddConnection("108_118", "108_115", 3, true);
            graph.AddConnection("105_121", "108_121", 3, true);
            graph.AddConnection("105_121", "105_126", 5, true);
            graph.AddConnection("108_121", "108_126", 5, true);
            graph.AddConnection("105_126", "108_126", 3, true);
            graph.AddConnection("101_115", "101_121", 6, true);
            graph.AddConnection("105_121", "101_121", 4, true);
            graph.AddConnection("101_126", "101_121", 5, true);
            graph.AddConnection("101_126", "105_126", 6, true);


            graph.AddConnection("108_106", "114_106", 6, true);
            graph.AddConnection("108_112", "111_112", 3, true);
            graph.AddConnection("111_109", "111_112", 3, true);
            graph.AddConnection("111_115", "111_112", 3, true);
            graph.AddConnection("111_115", "108_115", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("108_121", "114_121", 6, true);
            graph.AddConnection("111_118", "114_118", 3, true);
            graph.AddConnection("114_118", "114_121", 3, true);
            graph.AddConnection("111_109", "114_109", 3, true);
            graph.AddConnection("114_106", "114_109", 3, true);
            graph.AddConnection("114_106", "120_106", 6, true);
            graph.AddConnection("114_109", "117_109", 3, true);
            graph.AddConnection("120_109", "117_109", 3, true);
            graph.AddConnection("117_109", "117_118", 9, true);
            graph.AddConnection("114_118", "117_118", 3, true);
            graph.AddConnection("120_118", "117_118", 3, true);
            graph.AddConnection("114_121", "120_121", 6, true);


            graph.AddConnection("120_101", "120_106", 5, true);
            graph.AddConnection("120_101", "123_101", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("123_106", "120_106", 3, true);
            graph.AddConnection("120_109", "120_112", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("120_112", "123_112", 3, true);
            graph.AddConnection("123_103", "123_101", 2, true);
            graph.AddConnection("123_109", "123_106", 3, true);
            graph.AddConnection("123_109", "123_112", 3, true);
            graph.AddConnection("123_112", "123_115", 3, true);
            graph.AddConnection("123_118", "123_115", 3, true);
            graph.AddConnection("120_115", "123_115", 3, true);
            graph.AddConnection("123_118", "123_121", 3, true);
            graph.AddConnection("120_121", "123_121", 3, true);
            graph.AddConnection("120_121", "120_118", 3, true);
            graph.AddConnection("120_121", "120_126", 5, true);
            graph.AddConnection("120_115", "120_118", 3, true);
            graph.AddConnection("120_126", "123_126", 3, true);
            graph.AddConnection("123_124", "123_126", 2, true);


            graph.AddConnection("123_124", "126_124", 3, true);
            graph.AddConnection("126_126", "126_124", 2, true);
            graph.AddConnection("126_121", "126_124", 3, true);
            graph.AddConnection("126_121", "123_121", 3, true);
            graph.AddConnection("129_126", "126_126", 3, true);
            graph.AddConnection("129_126", "129_115", 11, true);
            graph.AddConnection("129_115", "126_115", 3, true);
            graph.AddConnection("126_115", "126_118", 3, true);
            graph.AddConnection("126_118", "123_118", 3, true);
            graph.AddConnection("129_115", "129_112", 3, true);
            graph.AddConnection("126_112", "129_112", 3, true);
            graph.AddConnection("129_101", "129_112", 11, true);
            graph.AddConnection("126_109", "126_112", 3, true);
            graph.AddConnection("126_109", "123_109", 3, true);
            graph.AddConnection("129_101", "126_101", 3, true);
            graph.AddConnection("126_101", "126_103", 2, true);
            graph.AddConnection("126_103", "126_106", 3, true);
            graph.AddConnection("126_103", "123_103", 3, true);
            graph.AddConnection("126_106", "123_106", 3, true);
                        

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



            //graph.AddNode(pacman_position);
            graph.AddNode("101_101");
            graph.AddNode("101_106");
            graph.AddNode("101_112");
            graph.AddNode("101_115");
            graph.AddNode("101_121");
            graph.AddNode("101_126");

            graph.AddNode("105_101");
            graph.AddNode("105_106");
            graph.AddNode("105_109");
            graph.AddNode("105_112");
            graph.AddNode("105_115");
            graph.AddNode("105_118");
            graph.AddNode("105_121");
            graph.AddNode("105_126");

            graph.AddNode("108_101");
            graph.AddNode("108_106");
            graph.AddNode("108_109");
            graph.AddNode("108_112");
            graph.AddNode("108_115");
            graph.AddNode("108_118");
            graph.AddNode("108_121");
            graph.AddNode("108_126");


            graph.AddNode("111_109");
            graph.AddNode("111_112");
            graph.AddNode("111_115");
            graph.AddNode("111_118");


            graph.AddNode("114_106");
            graph.AddNode("114_109");
            graph.AddNode("114_118");
            graph.AddNode("114_121");


            graph.AddNode("117_109");
            graph.AddNode("117_118");


            graph.AddNode("120_101");
            graph.AddNode("120_106");
            graph.AddNode("120_109");
            graph.AddNode("120_112");
            graph.AddNode("120_115");
            graph.AddNode("120_118");
            graph.AddNode("120_121");
            graph.AddNode("120_126");


            graph.AddNode("123_101");
            graph.AddNode("123_103");
            graph.AddNode("123_106");
            graph.AddNode("123_109");
            graph.AddNode("123_112");
            graph.AddNode("123_115");
            graph.AddNode("123_118");
            graph.AddNode("123_121");
            graph.AddNode("123_124");
            graph.AddNode("123_126");


            graph.AddNode("126_101");
            graph.AddNode("126_103");
            graph.AddNode("126_106");
            graph.AddNode("126_109");
            graph.AddNode("126_112");
            graph.AddNode("126_115");
            graph.AddNode("126_118");
            graph.AddNode("126_121");
            graph.AddNode("126_124");
            graph.AddNode("126_126");


            graph.AddNode("129_101");
            graph.AddNode("129_112");
            graph.AddNode("129_115");
            graph.AddNode("129_126");

            graph.cant_back(ghost_move_y, ghost_move_x, blinki_position);


            //Connections
            //graph.AddConnection(pacman_left, pacman_position, length1, true);
            //graph.AddConnection(pacman_right, pacman_position, length2, true);
            graph.AddConnection("101_101", "101_106", 5, true);
            graph.AddConnection("101_101", "105_101", 4, true);
            graph.AddConnection("101_106", "101_112", 6, true);
            graph.AddConnection("101_106", "105_106", 4, true);
            graph.AddConnection("101_112", "105_112", 4, true);
            graph.AddConnection("105_101", "108_101", 3, true);
            graph.AddConnection("105_101", "105_106", 5, true);
            graph.AddConnection("105_106", "105_109", 3, true);
            graph.AddConnection("105_106", "108_106", 3, true);
            graph.AddConnection("108_101", "108_106", 5, true);
            graph.AddConnection("108_109", "105_109", 3, true);
            graph.AddConnection("105_109", "105_112", 3, true);

            graph.AddConnection("105_112", "105_115", 3, true);
            graph.AddConnection("108_109", "108_112", 3, true);
            graph.AddConnection("105_115", "101_115", 4, true);
            graph.AddConnection("105_115", "105_118", 3, true);
            graph.AddConnection("105_118", "108_118", 3, true);
            graph.AddConnection("105_118", "105_121", 3, true);
            graph.AddConnection("108_118", "108_115", 3, true);
            graph.AddConnection("105_121", "108_121", 3, true);
            graph.AddConnection("105_121", "105_126", 5, true);
            graph.AddConnection("108_121", "108_126", 5, true);
            graph.AddConnection("105_126", "108_126", 3, true);
            graph.AddConnection("101_115", "101_121", 6, true);
            graph.AddConnection("105_121", "101_121", 4, true);
            graph.AddConnection("101_126", "101_121", 5, true);
            graph.AddConnection("101_126", "105_126", 6, true);


            graph.AddConnection("108_106", "114_106", 6, true);
            graph.AddConnection("108_112", "111_112", 3, true);
            graph.AddConnection("111_109", "111_112", 3, true);
            graph.AddConnection("111_115", "111_112", 3, true);
            graph.AddConnection("111_115", "108_115", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("108_121", "114_121", 6, true);
            graph.AddConnection("111_118", "114_118", 3, true);
            graph.AddConnection("114_118", "114_121", 3, true);
            graph.AddConnection("111_109", "114_109", 3, true);
            graph.AddConnection("114_106", "114_109", 3, true);
            graph.AddConnection("114_106", "120_106", 6, true);
            graph.AddConnection("114_109", "117_109", 3, true);
            graph.AddConnection("120_109", "117_109", 3, true);
            graph.AddConnection("117_109", "117_118", 9, true);
            graph.AddConnection("114_118", "117_118", 3, true);
            graph.AddConnection("120_118", "117_118", 3, true);
            graph.AddConnection("114_121", "120_121", 6, true);


            graph.AddConnection("120_101", "120_106", 5, true);
            graph.AddConnection("120_101", "123_101", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("123_106", "120_106", 3, true);
            graph.AddConnection("120_109", "120_112", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("120_112", "123_112", 3, true);
            graph.AddConnection("123_103", "123_101", 2, true);
            graph.AddConnection("123_109", "123_106", 3, true);
            graph.AddConnection("123_109", "123_112", 3, true);
            graph.AddConnection("123_112", "123_115", 3, true);
            graph.AddConnection("123_118", "123_115", 3, true);
            graph.AddConnection("120_115", "123_115", 3, true);
            graph.AddConnection("123_118", "123_121", 3, true);
            graph.AddConnection("120_121", "123_121", 3, true);
            graph.AddConnection("120_121", "120_118", 3, true);
            graph.AddConnection("120_121", "120_126", 5, true);
            graph.AddConnection("120_115", "120_118", 3, true);
            graph.AddConnection("120_126", "123_126", 3, true);
            graph.AddConnection("123_124", "123_126", 2, true);


            graph.AddConnection("123_124", "126_124", 3, true);
            graph.AddConnection("126_126", "126_124", 2, true);
            graph.AddConnection("126_121", "126_124", 3, true);
            graph.AddConnection("126_121", "123_121", 3, true);
            graph.AddConnection("129_126", "126_126", 3, true);
            graph.AddConnection("129_126", "129_115", 11, true);
            graph.AddConnection("129_115", "126_115", 3, true);
            graph.AddConnection("126_115", "126_118", 3, true);
            graph.AddConnection("126_118", "123_118", 3, true);
            graph.AddConnection("129_115", "129_112", 3, true);
            graph.AddConnection("126_112", "129_112", 3, true);
            graph.AddConnection("129_101", "129_112", 11, true);
            graph.AddConnection("126_109", "126_112", 3, true);
            graph.AddConnection("126_109", "123_109", 3, true);
            graph.AddConnection("129_101", "126_101", 3, true);
            graph.AddConnection("126_101", "126_103", 2, true);
            graph.AddConnection("126_103", "126_106", 3, true);
            graph.AddConnection("126_103", "123_103", 3, true);
            graph.AddConnection("126_106", "123_106", 3, true);



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



            //graph.AddNode(pacman_position);
            graph.AddNode("101_101");
            graph.AddNode("101_106");
            graph.AddNode("101_112");
            graph.AddNode("101_115");
            graph.AddNode("101_121");
            graph.AddNode("101_126");

            graph.AddNode("105_101");
            graph.AddNode("105_106");
            graph.AddNode("105_109");
            graph.AddNode("105_112");
            graph.AddNode("105_115");
            graph.AddNode("105_118");
            graph.AddNode("105_121");
            graph.AddNode("105_126");

            graph.AddNode("108_101");
            graph.AddNode("108_106");
            graph.AddNode("108_109");
            graph.AddNode("108_112");
            graph.AddNode("108_115");
            graph.AddNode("108_118");
            graph.AddNode("108_121");
            graph.AddNode("108_126");


            graph.AddNode("111_109");
            graph.AddNode("111_112");
            graph.AddNode("111_115");
            graph.AddNode("111_118");


            graph.AddNode("114_106");
            graph.AddNode("114_109");
            graph.AddNode("114_118");
            graph.AddNode("114_121");


            graph.AddNode("117_109");
            graph.AddNode("117_118");


            graph.AddNode("120_101");
            graph.AddNode("120_106");
            graph.AddNode("120_109");
            graph.AddNode("120_112");
            graph.AddNode("120_115");
            graph.AddNode("120_118");
            graph.AddNode("120_121");
            graph.AddNode("120_126");


            graph.AddNode("123_101");
            graph.AddNode("123_103");
            graph.AddNode("123_106");
            graph.AddNode("123_109");
            graph.AddNode("123_112");
            graph.AddNode("123_115");
            graph.AddNode("123_118");
            graph.AddNode("123_121");
            graph.AddNode("123_124");
            graph.AddNode("123_126");


            graph.AddNode("126_101");
            graph.AddNode("126_103");
            graph.AddNode("126_106");
            graph.AddNode("126_109");
            graph.AddNode("126_112");
            graph.AddNode("126_115");
            graph.AddNode("126_118");
            graph.AddNode("126_121");
            graph.AddNode("126_124");
            graph.AddNode("126_126");


            graph.AddNode("129_101");
            graph.AddNode("129_112");
            graph.AddNode("129_115");
            graph.AddNode("129_126");

            graph.cant_back(ghost_move_y, ghost_move_x, blinki_position);


            //Connections
            //graph.AddConnection(pacman_left, pacman_position, length1, true);
            //graph.AddConnection(pacman_right, pacman_position, length2, true);
            graph.AddConnection("101_101", "101_106", 5, true);
            graph.AddConnection("101_101", "105_101", 4, true);
            graph.AddConnection("101_106", "101_112", 6, true);
            graph.AddConnection("101_106", "105_106", 4, true);
            graph.AddConnection("101_112", "105_112", 4, true);
            graph.AddConnection("105_101", "108_101", 3, true);
            graph.AddConnection("105_101", "105_106", 5, true);
            graph.AddConnection("105_106", "105_109", 3, true);
            graph.AddConnection("105_106", "108_106", 3, true);
            graph.AddConnection("108_101", "108_106", 5, true);
            graph.AddConnection("108_109", "105_109", 3, true);
            graph.AddConnection("105_109", "105_112", 3, true);

            graph.AddConnection("105_112", "105_115", 3, true);
            graph.AddConnection("108_109", "108_112", 3, true);
            graph.AddConnection("105_115", "101_115", 4, true);
            graph.AddConnection("105_115", "105_118", 3, true);
            graph.AddConnection("105_118", "108_118", 3, true);
            graph.AddConnection("105_118", "105_121", 3, true);
            graph.AddConnection("108_118", "108_115", 3, true);
            graph.AddConnection("105_121", "108_121", 3, true);
            graph.AddConnection("105_121", "105_126", 5, true);
            graph.AddConnection("108_121", "108_126", 5, true);
            graph.AddConnection("105_126", "108_126", 3, true);
            graph.AddConnection("101_115", "101_121", 6, true);
            graph.AddConnection("105_121", "101_121", 4, true);
            graph.AddConnection("101_126", "101_121", 5, true);
            graph.AddConnection("101_126", "105_126", 6, true);


            graph.AddConnection("108_106", "114_106", 6, true);
            graph.AddConnection("108_112", "111_112", 3, true);
            graph.AddConnection("111_109", "111_112", 3, true);
            graph.AddConnection("111_115", "111_112", 3, true);
            graph.AddConnection("111_115", "108_115", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("108_121", "114_121", 6, true);
            graph.AddConnection("111_118", "114_118", 3, true);
            graph.AddConnection("114_118", "114_121", 3, true);
            graph.AddConnection("111_109", "114_109", 3, true);
            graph.AddConnection("114_106", "114_109", 3, true);
            graph.AddConnection("114_106", "120_106", 6, true);
            graph.AddConnection("114_109", "117_109", 3, true);
            graph.AddConnection("120_109", "117_109", 3, true);
            graph.AddConnection("117_109", "117_118", 9, true);
            graph.AddConnection("114_118", "117_118", 3, true);
            graph.AddConnection("120_118", "117_118", 3, true);
            graph.AddConnection("114_121", "120_121", 6, true);


            graph.AddConnection("120_101", "120_106", 5, true);
            graph.AddConnection("120_101", "123_101", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("123_106", "120_106", 3, true);
            graph.AddConnection("120_109", "120_112", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("120_112", "123_112", 3, true);
            graph.AddConnection("123_103", "123_101", 2, true);
            graph.AddConnection("123_109", "123_106", 3, true);
            graph.AddConnection("123_109", "123_112", 3, true);
            graph.AddConnection("123_112", "123_115", 3, true);
            graph.AddConnection("123_118", "123_115", 3, true);
            graph.AddConnection("120_115", "123_115", 3, true);
            graph.AddConnection("123_118", "123_121", 3, true);
            graph.AddConnection("120_121", "123_121", 3, true);
            graph.AddConnection("120_121", "120_118", 3, true);
            graph.AddConnection("120_121", "120_126", 5, true);
            graph.AddConnection("120_115", "120_118", 3, true);
            graph.AddConnection("120_126", "123_126", 3, true);
            graph.AddConnection("123_124", "123_126", 2, true);


            graph.AddConnection("123_124", "126_124", 3, true);
            graph.AddConnection("126_126", "126_124", 2, true);
            graph.AddConnection("126_121", "126_124", 3, true);
            graph.AddConnection("126_121", "123_121", 3, true);
            graph.AddConnection("129_126", "126_126", 3, true);
            graph.AddConnection("129_126", "129_115", 11, true);
            graph.AddConnection("129_115", "126_115", 3, true);
            graph.AddConnection("126_115", "126_118", 3, true);
            graph.AddConnection("126_118", "123_118", 3, true);
            graph.AddConnection("129_115", "129_112", 3, true);
            graph.AddConnection("126_112", "129_112", 3, true);
            graph.AddConnection("129_101", "129_112", 11, true);
            graph.AddConnection("126_109", "126_112", 3, true);
            graph.AddConnection("126_109", "123_109", 3, true);
            graph.AddConnection("129_101", "126_101", 3, true);
            graph.AddConnection("126_101", "126_103", 2, true);
            graph.AddConnection("126_103", "126_106", 3, true);
            graph.AddConnection("126_103", "123_103", 3, true);
            graph.AddConnection("126_106", "123_106", 3, true);



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

        public int Shortest_way2(int pacmanX, int pacmanY, string pacman_left, string pacman_right, int length1, int length2, int blinkyX, int blinkyY, int ghost_move_x, int ghost_move_y)
        {
            string pacman_position = (pacmanX + 100).ToString() + "_" + (pacmanY + 100).ToString();
            string blinki_position = (blinkyX + 100).ToString() + "_" + (blinkyY + 100).ToString();



            graph.AddNode(pacman_position);
            graph.AddNode("101_101");
            graph.AddNode("101_106");
            graph.AddNode("101_112");
            graph.AddNode("101_115");
            graph.AddNode("101_121");
            graph.AddNode("101_126");

            graph.AddNode("105_101");
            graph.AddNode("105_106");
            graph.AddNode("105_109");
            graph.AddNode("105_112");
            graph.AddNode("105_115");
            graph.AddNode("105_118");
            graph.AddNode("105_121");
            graph.AddNode("105_126");

            graph.AddNode("108_101");
            graph.AddNode("108_106");
            graph.AddNode("108_109");
            graph.AddNode("108_112");
            graph.AddNode("108_115");
            graph.AddNode("108_118");
            graph.AddNode("108_121");
            graph.AddNode("108_126");


            graph.AddNode("111_109");
            graph.AddNode("111_112");
            graph.AddNode("111_115");
            graph.AddNode("111_118");


            graph.AddNode("114_106");
            graph.AddNode("114_109");
            graph.AddNode("114_118");
            graph.AddNode("114_121");


            graph.AddNode("117_109");
            graph.AddNode("117_118");


            graph.AddNode("120_101");
            graph.AddNode("120_106");
            graph.AddNode("120_109");
            graph.AddNode("120_112");
            graph.AddNode("120_115");
            graph.AddNode("120_118");
            graph.AddNode("120_121");
            graph.AddNode("120_126");


            graph.AddNode("123_101");
            graph.AddNode("123_103");
            graph.AddNode("123_106");
            graph.AddNode("123_109");
            graph.AddNode("123_112");
            graph.AddNode("123_115");
            graph.AddNode("123_118");
            graph.AddNode("123_121");
            graph.AddNode("123_124");
            graph.AddNode("123_126");


            graph.AddNode("126_101");
            graph.AddNode("126_103");
            graph.AddNode("126_106");
            graph.AddNode("126_109");
            graph.AddNode("126_112");
            graph.AddNode("126_115");
            graph.AddNode("126_118");
            graph.AddNode("126_121");
            graph.AddNode("126_124");
            graph.AddNode("126_126");


            graph.AddNode("129_101");
            graph.AddNode("129_112");
            graph.AddNode("129_115");
            graph.AddNode("129_126");



            graph.cant_back(ghost_move_y, ghost_move_x, blinki_position);


            //Connections
            graph.AddConnection(pacman_left, pacman_position, length1, true);
            graph.AddConnection(pacman_right, pacman_position, length2, true);
            graph.AddConnection("101_101", "101_106", 5, true);
            graph.AddConnection("101_101", "105_101", 4, true);
            graph.AddConnection("101_106", "101_112", 6, true);
            graph.AddConnection("101_106", "105_106", 4, true);
            graph.AddConnection("101_112", "105_112", 4, true);
            graph.AddConnection("105_101", "108_101", 3, true);
            graph.AddConnection("105_101", "105_106", 5, true);
            graph.AddConnection("105_106", "105_109", 3, true);
            graph.AddConnection("105_106", "108_106", 3, true);
            graph.AddConnection("108_101", "108_106", 5, true);
            graph.AddConnection("108_109", "105_109", 3, true);
            graph.AddConnection("105_109", "105_112", 3, true);

            graph.AddConnection("105_112", "105_115", 3, true);
            graph.AddConnection("108_109", "108_112", 3, true);
            graph.AddConnection("105_115", "101_115", 4, true);
            graph.AddConnection("105_115", "105_118", 3, true);
            graph.AddConnection("105_118", "108_118", 3, true);
            graph.AddConnection("105_118", "105_121", 3, true);
            graph.AddConnection("108_118", "108_115", 3, true);
            graph.AddConnection("105_121", "108_121", 3, true);
            graph.AddConnection("105_121", "105_126", 5, true);
            graph.AddConnection("108_121", "108_126", 5, true);
            graph.AddConnection("105_126", "108_126", 3, true);
            graph.AddConnection("101_115", "101_121", 6, true);
            graph.AddConnection("105_121", "101_121", 4, true);
            graph.AddConnection("101_126", "101_121", 5, true);
            graph.AddConnection("101_126", "105_126", 6, true);


            graph.AddConnection("108_106", "114_106", 6, true);
            graph.AddConnection("108_112", "111_112", 3, true);
            graph.AddConnection("111_109", "111_112", 3, true);
            graph.AddConnection("111_115", "111_112", 3, true);
            graph.AddConnection("111_115", "108_115", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("111_115", "111_118", 3, true);
            graph.AddConnection("108_121", "114_121", 6, true);
            graph.AddConnection("111_118", "114_118", 3, true);
            graph.AddConnection("114_118", "114_121", 3, true);
            graph.AddConnection("111_109", "114_109", 3, true);
            graph.AddConnection("114_106", "114_109", 3, true);
            graph.AddConnection("114_106", "120_106", 6, true);
            graph.AddConnection("114_109", "117_109", 3, true);
            graph.AddConnection("120_109", "117_109", 3, true);
            graph.AddConnection("117_109", "117_118", 9, true);
            graph.AddConnection("114_118", "117_118", 3, true);
            graph.AddConnection("120_118", "117_118", 3, true);
            graph.AddConnection("114_121", "120_121", 6, true);


            graph.AddConnection("120_101", "120_106", 5, true);
            graph.AddConnection("120_101", "123_101", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("123_106", "120_106", 3, true);
            graph.AddConnection("120_109", "120_112", 3, true);
            graph.AddConnection("120_109", "120_106", 3, true);
            graph.AddConnection("120_112", "123_112", 3, true);
            graph.AddConnection("123_103", "123_101", 2, true);
            graph.AddConnection("123_109", "123_106", 3, true);
            graph.AddConnection("123_109", "123_112", 3, true);
            graph.AddConnection("123_112", "123_115", 3, true);
            graph.AddConnection("123_118", "123_115", 3, true);
            graph.AddConnection("120_115", "123_115", 3, true);
            graph.AddConnection("123_118", "123_121", 3, true);
            graph.AddConnection("120_121", "123_121", 3, true);
            graph.AddConnection("120_121", "120_118", 3, true);
            graph.AddConnection("120_121", "120_126", 5, true);
            graph.AddConnection("120_115", "120_118", 3, true);
            graph.AddConnection("120_126", "123_126", 3, true);
            graph.AddConnection("123_124", "123_126", 2, true);


            graph.AddConnection("123_124", "126_124", 3, true);
            graph.AddConnection("126_126", "126_124", 2, true);
            graph.AddConnection("126_121", "126_124", 3, true);
            graph.AddConnection("126_121", "123_121", 3, true);
            graph.AddConnection("129_126", "126_126", 3, true);
            graph.AddConnection("129_126", "129_115", 11, true);
            graph.AddConnection("129_115", "126_115", 3, true);
            graph.AddConnection("126_115", "126_118", 3, true);
            graph.AddConnection("126_118", "123_118", 3, true);
            graph.AddConnection("129_115", "129_112", 3, true);
            graph.AddConnection("126_112", "129_112", 3, true);
            graph.AddConnection("129_101", "129_112", 11, true);
            graph.AddConnection("126_109", "126_112", 3, true);
            graph.AddConnection("126_109", "123_109", 3, true);
            graph.AddConnection("129_101", "126_101", 3, true);
            graph.AddConnection("126_101", "126_103", 2, true);
            graph.AddConnection("126_103", "126_106", 3, true);
            graph.AddConnection("126_103", "123_103", 3, true);
            graph.AddConnection("126_106", "123_106", 3, true);


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
