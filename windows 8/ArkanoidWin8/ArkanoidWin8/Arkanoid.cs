using ArkanoidWin8.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using System;

namespace ArkanoidWin8
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Arkanoid : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public static int screenWidth;
        public static int screenHeight;

        const int PADDLE_OFFSET = 70;
        const float BALL_START_SPEED = 11f;
        const float KEYBOARD_PADDLE_SPEED = 10f;
        Player player1;
        Ball ball;
        public Arkanoid()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
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
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            player1 = new Player();
            ball = new Ball();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            player1.texture = Content.Load<Texture2D>("Paddle.png");

            player1.position = new Vector2((screenWidth / 2) - (player1.texture.Width / 2) , screenHeight - player1.texture.Height - PADDLE_OFFSET);
            ball.texture = Content.Load<Texture2D>("Ball");
            ball.Launch(BALL_START_SPEED, player1.position.X + (player1.texture.Width / 2), player1.position.Y - (player1.texture.Height / 2));
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
            // TODO: Add your update logic here
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
            ball.Move(ball.velocity);
            base.Update(gameTime);
            Vector2 player1Velocity = Input.GetKeyboardInputDirection(PlayerIndex.One) * KEYBOARD_PADDLE_SPEED;

            player1.Move(player1Velocity);

            
            if (GameObject.CheckPaddleBallCollision(player1, ball))
            {
                ball.velocity.Y = -Math.Abs(ball.velocity.Y);
            }
 
            if (ball.position.Y > screenHeight)
            {
                ball.Launch(BALL_START_SPEED, player1.position.X + (player1.texture.Width / 2), player1.position.Y - (player1.texture.Height / 2));
            }

            Vector2 player1TouchVelocity;
            Input.ProcessTouchInput(out player1TouchVelocity);
            player1.Move(player1TouchVelocity);
        }

        void checkPaddleBallCollision()
        {
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            player1.Draw(_spriteBatch);
            ball.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
