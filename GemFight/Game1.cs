﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GemFight.Framework;
using Microsoft.Xna.Framework;
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
        private static Game1 _instance = null;
        public GraphicsDeviceManager Graphics;
        SpriteBatch _spriteBatch;
        public List<Gem> ListOfGems = new List<Gem>();
        public InputController InputController1 = new InputController(PlayerIndex.One);
        public InputController InputController2 = new InputController(PlayerIndex.Two){Enabled = false};
        public ColissionHandler ColissionHandler;
        public List<Sprite> Sprites = new List<Sprite>();
        public List<Curser> ListofCursers = new List<Curser>();
        public List<Gem> GemsRemoveAble = new List<Gem>(); 
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
            Graphics.PreferredBackBufferWidth = screen.Bounds.Width;
            Graphics.PreferredBackBufferHeight = screen.Bounds.Height;
            Graphics.ApplyChanges();
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Player1 = new Monk(Content.Load<Texture2D>("Monk.png"),new Vector2(TheBoard.StartPointx-65,TheBoard.StartPointy-200), true);
            Player2 = new Wizard(Content.Load<Texture2D>("WizardAnimate.png"), new Vector2(TheBoard.StartPointx+600, TheBoard.StartPointy - 200), false);
            Player1.Enemy = Player2;
            Player2.Enemy = Player1;
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
            InputController1.InputGamePadButtonListeners.Add(Player1);
            InputController2.InputGamePadButtonListeners.Add(Player2);
            ColissionHandler = new ColissionHandler(Sprites);
            foreach (var curser in ListofCursers)
            {
                InputController1.InputGamePadDigitalDpadListeners.Add(curser);
                InputController1.InputGamePadButtonListeners.Add(curser);
                InputController2.InputGamePadDigitalDpadListeners.Add(curser);
                InputController2.InputGamePadButtonListeners.Add(curser);
                ColissionHandler.CollisionListenersList.Add(curser);
                Sprites.Add(curser);
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
            Handler.UpdateGems();
            Handler.UpdateMoveAble();
            Player2.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            foreach (var gem in ListOfGems)
            {
                gem.Draw(gameTime, _spriteBatch);
            }
            Player1.Draw(gameTime, _spriteBatch);
            Player2.Draw(gameTime,_spriteBatch);
            foreach (var curser in ListofCursers)
            {
                curser.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.DrawString(_font, Player1.Health.ToString(), new Vector2(100, 100), Color.DarkRed);
            _spriteBatch.DrawString(_font, Player1.BlueGems.ToString(), new Vector2(100, 200), Color.Blue);
            _spriteBatch.DrawString(_font, Player1.GreenGems.ToString(), new Vector2(100, 300), Color.Green);
            _spriteBatch.DrawString(_font, Player1.RedGems.ToString(), new Vector2(100, 400), Color.Red);
            _spriteBatch.DrawString(_font, Player1.YellowGems.ToString(), new Vector2(100, 500), Color.Yellow);
            _spriteBatch.DrawString(_font, Player1.Armor.ToString(), new Vector2(100, 600), Color.Gray);
            _spriteBatch.DrawString(_font, Player2.Health.ToString(), new Vector2(Graphics.PreferredBackBufferWidth - 300, 100), Color.DarkRed);
            _spriteBatch.DrawString(_font, Player2.BlueGems.ToString(), new Vector2(Graphics.PreferredBackBufferWidth - 300, 200), Color.Blue);
            _spriteBatch.DrawString(_font, Player2.GreenGems.ToString(), new Vector2(Graphics.PreferredBackBufferWidth - 300, 300), Color.Green);
            _spriteBatch.DrawString(_font, Player2.RedGems.ToString(), new Vector2(Graphics.PreferredBackBufferWidth - 300, 400), Color.Red);
            _spriteBatch.DrawString(_font, Player2.YellowGems.ToString(), new Vector2(Graphics.PreferredBackBufferWidth - 300, 500), Color.Yellow);
            _spriteBatch.DrawString(_font, Player2.Armor.ToString(), new Vector2(Graphics.PreferredBackBufferWidth - 300, 600), Color.Gray);
            _spriteBatch.DrawString(_font, ListOfGems.Count.ToString(), new Vector2((TheBoard.StartPointx+350), 400), Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
