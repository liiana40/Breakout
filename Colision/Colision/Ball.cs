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
    public class Ball
    {
        public static Texture2D Tex;
        static int Count;
        public Rectangle CollisionRectangle = new Rectangle(0, 0, 12, 12);
        Vector2 Position;
        Vector2 Velocity = new Vector2();
        float Speed = 6;

        static Random rnd = new Random();

        public Ball()
        {
            Count++;
            Reset();
        }
        public Ball(float x, float y)
        {
            Count++;
            Position.X = x;
            Position.Y = y;
        }
        public void Reset()
        {
            Position.X = 394;//400-6
            Position.Y = 234;
            do
            {
                Velocity.X = rnd.Next(-100, 100);
                Velocity.X *= .045f;
            } while (Math.Abs(Velocity.X) < 2);
            
                Velocity.Y = rnd.Next(-100, -25);
                Velocity.Y *= .045f;

                Velocity.Normalize();
                Velocity *= Speed;
           
        }
        public void Update(List<Ball>BallsRemove)
        {
            Position += Velocity;
            if (Position.X < 0 || Position.X > 794)
            {
                Velocity.X *= -1;
            }
            if (Position.Y < 0)
            {
                Velocity.Y *= -1;
            }
            if (Position.Y >480)
            {
                if (Count > 1)
                {
                    Count--;
                    BallsRemove.Add(this);
                }
                else
                {
                    //Lives--
                    Reset();
                }

            }
            CollisionRectangle.X = (int)Position.X;
            CollisionRectangle.Y = (int)Position.Y;
        
    }

        public void BounceH()
        {
            Velocity.X *= -1;
        }
        public void BounceV(float angle = .5f)
        {
            Velocity.Y *= -1;
            Velocity.X += (.5f - angle);

            Velocity.Normalize();
            Velocity *= Speed;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Tex, CollisionRectangle, Color.White);
        }
    }
}
