#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace TheBugSmash
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        Random random = new Random(Guid.NewGuid().GetHashCode());
        SpriteBatch spriteBatch;
        private int level = 10;
        private bool gameOver;
        private Texture2D YeezyUp, YeezyDown, YeezyLeft, YeezyRight;
        private Texture2D background;
        private List<Bug> buglist = new List<Bug>();
 
        public Game1()
            : base()
        {
            for (int i = buglist.Count; i < level; i++)
            {
                buglist.Add(new Bug(800, 0, 0));
            }
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
            gameOver = false;
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
            YeezyUp = Content.Load<Texture2D>("TestBugUp");
            YeezyDown = Content.Load<Texture2D>("TestBugDown");
            YeezyLeft = Content.Load<Texture2D>("TestBugLeft");
            YeezyRight = Content.Load<Texture2D>("TestBugRight");
            background = Content.Load<Texture2D>("Grass_level");
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (Bug a in buglist)
            {
                gameOver=a.Move();
                if (gameOver) Exit();
            }

            //int timeSinceLastFrame = 0;
            //int millisecondsPerFrame = 100;

            //timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            //if (timeSinceLastFrame > millisecondsPerFrame)
            //{
            //    timeSinceLastFrame -= millisecondsPerFrame;
            //    // Increment Current Frame here (See link for implementation)
            //}

            

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
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.WhiteSmoke);
            spriteBatch.Draw(background,new Rectangle(0, 410, 118, 480), Color.BlueViolet);
            foreach (Bug b in buglist)
            {
                switch(b.Direction)
                {
                    case 0: spriteBatch.Draw(YeezyUp, new Rectangle(b.X, b.Y, 50, 50), Color.White); break;
                    case 1: spriteBatch.Draw(YeezyRight, new Rectangle(b.X, b.Y, 50, 50), Color.White); break;
                    case 2: spriteBatch.Draw(YeezyDown, new Rectangle(b.X, b.Y, 50, 50), Color.White); break;
                    case 3: spriteBatch.Draw(YeezyLeft, new Rectangle(b.X, b.Y, 50, 50), Color.White); break;
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
