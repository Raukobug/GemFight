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
        private readonly Game1 _game = Game1.GetInstance();

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
            const int yDistance = 94;
            const int xDistance = 96;
            for (int i = 0; i < 36; i++)
            {
                _squares.Add(new Vector2(4 + (xDistance * xline), 4 + (yDistance * yline)));
                Pos.Add(new Vector2(3 + (xDistance * xline), 3 + (yDistance * yline)));
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
            _game.ListOfGems.Clear();
            var rnd = new Random();
            foreach (var vector2 in _squares)
            {
                switch (rnd.Next(0, 6))
                {
                    case 0:
                        _game.ListOfGems.Add(new Gem(_game.Content.Load<Texture2D>("blackGem.png"), vector2));
                        break;
                    case 1:
                        _game.ListOfGems.Add(new Gem(_game.Content.Load<Texture2D>("grayGem.png"), vector2));
                        break;
                    case 2:
                        _game.ListOfGems.Add(new Gem(_game.Content.Load<Texture2D>("blueGem.png"), vector2));
                        break;
                    case 3:
                        _game.ListOfGems.Add(new Gem(_game.Content.Load<Texture2D>("greenGem.png"), vector2));
                        break;
                    case 4:
                        _game.ListOfGems.Add(new Gem(_game.Content.Load<Texture2D>("redGem.png"), vector2));
                        break;
                    case 5:
                        _game.ListOfGems.Add(new Gem(_game.Content.Load<Texture2D>("yellowGem.png"), vector2));
                        break;
                    case 6:
                        _game.ListOfGems.Add(new Gem(_game.Content.Load<Texture2D>("yellowGem.png"), vector2));
                        break;
                }
            }
        }
    }
}
