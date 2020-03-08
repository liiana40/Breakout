using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Colision
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
      
        KeyboardState ks;
        List<Ball> Balls = new List<Ball>();
        List<Ball> BallsRemove = new List<Ball>();

        List<Brick> Bricks = new List<Brick>();
        List<Brick> BricksRemove = new List<Brick>();

        Paddle paddle = new Paddle();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Ball.Tex = Content.Load<Texture2D>("Ball");
            Brick.Tex = Content.Load<Texture2D>("Bricks");
            Paddle.Tex = Content.Load<Texture2D>("Bricks");
            //8 by 4
            for (int i = 0; i < 32; i++)
            {
                Bricks.Add(new Brick(i % 8 * 96 + 16, i / 8 * 32 + 64, 4 - (i / 8)));
            }
            Balls.Add(new Ball());
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //this.Exit();

            ks = Keyboard.GetState();
            foreach (var ball in Balls)
            {
                ball.Update(BallsRemove);
            }
            foreach (var ball in BallsRemove)
            {
                Balls.Remove(ball);
            }
            BallsRemove.Clear();
           
            foreach (var brick in Bricks)
            {
                brick.Update(Balls, BricksRemove);
            }
            foreach (var brick in BricksRemove)
            {
                Bricks.Remove(brick);
            }
            BricksRemove.Clear();
            paddle.Update(ks, Balls);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach (var ball in Balls)
            {
                ball.Draw(spriteBatch);
            }
            foreach (var brick in Bricks)
            {
                brick.Draw(spriteBatch);
            }
            paddle.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
