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
    public class Paddle
    {
        public static Texture2D Tex;
        public Rectangle CollisionRectangle = new Rectangle(352, 446, 96, 32);

        int Speed = 6;

        public void Update(KeyboardState ks, List<Ball> Balls)
        {
            if (ks.IsKeyDown(Keys.Left)&&CollisionRectangle.X>Speed)
            {
                CollisionRectangle.X -= Speed;
            }
            if (ks.IsKeyDown(Keys.Right) && CollisionRectangle.Right + Speed<800)
            {
                CollisionRectangle.X += Speed;
            }
            foreach (var ball in Balls)
            {
                if (ball.CollisionRectangle.Intersects(CollisionRectangle))
                {
                    ball.BounceV();
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Tex, CollisionRectangle, Color.White);
        }
    }
}
