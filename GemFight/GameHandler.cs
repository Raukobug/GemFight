﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class GameHandler
    {
        private Game1 _game = Game1.GetInstance();
        private Board _board = Board.GetInstance();
        private bool _ableToMoveUp;
        private bool _ableToMoveDown;
        private bool _ableToMoveLeft;
        private bool _ableToMoveRight;
        private bool ExtraTurnActiv = false;
        private int TimeToSwitch = 0;
        private bool Switch = false;

        public bool ExtraTurn
        {
            get { return ExtraTurnActiv; }
            set { ExtraTurnActiv = true; }
        }
        public bool AbleToMoveUp
        {
            get { return _ableToMoveUp; }
        }
        public bool AbleToMoveDown
        {
            get { return _ableToMoveDown; }
        }
        public bool AbleToMoveLeft
        {
            get { return _ableToMoveLeft; }
        }
        public bool AbleToMoveRight
        {
            get { return _ableToMoveRight; }
        }

        private static GameHandler _instance = null;
        private GameHandler()
        {
        }

        public static GameHandler GetInstance()
        {
            return _instance ?? (_instance = new GameHandler());
        }

        public void Updater(GameTime gameTime)
        {
            if (Switch)
            {
                if (TimeToSwitch == 0)
                {
                    if (_game.Player1.HasTurn)
                    {
                        _game.InputController1.Enabled = true;
                    }
                    else
                    {
                        _game.InputController2.Enabled = true;
                    }
                    Switch = false;
                }
                TimeToSwitch--;
            }
        }

        public void SwitchPlayer(Player player)
        {
            if (player.PlayerNumber == 1)
            {
                _game.Player2.HasTurn = true;
                player.HasTurn = false;
                _game.InputController1.Enabled = false;
                _game.InputController2.Enabled = false;
                player.Enemy.CursorSetup1();
            }
            else
            {
                _game.Player1.HasTurn = true;
                player.HasTurn = false;
                _game.InputController1.Enabled = false;
                _game.InputController2.Enabled = false;
                player.Enemy.CursorSetup1();
            }
            TimeToSwitch = 30;
            Switch = true;
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

        public void UpdateAbilitys()
        {
            foreach (var ability in _game.AbilitiesRemoveAble)
            {
                _game.ListofAbilities.Remove(ability);
            }
            if (_game.AbilitiesRemoveAble.Count != 0)
            {
                _game.AbilitiesRemoveAble.Clear();
            }
        }

        public void AssignGem(Gem gem)
        {
            Player player;
            if (!ExtraTurnActiv)
            {
                player = _game.Player1.HasTurn ? _game.Player2 : _game.Player1;
            }
            else
            {
                player = _game.Player1.HasTurn ? _game.Player1 : _game.Player2;
            }

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
                    player.Armor++;
                    break;
                case GemColor.Black:
                    if (player == _game.Player1)
                    {
                        _game.Player2.DoDmg(1, false);
                    }
                    else
                    {
                        _game.Player1.DoDmg(1, false);
                    }
                    break;
            }
        }

        public void UpdateMoveAble()
        {
            _ableToMoveUp = !_game.ListofCursers.Any(c => c.PositionY < _board.StartPointy + 93);

            _ableToMoveDown = !_game.ListofCursers.Any(c => c.PositionY > _board.EndPointy - 93);

            _ableToMoveLeft = !_game.ListofCursers.Any(c => c.PositionX < _board.StartPointx + 97);

            _ableToMoveRight = !_game.ListofCursers.Any(c => c.PositionX > _board.EndPointx - 97);
        }
        public void ResetGame()
        {
            _game.Player1.Reset();
            _game.Player2.Reset();
            _board.GenerateGems();
        }
    }
}
