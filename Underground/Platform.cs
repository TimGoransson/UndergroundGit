﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Underground
{
    class Platform : GameObject
    {
        public Platform(Texture2D tex, Vector2 pos) : base(tex, pos)
        {

        }
        public override void Update(float elapsedTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, HitBox, Color.White);

        }
    }
}
