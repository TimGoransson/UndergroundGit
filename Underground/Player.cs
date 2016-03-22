using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Underground
{
    class Player : MovableGameObjects
    {
        
        bool alive;
        KeyboardState ks;        


        public Player(Texture2D tex, Vector2 pos) : base(tex, pos)
        {
            this.frameSize = new Vector2(64, 64);

        }
        public override void HandleCollisionPlatform(Platform p)
        {
            isOnGround = false;
            base.HandleCollisionPlatform(p);
        }
        public override void Update(float elapsedTime)
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                sfx = SpriteEffects.None;
                velocity.X = 3;
                //frameTimer -= elapsedTime;
            }
            else if (ks.IsKeyDown(Keys.Left))
            {
                sfx = SpriteEffects.FlipHorizontally;
                velocity.X = -3;
                //frameTimer -= elapsedTime;
            }
            if (ks.IsKeyDown(Keys.Up) && isOnGround)
            {
                velocity.Y = -6;
                isOnGround = false;
            }
            if (!isOnGround)
            {
                velocity.Y += Utilities.gravity * elapsedTime;
            }
            else
            {
                velocity.Y = 0;
            }
            pos += velocity;
            velocity.X = 0;
            isOnGround = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, HitBox, Color.White);
        }
    }
}
