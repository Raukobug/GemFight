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
    public class Monk : Sprite, IInputGamePadButtons
    {
        public List<Curser> CurserList = new List<Curser>();
        private readonly Game1 _game = Game1.GetInstance();
        private readonly GameHandler _handler = GameHandler.GetInstance();
        private readonly Board _theBoard = Board.GetInstance();
        private int _selectCursorSetup = 1;
        public Monk(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
            
        }

        public void CursorSetup1()
        {
            if (_handler.PlayerTurn)
            { 
            _game.Cursor1.SetPosition(_theBoard.Pos[0]);
            _game.Cursor2.SetPosition(_theBoard.Pos[7]);
            _game.Cursor3.SetPosition(_theBoard.Pos[12]);
            _game.Cursor4.SetPosition(_theBoard.Pos[14]);
            _game.Cursor5.SetPosition(_theBoard.Pos[19]);
            _game.Cursor6.SetPosition(_theBoard.Pos[26]);
            _selectCursorSetup = 1;
            }
        }
        public void CursorSetup2()
        {
            if (_handler.PlayerTurn)
            {
                _game.Cursor1.SetPosition(_theBoard.Pos[0]);
                _game.Cursor2.SetPosition(_theBoard.Pos[6]);
                _game.Cursor3.SetPosition(_theBoard.Pos[12]);
                _game.Cursor4.SetPosition(_theBoard.Pos[18]);
                _game.Cursor5.SetPosition(_theBoard.Pos[24]);
                _game.Cursor6.SetPosition(_theBoard.Pos[30]);
                _selectCursorSetup = 2;
            }
        }
        public void CursorSetup3()
        {
            if (_handler.PlayerTurn)
            {
                _game.Cursor1.SetPosition(_theBoard.Pos[0]);
                _game.Cursor2.SetPosition(_theBoard.Pos[1]);
                _game.Cursor3.SetPosition(_theBoard.Pos[2]);
                _game.Cursor4.SetPosition(_theBoard.Pos[6]);
                _game.Cursor5.SetPosition(_theBoard.Pos[7]);
                _game.Cursor6.SetPosition(_theBoard.Pos[8]);
                _selectCursorSetup = 3;
            }
        }

        public void ButtonADown(InputController.ButtonStates buttonStates)
        {
            if (_handler.PlayerTurn && buttonStates == InputController.ButtonStates.JustPressed)
            {
                _handler.SwitchPlayer();
                _game.Wizard.CursorSetup1();
            } 
        }

        public void ButtonBDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public void ButtonXDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public void ButtonYDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public void ButtonLeftShoulderDown(InputController.ButtonStates buttonStates)
        {
            if (_handler.PlayerTurn)
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

        public void ButtonRightShoulderDown(InputController.ButtonStates buttonStates)
        {
            if (_handler.PlayerTurn)
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

        public void ButtonStartDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public void ButtonBackDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public void ButtonLeftStickDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public void ButtonRightStickDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }
    }
}
