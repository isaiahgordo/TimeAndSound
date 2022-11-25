using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TimeAndSound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bombtext;
        Rectangle bombrect;
        SpriteFont font;
        float seconds,startTime,mouseClick;
        MouseState mouseState;
        SoundEffect explode;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bombrect=new Rectangle(50,50,700,400);
            startTime = 0;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bombtext = Content.Load<Texture2D>("bomb");
            font = Content.Load<SpriteFont>("font");
            explode = Content.Load<SoundEffect>("explosion");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds-startTime;
            // TODO: Add your update logic here
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;


            }
            if (seconds > 10)
            { 
                explode.Play();
                seconds = 0;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombtext,bombrect,Color.White);
            _spriteBatch.DrawString(font, seconds.ToString("0:00"), new Vector2(270,200), Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}