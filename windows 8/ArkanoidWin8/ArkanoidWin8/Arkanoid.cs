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
        const float BALL_START_SPEED = 15f;
        const float KEYBOARD_PADDLE_SPEED = 4f;
        const float BACKGROUND_BORDER = 10;
        Player player1;
        Ball ball;
        Blocks[] block;
        GameObject background;
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
            block = new Blocks[15];
            background = new GameObject();
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
            for (int i = 0; i<15 ; i++)
            {
                block[i] = new Blocks();
                block[i].texture = Content.Load<Texture2D>(i.ToString());
            }
            player1.texture = Content.Load<Texture2D>("Paddle");
            background.texture = Content.Load<Texture2D>("Background");
            player1.position = new Vector2((screenWidth / 2) - (player1.texture.Width / 2) , screenHeight - player1.texture.Height - PADDLE_OFFSET);
            ball.texture = Content.Load<Texture2D>("kamuoliukas");
            ball.Launch(BALL_START_SPEED, player1.position.X + (player1.texture.Width / 2), player1.position.Y - (player1.texture.Height / 2));
            // TODO: use this.Content to load your game content here
            GenerateLevel(3, 5, block, BACKGROUND_BORDER);
        }

        private  void GenerateLevel(int row, int collumn, Blocks[] blocker, float spacing)
        {
            blocker[0].position = new Vector2(BACKGROUND_BORDER, BACKGROUND_BORDER);
            for (int i = 1; i < 5; i++)
                blocker[i].position = new Vector2(blocker[i - 1].position.X + blocker[i - 1].texture.Width + spacing, BACKGROUND_BORDER);
            blocker[5].position = new Vector2(BACKGROUND_BORDER, blocker[0].position.Y + blocker[0].texture.Height + spacing);
            for (int i = 6; i < 10; i++)
                blocker[i].position = new Vector2(blocker[i - 1].position.X + blocker[i - 1].texture.Width + spacing, blocker[0].position.Y + blocker[0].texture.Height + spacing);
            blocker[10].position = new Vector2(BACKGROUND_BORDER, blocker[5].position.Y + blocker[5].texture.Height + spacing);
            for (int i = 11; i < 15; i++)
                blocker[i].position = new Vector2(blocker[i - 1].position.X + blocker[i - 1].texture.Width + spacing, blocker[5].position.Y + blocker[5].texture.Height + spacing);
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
            ball.Move(ball.velocity, BACKGROUND_BORDER);
            base.Update(gameTime);
            Vector2 player1Velocity = Input.GetKeyboardInputDirection(PlayerIndex.One) * KEYBOARD_PADDLE_SPEED;

            player1.Move(player1Velocity);

            
            if (GameObject.CheckPaddleBallCollision(player1, ball)) //colision tikrinimas
            {
                ball.velocity.Y = -Math.Abs(ball.velocity.Y);
            }
            for (int i = 0; i < 15; i++)
            {
                if (GameObject.CheckPaddleBallCollision(block[i], ball))
                {
                    block[i].position = new Vector2(-150, -150);
                    ball.velocity.Y = Math.Abs(ball.velocity.Y);
                }
            }

 
            if (ball.position.Y > screenHeight)
            {
                ball.Launch(BALL_START_SPEED, player1.position.X + (player1.texture.Width / 2), player1.position.Y - (player1.texture.Height / 2));
                GenerateLevel(3, 5, block, BACKGROUND_BORDER);

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
            background.Draw(_spriteBatch);
            player1.Draw(_spriteBatch);
            ball.Draw(_spriteBatch);
            for (int i = 0; i < 15; i++)
            {
                block[i].Draw(_spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
