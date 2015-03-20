using System.Collections.Generic;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Player : Sprite, IInputGamePadButtons, ICollidable
    {
        protected enum State
        {
            Wait,
            Ability1,
            Ability2,
            Ability3
        }
        protected GameHandler Handler = GameHandler.GetInstance();
        protected Game1 Game = Game1.GetInstance();
        protected readonly Board TheBoard = Board.GetInstance();
        protected int SelectCursorSetup = 1;
        public List<Curser> CurserList = new List<Curser>();
        protected Animation Animation;
        protected const int ImageWidth = 250;
        protected const int ImageHeight = 300;
        public int Health = 75;
        public int Armor = 0;
        public int BlueGems = 0;
        public int GreenGems = 0;
        public int RedGems = 0;
        public int YellowGems = 0;
        public bool HasTurn;
        public Player Enemy;
        public int PlayerNumber;
        public bool ExtraTurn;
        public Player(Texture2D spriteTexture, Vector2 position, bool hasTurn, int playerNumber)
            : base(spriteTexture, position)
        {
            HasTurn = hasTurn;
            PlayerNumber = playerNumber;
            SourceRectangle = new Rectangle(0, 0, ImageWidth, ImageHeight);
        }

        public virtual void ButtonADown(InputController.ButtonStates buttonStates)
        {
        }

        public void Reset()
        {
            Health = 75;
            Armor = 0;
            BlueGems = 0;
            GreenGems = 0;
            RedGems = 0;
            YellowGems = 0;
        }
        public virtual void ButtonBDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public virtual void ButtonXDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public virtual void ButtonYDown(InputController.ButtonStates buttonStates)
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

        public void DoDmg(int dmg, bool Bypass)
        {
            for (int i = 0; i < dmg; i++)
            {
                if (Bypass)
                {
                    Health--;
                }
                else
                {
                    if (Armor > 0)
                    {
                        Armor--;
                    }
                    else
                    {
                        Health--;
                    }
                }
            }
            if (Health < 1)
            {
                Game.winner = Enemy.ToString().Replace("GemFight.", "");
                Game.gameState = Game1.GameState.Win;
                Handler.SwitchPlayer(Enemy);
            }
        }

        public virtual void Ability1()
        {

        }
        public virtual void Ability2()
        {

        }
        public virtual void Ability3()
        {

        }

        public void CollideWith(Sprite other)
        {

        }
    }
}
