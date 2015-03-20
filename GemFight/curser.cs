using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Curser : Sprite, IInputGamePadDigitalDpad, IInputGamePadButtons, ICollidable
    {
        private Animation _animation;
        public Sprite SelectedSprite = null;
        private GameHandler _handler = GameHandler.GetInstance();
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
                if (_handler.AbleToMoveDown)
                {
                    PositionY = PositionY + 94;                   
                }
            }
            SelectedSprite = null;
        }

        public void ButtonDpadUpPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                if (_handler.AbleToMoveUp)
                {
                    PositionY = PositionY - 94;                   
                }
            }
            SelectedSprite = null;
        }

        public void ButtonDpadLeftPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                if (_handler.AbleToMoveLeft)
                {
                    PositionX = PositionX - 97;
                }
            }
            SelectedSprite = null;
        }

        public void ButtonDpadRightPressed(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                if (_handler.AbleToMoveRight)
                {
                    PositionX = PositionX + 97;
                }
            }
            SelectedSprite = null;
        }

        public void ButtonADown(InputController.ButtonStates buttonStates)
        {
            if (buttonStates == InputController.ButtonStates.JustPressed)
            {
                Gem gem = (Gem)SelectedSprite;
                if (gem != null)
                {
                    gem.Destroy();
                }
            }
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
                SelectedSprite = other;
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
