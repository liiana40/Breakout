using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Colision
{
    public class Brick
    {
        public static Texture2D Tex;
        public static Color[] Colors = {Color.AliceBlue, Color.Cornsilk, Color.DarkKhaki, Color.Firebrick, Color.FloralWhite, Color.IndianRed};

        public Rectangle CollisionRectangle = new Rectangle(0, 0, 96, 32);
        int HitCount;

        public Brick(int x, int y, int hitcount)
        {
            CollisionRectangle.X = x;
            CollisionRectangle.Y = y;
            HitCount = hitcount;
        }
        public void Update(List<Ball> Balls, List<Brick> BricksRemove)
        {
            foreach (var ball in Balls)
            {
                if (ball.CollisionRectangle.Intersects(CollisionRectangle))
                {
                    if(--HitCount ==-1)
                    {
                        BricksRemove.Add(this);
                    }
                    Rectangle tmp = Rectangle.Intersect(ball.CollisionRectangle, CollisionRectangle);
                    if (tmp.Width > tmp.Height)
                    {
                        ball.BounceV();
                    }
                    else
                        ball.BounceH();
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Tex, CollisionRectangle, Colors[HitCount]);
        }
    }
}
