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
    class AStar
    {
        //Needed in all path-finding algorithms
        TileX[,] map; // Game Environment
        Point[] directions;
        Point[,] path; // Saves the final path
        //

        // A Star
        List<cell> PQ; // Data Structure that simulates Priority Queue operations
        bool[,] visited;


        List<cell> openList;
        bool[,] closeList;

        public AStar(TileX[,] map)
        {
            this.map = map;
            this.directions = new Point[8];
            this.path = new Point[map.GetLength(0), map.GetLength(1)];

            this.visited = new bool[map.GetLength(0), map.GetLength(1)];
            this.PQ = new List<cell>();
            this.closeList = new bool[map.GetLength(0), map.GetLength(1)];

            this.directions[0] = new Point(1, 0);
            this.directions[1] = new Point(0, 1);
            this.directions[2] = new Point(-1, 0);
            this.directions[3] = new Point(0, -1);
            this.directions[4] = new Point(-1, -1);
            this.directions[5] = new Point(-1, 1);
            this.directions[6] = new Point(1, -1);
            this.directions[7] = new Point(1, 1);

            this.openList = new List<cell>();

        }

        /*
         * A* algorithm Steps:-
         * 
         *      1- Enquueue the source node
         *      
         *      2- Dequeue it
         *         - If the current node is the target, return the path from source to end
         *         
         *      3- Put the current node to your close list
         *      
         *      4- If you are using Euclidean method, then do the following:-
         *         - Get all of its 8 neighbors
         *         - Set the priority of the cells (i.e the cost to move diagonally and to the basic 4 directions)
         *         - Check if you reaches to the next node with lower cost or not, if yes, update its (f, g, h) 
         *         - If it is unvisited node, enqueue it to be examined.
         *         - Do the above steps till your Priority Queue becomes empty
         *         
         *      5- If you are using Manhatten method, then to the following:-
         *         - Get all of its 4 neighbors
         *         - Check if you reaches to the next node with lower cost or not, if yes, update its (f, g, h) 
         *         - If it is unvisited node, enqueue it to be examined.
         *         - Do the above steps till your Priority Queue becomes empty
         *           
         * 
         */

        public List<Point> aStarPathFinder(Point source, Point destintation)
        {
            //YOUR CODE GOES HERE

            return new List<Point>();
        }

        public double getHManhatten(Point source, Point destination)
        {
            return (Math.Abs(destination.X - source.X) + Math.Abs(destination.Y - source.Y));
        }

        public double getHEuclidean(Point source, Point destination)
        {
            return (Math.Sqrt((destination.X - source.X) * (destination.X - source.X) + (destination.Y - source.Y) * (destination.Y - source.Y)));
        }

        public bool isDiagonal(Point next, Point current)
        {
            bool isDiag = false;
            isDiag = ((next.Y < current.Y && next.X > current.X) ||
                            (next.Y < current.Y && next.X < current.X) ||
                            (next.Y > current.Y && next.X > current.X) ||
                            (next.Y > current.Y && next.X > current.X)
                            );
            return isDiag;
        }

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

        public struct cell
        {
            public Point node;
            public double h;
            public double g;
            public double f;
        }
    }
}
