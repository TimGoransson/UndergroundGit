using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
    }
}
