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
        // Du kan vara en player.
        //Din apa!
        bool alive;
        

        public Player(Vector2 pos) : base(TextureManager.texHero, pos)
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
            if (KeyMouseReader.KeyPressed(Keys.Right))
            {
                sfx = SpriteEffects.None;
                velocity.X = 3;
                //frameTimer -= elapsedTime;
            }
            else if (KeyMouseReader.KeyPressed(Keys.Left))
            {
                sfx = SpriteEffects.FlipHorizontally;
                velocity.X = -3;
                //frameTimer -= elapsedTime;
            }
            if (KeyMouseReader.KeyPressed(Keys.Up) && isOnGround)
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
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, HitBox, Color.White);
        }
    }
}
