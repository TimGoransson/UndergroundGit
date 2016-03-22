using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Underground
{
    abstract class MovableGameObjects : GameObject
    {       
        protected bool active;
        protected Vector2 velocity;
        protected bool isOnGround;
        public MovableGameObjects(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            
        }

        public override void Update()
        {
         
        }

        public override void Draw()
        {

        }
        public virtual bool IsColliding(GameObject g)
        {
            return HitBox.Intersects(g.HitBox);
        }
        public virtual void HandleCollisionPlatform(Platform other)
        {
            //if (other.CollisionType != 0)
            //{
                Vector2 depth = Utilities.GetIntersectionDepth(HitBox, other.HitBox);
                float absDepthX = Math.Abs(depth.X);
                float absDepthY = Math.Abs(depth.Y);
                //|| other.CollisionType == 2
                if (absDepthY < absDepthX)
                {
                    if (depth.Y < 0)
                    {
                        isOnGround = true;
                    }
                    else
                    {
                        velocity.Y = 0;
                    }
                    pos.Y = HitBox.Y + depth.Y;
                }
                //pos.Y = other.HitBox.Y - HitBox.Height + 1;
                //else if (other.CollisionType == 1)
                //{
                //    pos.X = HitBox.X + depth.X;
                //}
        }            
    }
}
