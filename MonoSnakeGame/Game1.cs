using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Design;

namespace MonoSnakeGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Song song;

        Texture2D genTex;

        GameWindow activeScreen;
        StartScreen startScreen;
        GameScreen gameScreen;
        EndScreen endScreen;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.song = Content.Load<Song>("SnakeMusic");
            MediaPlayer.Play(this.song);
            MediaPlayer.IsRepeating = true;

            genTex = new Texture2D(GraphicsDevice, 1, 1);
            genTex.SetData(new[] { Color.White });

            startScreen = new StartScreen(this, spriteBatch, genTex);
            Components.Add(startScreen);
            startScreen.Hide();

            gameScreen = new GameScreen(this, spriteBatch, genTex);
            Components.Add(gameScreen);
            gameScreen.Hide();

            endScreen = new EndScreen(this, spriteBatch, genTex);
            Components.Add(endScreen);
            endScreen.Hide();

            activeScreen = startScreen;
            activeScreen.Show();

            //SpriteFont initialization
          

            // Create a new SpriteBatch, which can be used to draw textures.
           


        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                activeScreen.Hide();
                activeScreen = gameScreen;
                activeScreen.Show();
            }

            if (gameScreen.isDead() == true)
            {
                activeScreen.Hide();
                activeScreen = endScreen;
                activeScreen.Show();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin Drawing
            spriteBatch.Begin();

            base.Draw(gameTime);

            spriteBatch.End();
            // TODO: Add your drawing code here

           
        }
    }
}
