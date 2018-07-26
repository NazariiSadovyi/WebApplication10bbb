using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10bbb.MapGraph
{
    public class Graph
    {
        internal IDictionary<string, Node> Nodes { get; private set; }

        public Graph()
        {
            Nodes = new Dictionary<string, Node>();
        }

        public int left_right;
        public int up_down;
        public int ghost_position_X;
        public int ghost_position_Y;
        public string ghost_position;

        public void cant_back(int left_right, int up_down, string ghost_position)
        {
            this.left_right = left_right;
            this.up_down = up_down;
            this.ghost_position = ghost_position;
            this.ghost_position_X = Convert.ToInt32(ghost_position[1].ToString() + ghost_position[2].ToString());
            this.ghost_position_Y = Convert.ToInt32(ghost_position[5].ToString() + ghost_position[6].ToString());
        }

        public void AddNode(string name)
        {
            var node = new Node(name);
            bool duplicate = Nodes.ContainsKey(name);
            if (duplicate==false)
            Nodes.Add(name, node);
        }

        public void AddConnection(string fromNode, string toNode, int distance, bool twoWay)
        {
            if (fromNode == ghost_position)
            {
                if (left_right == 1)
                {
                    int previos_node_position = Convert.ToInt32(toNode[5].ToString() + toNode[6].ToString());
                    if (previos_node_position < ghost_position_Y)
                    {
                        Nodes[toNode].AddConnection(Nodes[fromNode], distance, false);
                    }
                    else
                    {
                        AddNode(fromNode);
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                    }
                }
                else if (left_right == -1)
                {
                    int previos_node_position = Convert.ToInt32(toNode[5].ToString() + toNode[6].ToString());
                    if (previos_node_position > ghost_position_Y)
                    {
                        Nodes[toNode].AddConnection(Nodes[fromNode], distance, false);
                    }
                    else
                    {
                        AddNode(fromNode);
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                    }
                }
                else if (up_down == 1)
                {
                    int previos_node_position = Convert.ToInt32(toNode[1].ToString() + toNode[2].ToString());
                    if (previos_node_position < ghost_position_X)
                    {
                        Nodes[toNode].AddConnection(Nodes[fromNode], distance, false);
                    }
                    else
                    {
                        AddNode(fromNode);
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                    }
                }
                else if (up_down == -1)
                {
                    int previos_node_position = Convert.ToInt32(toNode[1].ToString() + toNode[2].ToString());
                    if (previos_node_position > ghost_position_X)
                    {
                        Nodes[toNode].AddConnection(Nodes[fromNode], distance, false);
                    }
                    else
                    {
                        AddNode(fromNode);
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                    }
                }
            }
            else if (toNode == ghost_position)
            {
                if (left_right == 1)
                {
                    int previos_node_position = Convert.ToInt32(fromNode[5].ToString() + fromNode[6].ToString());
                    if (previos_node_position < ghost_position_Y)
                    {
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, false);
                    }
                    else
                    {
                        
                            AddNode(fromNode);
                            Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                        
                       
                    }
                }
                else if (left_right == -1)
                {
                    int previos_node_position = Convert.ToInt32(fromNode[5].ToString() + fromNode[6].ToString());
                    if (previos_node_position > ghost_position_Y)
                    {
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, false);
                    }
                    else
                    {
                        AddNode(fromNode);
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                    }
                }
                else if (up_down == 1)
                {
                    int previos_node_position = Convert.ToInt32(fromNode[1].ToString() + fromNode[2].ToString());
                    if (previos_node_position < ghost_position_X)
                    {
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, false);
                    }
                    else
                    {
                        AddNode(fromNode);
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                    }
                }
                else if (up_down == -1)
                {
                    int previos_node_position = Convert.ToInt32(fromNode[1].ToString() + fromNode[2].ToString());
                    if (previos_node_position > ghost_position_X)
                    {
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, false);
                    }
                    else
                    {
                        AddNode(fromNode);
                        Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                    }
                }
            }
            else
            {
               
                    AddNode(fromNode);
                    Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
                
                
            }



        }
    }
}
