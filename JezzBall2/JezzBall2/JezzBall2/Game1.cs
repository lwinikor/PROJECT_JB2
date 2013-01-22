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
using Animations;
using ScreenManager;
using JezzBall2.Screens;
using JezzBall2.Utility;
using JezzBall2.Enums;
using JezzBall2.Stages;

namespace JezzBall2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GameScreen activeScreen;
        TitleScreen titleScreen;
        MainMenuScreen mainMenuScreen;
        CreditScreen creditScreen;
        ActionScreen actionScreen;

        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        // Gamepad states used to determine button presses
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Change of resolution.
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
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

            this.titleScreen = new TitleScreen(this, this.spriteBatch, Content.Load<SpriteFont>("Fonts/TitleScreen"), Content.Load<SpriteFont>("Fonts/PressStart"), null, Color.Black);
            this.titleScreen.Hide();
            this.Components.Add(this.titleScreen);
            this.mainMenuScreen = new MainMenuScreen(this, this.spriteBatch, Content.Load<SpriteFont>("Fonts/MainMenu"), null, Color.Black);
            this.mainMenuScreen.Hide();
            this.Components.Add(this.mainMenuScreen);

            String[] credits = { "LEE", "JOSH", "NACHO" };
            this.creditScreen = new CreditScreen(this, this.spriteBatch, Content.Load<SpriteFont>("Fonts/TitleScreen"), credits, Color.White);
            this.creditScreen.Hide();
            this.Components.Add(this.creditScreen);

            Texture2D borderTexture = new Texture2D(GraphicsDevice, 1, 1);
            borderTexture.SetData(new[] { Color.White });

            Stage stage = new Stage(600, 1000, 1, borderTexture, new Vector2(140, 60));

            this.actionScreen = new ActionScreen(this, this.spriteBatch, stage);
            this.actionScreen.Hide();
            this.Components.Add(this.actionScreen);

            this.activeScreen = this.titleScreen;
            this.activeScreen.Show();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || this.currentKeyboardState.IsKeyDown(Keys.Escape))
                this.Exit();

            // Save the previous state of the keyboard and game pad so we can determinesingle key/button presses
            this.previousGamePadState = this.currentGamePadState;
            this.previousKeyboardState = this.currentKeyboardState;

            // Read the current state of the keyboard and gamepad and store it
            this.currentKeyboardState = Keyboard.GetState();
            this.currentGamePadState = GamePad.GetState(PlayerIndex.One);

            if (this.activeScreen == this.titleScreen)
            {
                if (!this.titleScreen.Enabled)
                {
                    this.SwapToScreen(this.mainMenuScreen);
                }
            }
            else if (this.activeScreen == this.mainMenuScreen)
            {
                if (KeyboardUtility.checkKey(Keys.Enter, this.currentKeyboardState, this.previousKeyboardState))
                {
                    if ((MainMenu) this.mainMenuScreen.SelectedIndex == MainMenu.EXIT)
                    {
                        this.Exit();
                    }
                    else if ((MainMenu)this.mainMenuScreen.SelectedIndex == MainMenu.CREDITS)
                    {
                        this.creditScreen.Enabled = true;
                        this.SwapToScreen(this.creditScreen);
                    }
                    else if ((MainMenu)this.mainMenuScreen.SelectedIndex == MainMenu.SURVIVAL)
                    {
                        this.actionScreen.Enabled = true;
                        this.SwapToScreen(this.actionScreen);
                    }
                }
                
            }
            else if (this.activeScreen == this.creditScreen)
            {
                if (!this.creditScreen.Enabled)
                {
                    this.SwapToScreen(this.mainMenuScreen);
                }
            }
            else if (this.activeScreen == this.actionScreen)
            {
                
            }

            base.Update(gameTime);
        }
        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            this.spriteBatch.Begin();

            base.Draw(gameTime);

            this.spriteBatch.End();
        }

        // Helper functions
        private void SwapToScreen(GameScreen newScreen)
        {
            this.activeScreen.Hide();
            this.activeScreen = newScreen;
            this.activeScreen.Show();
        }
    }
}
