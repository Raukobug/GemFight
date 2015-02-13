using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class curser : Sprite, IInputGamePadDigitalDpad, IInputGamePadButtons, ICollidable
    {
        private Sprite SelectedSprite = null;
        private Board _theBoard = Board.GetInstance();
        public curser(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
        }

        public void LeftStickMove(Vector2 moveVector)
        {
            if (moveVector.X > 0.5)
            {
                PositionX = PositionX + 96;
                if (PositionX > 96 * 6 + 3)
                {
                    PositionX = 96 * 6 + 3;
                }
            }
            if (moveVector.X < -0.5)
            {
                PositionX = PositionX - 96;
                if (PositionX < 99)
                {
                    PositionX = 99;
                }
            }
            if (moveVector.Y > 0.5)
            {
                PositionY = PositionY - 94;
                if (PositionY < 97)
                {
                    PositionY = 97;
                }
            }
            if (moveVector.Y < -0.5)
            {
                PositionY = PositionY + 94;
                if (PositionY > 94 * 6 + 3)
                {
                    PositionY = 94*6+3;
                }
            }
        }

        public void ButtonDpadDownPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionY = PositionY + 94;
                if (PositionY > 94 * 6 + 3)
                {
                    PositionY = 94 * 6 + 3;
                }      
            }

        }

        public void ButtonDpadUpPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionY = PositionY - 94;
                if (PositionY < 97)
                {
                    PositionY = 97;
                }
            }
        }

        public void ButtonDpadLeftPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionX = PositionX - 96;
                if (PositionX < 99)
                {
                    PositionX = 99;
                }
            }
        }

        public void ButtonDpadRightPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionX = PositionX + 96;
                if (PositionX > 96*6 + 3)
                {
                    PositionX = 96*6 + 3;
                }
            }
        }

        public void ButtonADown(InputController.ButtonStates buttonStates)
        {
            Game1 game = Game1.GetInstance();
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                game.ListOfGems.Remove((Gem)SelectedSprite);
                if (game.ListOfGems.Count <= 12)
                {
                    _theBoard.GenerateGems();
                }      
            }
        }

        public void ButtonBDown(InputController.ButtonStates buttonStates)
        {
            Game1 game = Game1.GetInstance();
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                game.ListOfGems.Remove((Gem)SelectedSprite);
                if (game.ListOfGems.Count <= 12)
                {
                    _theBoard.GenerateGems();
                }
            }
        }

        public void ButtonXDown(InputController.ButtonStates buttonStates)
        {
            Game1 game = Game1.GetInstance();
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                game.ListOfGems.Remove((Gem)SelectedSprite);
                if (game.ListOfGems.Count <= 12)
                {
                    _theBoard.GenerateGems();
                }
            }
        }

        public void ButtonYDown(InputController.ButtonStates buttonStates)
        {
            Game1 game = Game1.GetInstance();
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                game.ListOfGems.Remove((Gem)SelectedSprite);
                if (game.ListOfGems.Count <= 12)
                {
                    _theBoard.GenerateGems();
                }
            }
        }

        public void ButtonLeftShoulderDown(InputController.ButtonStates buttonStates)
        {
            //throw new NotImplementedException();
        }

        public void ButtonRightShoulderDown(InputController.ButtonStates buttonStates)
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

        public void CollideWith(Sprite other)
        {
            if (BoundingBox.Intersects(other.BoundingBox))
            {
                SelectedSprite = other;
            }
        }

        internal void Position(Vector2 vector2)
        {
            PositionX = vector2.X;
            PositionY = vector2.Y;
        }
    }
}
