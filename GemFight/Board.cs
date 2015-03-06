using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Board
    {
        public static Board Instance;
        private readonly List<Vector2> _squares = new List<Vector2>();
        /// <summary>
        /// Pos used to place cursers. Where the index goes up vertical.
        /// Pos[0] is 0,0. Pos[6] is 0,1.
        /// </summary>
        public List<Vector2> Pos = new List<Vector2>(); 
        private static readonly Game1 Game = Game1.GetInstance();
        public const int YDistance = 94;
        public const int XDistance = 97;
        public int StartPointx = (Game.Graphics.PreferredBackBufferWidth / 2) - (XDistance * 4);
        public int StartPointy = (Game.Graphics.PreferredBackBufferHeight) - (YDistance * 7) - 20;
        public int EndPointx = (Game.Graphics.PreferredBackBufferWidth / 2) + (XDistance * 2);
        public int EndPointy = (Game.Graphics.PreferredBackBufferHeight) - (YDistance + 1);

        private Board()
        {
            GenerateBoard();
        }

        public static Board GetInstance()
        {
            return Instance ?? (Instance = new Board());
        }

        public void GenerateBoard()
        {
            int yline = 1;
            int xline = 1;


            for (int i = 0; i < 36; i++)
            {
                ;
                _squares.Add(new Vector2(StartPointx + (XDistance * xline), StartPointy + (YDistance * yline)));
                Pos.Add(new Vector2(StartPointx - 2 + (XDistance * xline), StartPointy - 2 + (YDistance * yline)));
                if (yline == 6)
                {
                    yline = 1;
                    xline++;
                }
                else
                {
                    yline++;
                }
            }
            GenerateGems();
        }

        public void GenerateGems()
        {
            Game.ListOfGems.Clear();
            var rnd = new Random();
            foreach (var vector2 in _squares)
            {
                Game.ListOfGems.Add(new Gem(Game.Content.Load<Texture2D>("Gems.png"), vector2, rnd.Next(0,6)));
            }
        }
    }
}
