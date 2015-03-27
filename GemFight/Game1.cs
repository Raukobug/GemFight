#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

#endregion

namespace GemFight
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public enum GameState { Intro, Game, Win };

        public Camera Camera;
        private StartScreen _startScreen;
        public GameState gameState;
        private static Game1 _instance = null;
        public GraphicsDeviceManager Graphics;
        SpriteBatch _spriteBatch;
        public List<Gem> ListOfGems = new List<Gem>();
        public InputController InputController1 = new InputController(PlayerIndex.One);
        public InputController InputController2 = new InputController(PlayerIndex.Two) { Enabled = false };
        public List<Curser> ListofCursers = new List<Curser>();
        public List<Gem> GemsRemoveAble = new List<Gem>();
        public List<Ability> ListofAbilities = new List<Ability>();
        public List<Ability> AbilitiesRemoveAble = new List<Ability>();
        public Board TheBoard;
        public GameHandler Handler;
        public Player Player1;
        public Player Player2;
        public Curser Cursor1;
        public Curser Cursor2;
        public Curser Cursor3;
        public Curser Cursor4;
        public Curser Cursor5;
        public Curser Cursor6;
        private SpriteFont _font;
        private Sprite _background;
        private Sprite _backgroundEarth;
        private Sprite centerBoard;
        private Sprite leftBoard;
        private Sprite rightBoard;
        private Sprite Player1Ability1;
        private Sprite Player1Ability2;
        private Sprite Player1Ability3;
        private Sprite Player2Ability1;
        private Sprite Player2Ability2;
        private Sprite Player2Ability3;
        private Sprite Player1SiteTop;
        private Sprite Player2SiteTop;
        public SoundEffect Sound;
        public string Winner;
        public List<Sprite> BoardPices = new List<Sprite>();

        private Game1()
            : base()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static Game1 GetInstance()
        {
            return _instance ?? (_instance = new Game1());
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
            var screen = Screen.AllScreens.First(e => e.Primary);
            Window.IsBorderless = true;
            Window.Position = new Point(screen.Bounds.X, screen.Bounds.Y);
            Graphics.PreferredBackBufferWidth = 1920;
            Graphics.PreferredBackBufferHeight = 1080;
            //Graphics.PreferredBackBufferWidth = screen.Bounds.Width;
            //Graphics.PreferredBackBufferHeight = screen.Bounds.Height;
            Graphics.ApplyChanges();

            gameState = GameState.Intro;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            TheBoard = Board.GetInstance();
            Handler = GameHandler.GetInstance();
            Camera = new Camera(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Player1 = new Monk(Content.Load<Texture2D>("MonkAnimate.png"), new Vector2(TheBoard.StartPointx - 65, TheBoard.StartPointy - 240), true, 1);
            Player2 = new Wizard(Content.Load<Texture2D>("WizardAnimate.png"), new Vector2(TheBoard.StartPointx + 600, TheBoard.StartPointy - 220), false, 2);
            Player1.Enemy = Player2;
            Player2.Enemy = Player1;
            Camera.Add(Player1);
            Camera.Add(Player2);
            _background = new Sprite(Content.Load<Texture2D>("background.png"), new Vector2((Camera.CenterX()) - 1250, 0));
            _backgroundEarth = new Sprite(Content.Load<Texture2D>("backgroundEarth.png"), new Vector2((Camera.CenterX()) - 1250, 26));
            Camera.Add(_backgroundEarth);
            BoardPices.Add(centerBoard = new Sprite(Content.Load<Texture2D>("centerBoard.png"), new Vector2(TheBoard.StartPointx + 67, TheBoard.StartPointy + 65)));
            BoardPices.Add(rightBoard = new Sprite(Content.Load<Texture2D>("Sitebar.png"), new Vector2(TheBoard.StartPointx - 435, TheBoard.StartPointy + 65)));
            BoardPices.Add(leftBoard = new Sprite(Content.Load<Texture2D>("Sitebar.png"), new Vector2(TheBoard.StartPointx + 729, TheBoard.StartPointy + 65)));
            _startScreen = new StartScreen(Content.Load<Texture2D>("Startscreen.png"), new Vector2(Camera.Left(), Camera.Top()));
            BoardPices.Add(Player1SiteTop = new Sprite(Content.Load<Texture2D>("topSiteBar.png"), new Vector2(TheBoard.StartPointx - 424, TheBoard.StartPointy + 80)));
            BoardPices.Add(Player1Ability1 = new Sprite(Content.Load<Texture2D>("MonkAbility1.png"), new Vector2(TheBoard.StartPointx - 424, TheBoard.StartPointy + 226)));
            BoardPices.Add(Player1Ability2 = new Sprite(Content.Load<Texture2D>("MonkAbility2.png"), new Vector2(TheBoard.StartPointx - 424, TheBoard.StartPointy + 372)));
            BoardPices.Add(Player1Ability3 = new Sprite(Content.Load<Texture2D>("MonkAbility3.png"), new Vector2(TheBoard.StartPointx - 424, TheBoard.StartPointy + 518)));
            BoardPices.Add(Player2SiteTop = new Sprite(Content.Load<Texture2D>("topSiteBar.png"), new Vector2(TheBoard.EndPointx + 158, TheBoard.StartPointy + 80)));
            BoardPices.Add(Player2Ability1 = new Sprite(Content.Load<Texture2D>("WizardAbility1.png"), new Vector2(TheBoard.EndPointx + 158, TheBoard.StartPointy + 224)));
            BoardPices.Add(Player2Ability2 = new Sprite(Content.Load<Texture2D>("WizardAbility2.png"), new Vector2(TheBoard.EndPointx + 158, TheBoard.StartPointy + 368)));
            BoardPices.Add(Player2Ability3 = new Sprite(Content.Load<Texture2D>("WizardAbility3.png"), new Vector2(TheBoard.EndPointx + 158, TheBoard.StartPointy + 512)));
            Cursor1 = new Curser(Content.Load<Texture2D>("MarkerAnimate.png"), TheBoard.Pos[0]);
            Cursor2 = new Curser(Content.Load<Texture2D>("MarkerAnimate.png"), TheBoard.Pos[7]);
            Cursor3 = new Curser(Content.Load<Texture2D>("MarkerAnimate.png"), TheBoard.Pos[12]);
            Cursor4 = new Curser(Content.Load<Texture2D>("MarkerAnimate.png"), TheBoard.Pos[14]);
            Cursor5 = new Curser(Content.Load<Texture2D>("MarkerAnimate.png"), TheBoard.Pos[19]);
            Cursor6 = new Curser(Content.Load<Texture2D>("MarkerAnimate.png"), TheBoard.Pos[26]);
            ListofCursers.Add(Cursor1);
            ListofCursers.Add(Cursor2);
            ListofCursers.Add(Cursor3);
            ListofCursers.Add(Cursor4);
            ListofCursers.Add(Cursor5);
            ListofCursers.Add(Cursor6);
            foreach (var curser in ListofCursers)
            {
                Camera.Add(curser);
            }
            foreach (var boardPice in BoardPices)
            {
                Camera.Add(boardPice);
            }
            InputController1.InputGamePadButtonListeners.Add(Player1);
            InputController2.InputGamePadButtonListeners.Add(Player2);
            foreach (var curser in ListofCursers)
            {
                InputController1.InputGamePadDigitalDpadListeners.Add(curser);
                InputController1.InputGamePadButtonListeners.Add(curser);
                InputController2.InputGamePadDigitalDpadListeners.Add(curser);
                InputController2.InputGamePadButtonListeners.Add(curser);
            }
            _font = Content.Load<SpriteFont>("SegoeUI_48");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || GamePad.GetState(PlayerIndex.Two).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            //if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            //{
            //    foreach (var gem in ListOfGems)
            //    {
            //        gem.Destroy();
            //    }
            //    Camera.ShakeY = true;
            //    Camera.ShakeX = true;
            //}
            switch (gameState)
            {
                case GameState.Intro:
                    if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || GamePad.GetState(PlayerIndex.Two).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
                    {
                        gameState = GameState.Game;
                    }
                    break;

                case GameState.Game:
                    foreach (var gem in ListOfGems)
                    {
                        foreach (var curser in ListofCursers)
                        {
                            curser.CollideWith(gem);
                        }
                        gem.Update(gameTime);
                    }
                    InputController1.Update(gameTime);
                    InputController2.Update(gameTime);
                    foreach (var curser in ListofCursers)
                    {
                        curser.Update(gameTime);
                    }
                    foreach (var ability in ListofAbilities)
                    {
                        ability.Update(gameTime);
                    }
                    Handler.UpdateGems();
                    foreach (var gem in ListOfGems)
                    {
                        Camera.Add(gem);
                    }
                    Handler.UpdateAbilitys();
                    Handler.UpdateMoveAble();
                    Player1.Update(gameTime);
                    Player2.Update(gameTime);
                    Camera.Shake(gameTime);
                    Handler.Updater(gameTime);
                    break;

                case GameState.Win:
                    if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || GamePad.GetState(PlayerIndex.Two).Buttons.A == ButtonState.Pressed)
                    {
                        gameState = GameState.Intro;
                        Handler.ResetGame();
                    }
                    break;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _background.Draw(gameTime, _spriteBatch);
            _backgroundEarth.Draw(gameTime, _spriteBatch);
            switch (gameState)
            {
                case GameState.Intro:
                    _startScreen.Draw(gameTime, _spriteBatch);
                    break;
                case GameState.Game:
                    foreach (var pice in BoardPices)
                    {
                        pice.Draw(gameTime, _spriteBatch);
                    }
                    foreach (var gem in ListOfGems)
                    {
                        gem.Draw(gameTime, _spriteBatch);
                    }
                    Player1.Draw(gameTime, _spriteBatch);
                    Player2.Draw(gameTime, _spriteBatch);
                    foreach (var curser in ListofCursers)
                    {
                        curser.Draw(gameTime, _spriteBatch);
                    }
                    foreach (var ability in ListofAbilities)
                    {
                        ability.Draw(gameTime, _spriteBatch);
                    }
                    _spriteBatch.DrawString(_font, Player1.Health.ToString(), new Vector2(TheBoard.StartPointx - 410, TheBoard.StartPointy + 70), Color.DarkRed);
                    _spriteBatch.DrawString(_font, Player1.BlueGems.ToString(), new Vector2(TheBoard.StartPointx - 330, TheBoard.StartPointy + 130), Color.Blue);
                    _spriteBatch.DrawString(_font, Player1.GreenGems.ToString(), new Vector2(TheBoard.StartPointx - 250, TheBoard.StartPointy + 130), Color.Green);
                    _spriteBatch.DrawString(_font, Player1.RedGems.ToString(), new Vector2(TheBoard.StartPointx - 180, TheBoard.StartPointy + 130), Color.Red);
                    _spriteBatch.DrawString(_font, Player1.YellowGems.ToString(), new Vector2(TheBoard.StartPointx - 100, TheBoard.StartPointy + 130), Color.Yellow);
                    _spriteBatch.DrawString(_font, Player1.Armor.ToString(), new Vector2(TheBoard.StartPointx - 410, TheBoard.StartPointy + 130), Color.Gray);
                    _spriteBatch.DrawString(_font, Player2.Health.ToString(), new Vector2(TheBoard.EndPointx + 165, TheBoard.StartPointy + 70), Color.DarkRed);
                    _spriteBatch.DrawString(_font, Player2.BlueGems.ToString(), new Vector2(TheBoard.EndPointx + 254, TheBoard.StartPointy + 130), Color.Blue);
                    _spriteBatch.DrawString(_font, Player2.GreenGems.ToString(), new Vector2(TheBoard.EndPointx + 325, TheBoard.StartPointy + 130), Color.Green);
                    _spriteBatch.DrawString(_font, Player2.RedGems.ToString(), new Vector2(TheBoard.EndPointx + 405, TheBoard.StartPointy + 130), Color.Red);
                    _spriteBatch.DrawString(_font, Player2.YellowGems.ToString(), new Vector2(TheBoard.EndPointx + 485, TheBoard.StartPointy + 130), Color.Yellow);
                    _spriteBatch.DrawString(_font, Player2.Armor.ToString(), new Vector2(TheBoard.EndPointx + 165, TheBoard.StartPointy + 130), Color.Gray);
                    _spriteBatch.DrawString(_font, ListOfGems.Count.ToString(), new Vector2((TheBoard.StartPointx + 350), TheBoard.StartPointy), Color.Black);
                    break;
                case GameState.Win:
                    _spriteBatch.DrawString(_font, "Winner is " + Winner, new Vector2((TheBoard.StartPointx + 350), TheBoard.StartPointy - 200), Color.Black);
                    _spriteBatch.DrawString(_font, "Press A to continue", new Vector2((TheBoard.StartPointx + 350), TheBoard.StartPointy - 120), Color.Black);
                    break;
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
