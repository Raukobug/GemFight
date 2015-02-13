#region Using Statements
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
        private static Game1 Instance = null;
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        public List<Gem> ListOfGems = new List<Gem>();
        public InputController _inputController1 = new InputController(PlayerIndex.One);
        public ColissionHandler _colissionHandler;
        public List<Sprite> _sprites = new List<Sprite>();
        public List<curser> listofCursers = new List<curser>();
        public Board TheBoard;
        private Monk monk;
        public curser Cursor1;
        public curser Cursor2;
        public curser Cursor3;
        public curser Cursor4;
        public curser Cursor5;
        public curser Cursor6;

        private Game1()
            : base()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static Game1 GetInstance()
        {
            return Instance ?? (Instance = new Game1());
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
            _graphics.PreferredBackBufferWidth = screen.Bounds.Width;
            _graphics.PreferredBackBufferHeight = screen.Bounds.Height;
            _graphics.ApplyChanges();
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
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            monk = new Monk(Content.Load<Texture2D>("monk.png"),new Vector2(800,0));
            Cursor1 = new curser(Content.Load<Texture2D>("Marker.png"), TheBoard.Pos[0]);
            Cursor2 = new curser(Content.Load<Texture2D>("Marker.png"), TheBoard.Pos[7]);
            Cursor3 = new curser(Content.Load<Texture2D>("Marker.png"), TheBoard.Pos[12]);
            Cursor4 = new curser(Content.Load<Texture2D>("Marker.png"), TheBoard.Pos[14]);
            Cursor5 = new curser(Content.Load<Texture2D>("Marker.png"), TheBoard.Pos[19]);
            Cursor6 = new curser(Content.Load<Texture2D>("Marker.png"), TheBoard.Pos[26]);
            listofCursers.Add(Cursor1);
            listofCursers.Add(Cursor2);
            listofCursers.Add(Cursor3);
            listofCursers.Add(Cursor4);
            listofCursers.Add(Cursor5);
            listofCursers.Add(Cursor6);
            _inputController1.InputGamePadButtonListeners.Add(monk);
            _colissionHandler = new ColissionHandler(_sprites);
            foreach (var curser in listofCursers)
            {
                _inputController1.InputGamePadDigitalDpadListeners.Add(curser);
                _inputController1.InputGamePadButtonListeners.Add(curser);
                _colissionHandler.CollisionListenersList.Add(curser);
                _sprites.Add(curser);   
            }



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
            // TODO: Add your update logic here
            foreach (var gem in ListOfGems)
            {
                foreach (var curser in listofCursers)
                {
                    curser.CollideWith(gem);   
                }
            }
            _inputController1.Update(gameTime);
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
            foreach (var curser in listofCursers)
            {
                curser.Draw(gameTime,_spriteBatch);
            }
            foreach (var gem in ListOfGems)
            {
                gem.Draw(gameTime,_spriteBatch);
            }
            monk.Draw(gameTime,_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
