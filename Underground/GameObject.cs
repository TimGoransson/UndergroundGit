using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Underground
{
    abstract class GameObject
    {
        protected Texture2D tex;
        protected Vector2 pos;
        protected Rectangle sourceRect;
        protected Vector2 frameSize;

        public virtual Rectangle Hitbox()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public virtual Rectangle Source
        {
            get { return new Rectangle(0, 0, (int)frameSize.X, (int)frameSize.Y); }
        }
        public virtual Rectangle Dest
        {
            get { return new Rectangle((int)pos.X, (int)pos.Y, (int)frameSize.X, (int)frameSize.Y); }
        }
        public virtual Rectangle HitBox
        {
            get { return Dest; }
        }
        public GameObject(Texture2D tex, Vector2 pos)
        {
            this.tex = tex;
            this.pos = pos;
            this.sourceRect = Source;
        }

        public abstract void Update(float elapsedTime);

        public abstract void Draw(SpriteBatch spriteBatch);
        


        Color[] colorData;
        public void SetColorData()
        {
            colorData = new Color[tex.Width * tex.Height];
            tex.GetData(colorData);
        }
        public Color GetPixel(int col, int row)
        {
            int c = col - Dest.X + sourceRect.X;
            int r = row - Dest.Y + sourceRect.Y;
            return colorData[r * tex.Width + c];
        }
        public bool PixelCollision(GameObject G1, GameObject G2)
        {
            if (!G1.HitBox.Intersects(G2.HitBox))
            {
                return false;
            }
            float collLeft = MathHelper.Max(G1.Dest.X, G2.Dest.X);
            float collTop = MathHelper.Max(G1.Dest.Y, G2.Dest.Y);
            float collRight = MathHelper.Min(G1.Dest.Right, G2.Dest.Right);
            float collBottom = MathHelper.Min(G1.Dest.Bottom, G2.Dest.Bottom);

            for (int col = (int)collLeft; col < collRight; col++)
            {
                for (int row = (int)collTop; row < collBottom; row++)
                {
                    if (G1.GetPixel(col, row).A > 127 && G2.GetPixel(col, row).A > 127)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
      
    }
}
