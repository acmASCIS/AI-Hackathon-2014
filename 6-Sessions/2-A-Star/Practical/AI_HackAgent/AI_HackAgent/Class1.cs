using System;
using System.Collections.Generic;
using System.Text;
using AI_Hack.Agent_Component;
using AI_Hack.Simulator;
using System.Runtime.Serialization;
using Microsoft.Xna.Framework;
using AI_Hack.Core;
using AI_Hack.Loader;

namespace AI_Tanks_Project
{
    [Serializable]
    //change class name to your name
    public class AIAgent : Agent, ISerializable
    {
        AStar m_pathFinder;
        public List<Point> m_target;
        public AIAgent(MiniTank t)
            : base(t)
        {

        }
        public override void Input()
        {
            base.Input();
        }

        public override void whenHit()
        {
            //YOUR CODE GOES HERE
            base.whenHit();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime time)
        {
            m_pathFinder = new AStar(tank.Sensor.Map);
            m_target = new List<Point>();
            int X = 0, Y = 0;
            var Flist = tank.Sensor.Flags;
            Index pos = tank.Sensor.tankPosition;
            if (Flist.Count != 0)
            {
                X = Flist[0].x;
                Y = Flist[0].y;
            }
            m_target.Clear();
            ////bfs
            m_target = m_pathFinder.aStarPathFinder(new Point(pos.x, pos.y), new Point(X, Y));
            ////
            if (m_target != null && m_target.Count > 0)
            {
                Point mypoint = new Point(pos.x, pos.y);
                Point nextpoint = m_target[0];
                m_target.RemoveAt(0);
                if (nextpoint.Y < mypoint.Y && nextpoint.X == mypoint.X)
                    tank.move(Movement.North);
                else if (nextpoint.Y > mypoint.Y && nextpoint.X == mypoint.X)
                    tank.move(Movement.South);
                else if (nextpoint.X < mypoint.X && nextpoint.Y == mypoint.Y)
                    tank.move(Movement.West);
                else if (nextpoint.X > mypoint.X && nextpoint.Y == mypoint.Y)
                    tank.move(Movement.East);
                else if (nextpoint.Y < mypoint.Y && nextpoint.X > mypoint.X)
                    tank.move(Movement.NorthEast);
                else if (nextpoint.Y < mypoint.Y && nextpoint.X < mypoint.X)
                    tank.move(Movement.NorthWest);
                else if (nextpoint.Y > mypoint.Y && nextpoint.X > mypoint.X)
                    tank.move(Movement.SouthEast);
                else if (nextpoint.Y > mypoint.Y && nextpoint.X < mypoint.X)
                    tank.move(Movement.SouthWest);
                else ////bfs
                    m_target = m_pathFinder.aStarPathFinder(new Point(pos.x, pos.y), new Point(X, Y));
            }
            else
                tank.move(Movement.Stable);
            base.Update(time);
        }

        public new void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public AIAgent(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }

}
