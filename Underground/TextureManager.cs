using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace Underground
{
    static class TextureManager
    {
        public static Texture2D texHero, texPlatform;
        public static void LoadContent(ContentManager content)
        {
            texHero = content.Load<Texture2D>("png");
            texPlatform = content.Load<Texture2D>("wall");
            //WallTex = content.Load<Texture2D>("wall");
            //GhostTex = content.Load<Texture2D>("SpriteSheet");
            //FoodTex = content.Load<Texture2D>("centerDot");
        }
    }
}
