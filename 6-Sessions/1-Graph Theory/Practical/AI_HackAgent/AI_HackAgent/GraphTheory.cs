using System;
using System.Collections.Generic;
using System.Text;
using AI_Hack.Agent_Component;
using AI_Hack.Simulator;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using AI_Hack.Core;
using AI_Hack.Loader;
using System.Linq;
using System.Threading.Tasks;



namespace AI_Hack.Simulator
{
    [Serializable]
    class GraphTheory
    {
        //Needed in all path-finding algorithms
        TileX[,] map; // Game Environment
        Point[] directions;
        Point[,] path; // Saves the final path
        //

        // BFS
        bool[,] visited; // Visited Cells on the map
        Queue<Point> Q; // Open list contains the next visited nodes 
        //

        // Dijkstra
        List<KeyValuePair<double, Point>> PQ; // Data Structure that simulates Priority Queue operations
        double[,] distance; // Distance to reach to nodes
        //


        // DFS
        Stack<Point> S = new Stack<Point>();
        //


        public GraphTheory(TileX[,] map)
        {
            this.map = map;
            this.visited = new bool[map.GetLength(0), map.GetLength(1)];
            this.Q = new Queue<Point>();
            this.directions = new Point[8];
            this.path = new Point[map.GetLength(0), map.GetLength(1)];

            this.PQ = new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<double, Point>>();
            this.distance = new double[map.GetLength(0), map.GetLength(1)];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    this.distance[i, j] = double.MaxValue;
                }
            }

            this.directions[0] = new Point(1, 0);
            this.directions[1] = new Point(0, 1);
            this.directions[2] = new Point(-1, 0);
            this.directions[3] = new Point(0, -1);
            this.directions[4] = new Point(1, 1);
            this.directions[5] = new Point(-1, 1);
            this.directions[6] = new Point(1, -1);
            this.directions[7] = new Point(-1, -1);
        }

        /*
         * BFS Algorithm Steps:
         * 
         *  1- Enqueue your start node 
         *  2- Dequeue and do the following:-
         *     - If the the targeted node is found, return the path
         *     - otherwise, enqueue all its children that haven't been visited yet
         *  3- Continue above steps until the queue becomes empty 
         * 
         */

        public List<Point> bfs(Point source, Point destination)
        {
            //YOUR CODE GOES HERE

            return new List<Point>();
        }


        /*
         * Dijkstra Algorithm Steps:
         * 
         *   1- Initialize all dictance to nodes to infinite
         *   2- Set the start node distance to 0
         *   3- Enqueue it in your priority Queue
         *   4- Dequeue and do the following:-
         *      - If the the targeted node is found, return the path
         *      - otherwise, enqueue all its children
         *   5- Check if you can reach to the next node with lower cost
         *   6- Update the reachable distance to the next node
         *   7- Enqueue it with its new cost
         *   8- Repeat until the queue becomes empty
         */

        public List<Point> dijkstra(Point source, Point destination)
        {
            //YOUR CODE GOES HERE

            return new List<Point>();
        }


        ///////////////////////////////////////////////Self-Study 1/////////////////////////////////////////////////////

        /*
         * Complete the following function to implement DFS Algorithm
         */

        public List<Point> dfs(Point source, Point destination)
        {
            return new List<Point>();
        }




        //Helper function to get the path from source to destination node
        private List<Point> getPath(Point source, Point destination)
        {
            List<Point> resultedPath = new List<Point>();
            Point currentPoint = destination;

            while (currentPoint != source)
            {
                resultedPath.Add(currentPoint);
                currentPoint = this.path[currentPoint.X, currentPoint.Y];
            }

            resultedPath.Reverse();

            return resultedPath;
        }

    }

}
