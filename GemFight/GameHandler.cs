using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GemFight
{
    public class GameHandler
    {
        private bool _playerTurn = true;
        private Game1 _game = Game1.GetInstance();

        public bool PlayerTurn
        {
            get { return _playerTurn; }
        }

        private static GameHandler _instance = null;
        private GameHandler()
        {
        }

        public static GameHandler GetInstance()
        {
            return _instance ?? (_instance = new GameHandler());
        }

        public void SwitchPlayer()
        {
            if (_playerTurn)
            {
                _playerTurn = false;
                _game.InputController1.Enabled = false;
                _game.InputController2.Enabled = true;
            }
            else
            {
                _playerTurn = true;
                _game.InputController1.Enabled = true;
                _game.InputController2.Enabled = false;
            }
        }

        public void UpdateGems()
        {
            foreach (var gem in _game.GemsRemoveAble)
            {
                _game.ListOfGems.Remove(gem);
            }
            if (_game.GemsRemoveAble.Count != 0)
            {
                _game.GemsRemoveAble.Clear();
            }
            if (_game.ListOfGems.Count <= 12)
            {
                _game.TheBoard.GenerateGems();
            }
        }

        public void AssignGem(Gem gem)
        {
            if (PlayerTurn)
            {
                switch (gem.GemColor)
                {
                        case GemColor.Blue:
                        Console.WriteLine("test");
                        break;
                }
            }
        }
    }
}
