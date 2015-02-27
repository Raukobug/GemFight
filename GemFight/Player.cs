using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Player : Sprite, IInputGamePadButtons
    {
        private GameHandler _handler = GameHandler.GetInstance();
        private Game1 _game = Game1.GetInstance();
        public int Health = 100;
        public int Armor = 0;
        public int BlueGems = 0;
        public int GreenGems = 0;
        public int RedGems = 0;
        public int YellowGems = 0;
        public bool HasTurn;
        public Player(Texture2D spriteTexture, Vector2 position, bool hasTurn) : base(spriteTexture, position)
        {
            HasTurn = hasTurn;
        }

        public virtual void ButtonADown(InputController.ButtonStates buttonStates)
        {
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

        public virtual void ButtonLeftShoulderDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public virtual void ButtonRightShoulderDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
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

        public virtual void CursorSetup1()
        {
            
        }

        public virtual void CursorSetup2()
        {

        }

        public virtual void CursorSetup3()
        {

        }
    }
}
