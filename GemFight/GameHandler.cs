using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GemFight
{
    public class GameHandler
    {
        //private bool _playerTurn = true;
        private Game1 _game = Game1.GetInstance();

        //public bool PlayerTurn
        //{
        //    get { return _playerTurn; }
        //}

        private static GameHandler _instance = null;
        private GameHandler()
        {
        }

        public static GameHandler GetInstance()
        {
            return _instance ?? (_instance = new GameHandler());
        }

        public void SwitchPlayer(Player player)
        {
            if (player is Monk)
            {
                _game.Player2.HasTurn = true;
                player.HasTurn = false;
                _game.InputController1.Enabled = false;
                _game.InputController2.Enabled = true; 
            }
            else
            {
                _game.Player1.HasTurn = true;
                player.HasTurn = false;
                _game.InputController1.Enabled = true;
                _game.InputController2.Enabled = false; 
            }
        }

        public void UpdateGems()
        {
            foreach (var gem in _game.GemsRemoveAble)
            {
                AssignGem(gem);
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
            Player player = _game.Player1.HasTurn ? _game.Player2 : _game.Player1;
            switch (gem.GemColor)
                {
                    case GemColor.Blue:
                        player.BlueGems++;
                        break;
                    case GemColor.Green:
                        player.GreenGems++;
                        break;
                    case GemColor.Red:
                        player.RedGems++;
                        break;
                    case GemColor.Yellow:
                        player.YellowGems++;
                        break;
                    case GemColor.Gray:
                        player.Armor = player.Armor++;
                        break;
                    case GemColor.Black:
                        if (player == _game.Player1)
                        {
                            _game.Player2.DoDmg(1,false);
                        }
                        else
                        {
                            _game.Player1.DoDmg(1,false);   
                        }
                        break;
                }
        }
    }
}
