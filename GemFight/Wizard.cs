using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Wizard : Player, IInputGamePadButtons
    {
        public List<Curser> CurserList = new List<Curser>();
        private readonly Game1 _game = Game1.GetInstance();
        private readonly GameHandler _handler = GameHandler.GetInstance();
        private readonly Board _theBoard = Board.GetInstance();
        private int _selectCursorSetup = 1;
        private bool _extraTurn = false;
        public Wizard(Texture2D spriteTexture, Vector2 position, bool hasTurn)
            : base(spriteTexture, position, hasTurn)
        {

        }

        public override void CursorSetup1()
        {
            if (HasTurn)
            {
            _game.Cursor1.SetPosition(_theBoard.Pos[12]);
            _game.Cursor2.SetPosition(_theBoard.Pos[13]);
            _game.Cursor3.SetPosition(_theBoard.Pos[7]);
            _game.Cursor4.SetPosition(_theBoard.Pos[8]);
            _game.Cursor5.SetPosition(_theBoard.Pos[2]);
            _game.Cursor6.SetPosition(_theBoard.Pos[3]);
            _selectCursorSetup = 1;
            }
        }
        public override void CursorSetup2()
        {
            if (HasTurn)
            {
                _game.Cursor1.SetPosition(_theBoard.Pos[0]);
                _game.Cursor2.SetPosition(_theBoard.Pos[7]);
                _game.Cursor3.SetPosition(_theBoard.Pos[14]);
                _game.Cursor4.SetPosition(_theBoard.Pos[20]);
                _game.Cursor5.SetPosition(_theBoard.Pos[25]);
                _game.Cursor6.SetPosition(_theBoard.Pos[30]);
                _selectCursorSetup = 2;
            }
        }
        public override void CursorSetup3()
        {
            if (HasTurn)
            {
                _game.Cursor1.SetPosition(_theBoard.Pos[0]);
                _game.Cursor2.SetPosition(_theBoard.Pos[1]);
                _game.Cursor3.SetPosition(_theBoard.Pos[6]);
                _game.Cursor4.SetPosition(_theBoard.Pos[7]);
                _game.Cursor5.SetPosition(_theBoard.Pos[12]);
                _game.Cursor6.SetPosition(_theBoard.Pos[13]);
                _selectCursorSetup = 3;
            }
        }

        public override void ButtonADown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                if (_extraTurn)
                {
                    _extraTurn = false;
                }
                else
                {
                    _handler.SwitchPlayer(this);
                    _game.Player1.CursorSetup1();
                }
            } 
        }
        public override void ButtonXDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                Ability1();
            }
        }

        public override void ButtonBDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                Ability3();
            }
        }

        public override void ButtonYDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                Ability2();
            }
        }

        public override void ButtonLeftShoulderDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn)
            {
                if (buttonStates == InputController.ButtonStates.JustPressed)
                {
                    switch (_selectCursorSetup)
                    {
                        case 1:
                            CursorSetup3();
                            break;
                        case 2:
                            CursorSetup1();
                            break;
                        case 3:
                            CursorSetup2();
                            break;
                    }
                }
            }
        }

        public override void ButtonRightShoulderDown(InputController.ButtonStates buttonStates)
        {
            if (HasTurn)
            {
                if (buttonStates == InputController.ButtonStates.JustPressed)
                {
                    switch (_selectCursorSetup)
                    {
                        case 1:
                            CursorSetup2();
                            break;
                        case 2:
                            CursorSetup3();
                            break;
                        case 3:
                            CursorSetup1();
                            break;
                    }
                }
            }
        }

        public override void Ability1()
        {
            if (RedGems >= 3 && GreenGems >= 3)
            {
                RedGems = RedGems - 3;
                GreenGems = GreenGems - 3;
                _game.Player1.DoDmg(6,false);
            }
        }

        public override void Ability2()
        {
            if (YellowGems >= 20)
            {
                YellowGems = YellowGems - 20;
                _game.Player1.DoDmg(25,true);
            }
        }

        public override void Ability3()
        {
            if (BlueGems >= 10)
            {
                BlueGems = BlueGems - 10;
                _extraTurn = true;
            }
        }
    }
}
