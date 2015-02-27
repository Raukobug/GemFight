using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Curser : Sprite, IInputGamePadDigitalDpad, IInputGamePadButtons, ICollidable
    {
        private Animation _animation;
        private Sprite _selectedSprite = null;
        private readonly Board _theBoard = Board.GetInstance();
        public Curser(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
            SourceRectangle = new Rectangle(0, 0, 95, 92);
            _animation = new Animation(this);
            _animation.Frames.Add(new Rectangle(0, 0, 95, 92));
            _animation.Frames.Add(new Rectangle(95, 0, 95, 92));
            _animation.Frames.Add(new Rectangle(190, 0, 95, 92));
            _animation.Frames.Add(new Rectangle(285, 0, 95, 92));
            _animation.Frames.Add(new Rectangle(190, 0, 95, 92));
            _animation.Frames.Add(new Rectangle(95, 0, 95, 92));
        }

        public override void Update(GameTime gameTime)
        {
            if (_animation != null)
            {
                _animation.Update(gameTime);
            }
        }

        public void ButtonDpadDownPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionY = PositionY + 94;
                if (PositionY > _theBoard.EndPointy)
                {
                    PositionY = _theBoard.EndPointy-1;
                }
            }
            _selectedSprite = null;
        }

        public void ButtonDpadUpPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionY = PositionY - 94;
                if (PositionY < _theBoard.StartPointy + 93)
                {
                    PositionY = _theBoard.StartPointy + 93;
                }
            }
            _selectedSprite = null;
        }

        public void ButtonDpadLeftPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionX = PositionX - 97;
                if (PositionX < _theBoard.StartPointx + 95)
                {
                    PositionX = _theBoard.StartPointx + 95;
                }
            }
            _selectedSprite = null;
        }

        public void ButtonDpadRightPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                PositionX = PositionX + 97;
                if (PositionX > _theBoard.EndPointx)
                {
                    PositionX = _theBoard.EndPointx-1;
                }
            }
            _selectedSprite = null;
        }

        public void ButtonADown(InputController.ButtonStates buttonStates)
        {
            Game1 game = Game1.GetInstance();
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                //game.ListOfGems.Remove((Gem)_selectedSprite);
                Gem gem = (Gem)_selectedSprite;
                if (gem != null)
                {
                    gem.Destroy();                   
                }
                //if (game.ListOfGems.Count <= 12)
                //{
                //    _theBoard.GenerateGems();
                //}
            }
        }

        public void ButtonADown(InputController.ButtonStates buttonStates, InputController controller)
        {
            
        }

        public void ButtonBDown(InputController.ButtonStates buttonStates)
        {
        }

        public void ButtonXDown(InputController.ButtonStates buttonStates)
        {
        }

        public void ButtonYDown(InputController.ButtonStates buttonStates)
        {
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
                _selectedSprite = other;
            }
        }

        public void SetPosition(Vector2 vector2)
        {
            PositionX = vector2.X;
            PositionY = vector2.Y;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Do we have a texture? If not then there is nothing to draw...
            if (SpriteTexture != null)
            {
                // Has a source rectangle been set?
                if (SourceRectangle.IsEmpty)
                {
                    // No, so draw the entire sprite texture
                    spriteBatch.Draw(SpriteTexture, Position, null, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0f);
                }
                else
                {
                    // Yes, so just draw the specified SourceRect
                    spriteBatch.Draw(SpriteTexture, Position, SourceRectangle, Color.White, Rotation, Origin, Scale, SpriteEffects.None, 0f);
                }
            }
        }
    }
}
