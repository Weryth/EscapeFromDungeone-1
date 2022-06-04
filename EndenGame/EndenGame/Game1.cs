using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EndenGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D _characterJustTexture;
        private Texture2D _characterIdleTexture;
        private Texture2D _characterRunRight;
        private Texture2D _characterRunBack;

        private Texture2D _background;
        private Texture2D _roomGround;

        private Texture2D _GhoulJustTexture;
        private Texture2D _GhoulIdleTexture;
        private Texture2D _GhoulRunLeftTexture;
        private Texture2D _GhoulRunRightTexture;

        private InformationBankWithObj _mainBank = new InformationBankWithObj();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
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

            //Загрузка основных текстур
            _characterJustTexture = Content.Load<Texture2D>("Chara1");
            _characterIdleTexture = Content.Load<Texture2D>("NewCharacterStay");
            _characterRunRight = Content.Load<Texture2D>("NewCharacterRunRight");
            _characterRunBack = Content.Load<Texture2D>("NewCharacterRunBack");
            _roomGround = Content.Load<Texture2D>("RoomGround");
            _background = Content.Load<Texture2D>("Background");

            _GhoulJustTexture = Content.Load<Texture2D>("EnemyGhoulJust");
            _GhoulIdleTexture = Content.Load<Texture2D>("EnemyGhoulIdle");
            _GhoulRunLeftTexture = Content.Load<Texture2D>("EnemyGhoulRunLeft");
            _GhoulRunRightTexture = Content.Load<Texture2D>("EnemyGhoulRunRight");

            //Отгрузка в банк
            _mainBank.TakeGhoulRunRightTexture(_GhoulRunRightTexture);
            _mainBank.TakeJustText(_characterJustTexture);
            _mainBank.TakeIdleText(_characterIdleTexture);
            _mainBank.TakeBackground(_background);
            _mainBank.TakeRunRightText(_characterRunRight);
            _mainBank.TakeRunBackText(_characterRunBack);
            _mainBank.TakeAtackTexture(Content.Load<Texture2D>("NewCharacterAtack"));

            //отгрузка гуля
            _mainBank.TakeGhoulJustText(_GhoulJustTexture);
            _mainBank.TakeGhoulIdleText(_GhoulIdleTexture);
            _mainBank.TakeGhoulRunLeftTexture(_GhoulRunLeftTexture);
            _mainBank.TakeEnemyAtack(Content.Load<Texture2D>("EnemyGhoulAtack1"));

            _mainBank.TakeRoomGround(_roomGround);
            //Load банка
            _mainBank.LoadContent();

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

            // TODO: Add your update logic here

            _mainBank.Update(gameTime);

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

            _mainBank.Draw(spriteBatch);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
