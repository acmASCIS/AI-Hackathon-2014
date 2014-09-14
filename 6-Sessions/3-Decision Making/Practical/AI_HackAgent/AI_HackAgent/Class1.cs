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
            //YOUR CODE GOES HERE
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
