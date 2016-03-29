using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Underground
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<GameObject> gameObjects;
        List<Platform> platforms;
        Player pngMan;
        Texture2D texHero, texPlatform;
        Keys[] pressedKeys = new Keys[5];

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
            texHero = Content.Load<Texture2D>("red");
            texPlatform = Content.Load<Texture2D>("NewBlock");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pngMan = new Player(texHero, new Vector2(100,100));
            platforms = new List<Platform>();
            platforms.Add(new Platform(texPlatform, new Vector2(100, 200)));
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{

            //    Keyboard.GetState().GetPressedKeys();
            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                if (pngMan.IsColliding(platforms[i]))
                {
                    //if (pngMan.PixelCollision(pngMan,platforms[i]))
                    //{
                    //    pngMan.HandleCollisionPlatform(platforms[i]);

                    //}
                    pngMan.HandleCollisionPlatform(platforms[i]);
                }
                
            }

            //}
            pngMan.Update(elapsedTime);
            //for (int i = platforms.Count - 1; i >= 0; i--)
            //{
            //    platforms[i].Update(elapsedTime);
            //}
            // TODO: Add your update logic here

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

            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                platforms[i].Draw(spriteBatch);
            }
            pngMan.Draw(spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
