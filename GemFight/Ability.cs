using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    public class Ability : Sprite
    {
        public enum AnimationDirection
        {
            Vertical,
            Horhorizontal
        }
        private int _speed;
        private readonly Player _destroyOnContact;
        private readonly int _removeAtX;
        private readonly int _removeAtY;
        private readonly Game1 _game = Game1.GetInstance();
        private Animation _animation;
        private int _imageWidth;
        private int _imageHeight;
        private int _frameNumber;
        private bool _endAnimation;
        private AnimationDirection _direction;
        private GameHandler _handler = GameHandler.GetInstance();
        public Ability(Texture2D spriteTexture, Vector2 position, int speed, Player destroyOnContact, int removeAtX, int removeAtY, int imageWidth, int imageHeight, int frameNumber, AnimationDirection direction)
            : base(spriteTexture, position)
        {
            _speed = speed;
            _destroyOnContact = destroyOnContact;
            _removeAtX = removeAtX;
            _removeAtY = removeAtY;
            _imageWidth = imageWidth;
            _imageHeight = imageHeight;
            _frameNumber = frameNumber;
            _direction = direction;
            SourceRectangle = new Rectangle(0, 0, _imageWidth, _imageHeight);
            _animation = new Animation(this);
            for (int i = 0; i < _frameNumber; i++)
            {
                _animation.Frames.Add(new Rectangle(_imageWidth * i, 0, _imageWidth, _imageHeight));
            }
            _game.Sound.Play();
        }

        public override void Update(GameTime gameTime)
        {
            if (_animation != null)
            {
                _animation.Update(gameTime);
            }
            if (_direction == AnimationDirection.Horhorizontal)
            {
                PositionX = PositionX + _speed;
            }
            else
            {
                PositionY = PositionY + _speed;
                if (PositionY < 0)
                {
                    PositionX = _destroyOnContact.PositionX + 20;
                    _speed = _speed * -1;
                }
            }
            Destroy();
        }

        public void Destroy()
        {
            if (_direction == AnimationDirection.Horhorizontal)
            {
                if (BoundingBox.Intersects(_destroyOnContact.BoundingBox) && PositionX <= _destroyOnContact.PositionX + _removeAtX)
                {
                    _speed = 0;
                    if (!_endAnimation)
                    {
                        _animation = new Animation(this);
                        _animation.Delay = 100;
                        for (int i = _frameNumber; i < _frameNumber * 2; i++)
                        {
                            _animation.Frames.Add(new Rectangle(_imageWidth * i, 0, _imageWidth, _imageHeight));
                        }
                        _game.Camera.ShakeX = true;
                    }
                    if (_animation.LastFrame)
                    {
                        _game.AbilitiesRemoveAble.Add(this);

                    }
                    _endAnimation = true;
                }
            }
            else
            {
                if (BoundingBox.Intersects(_destroyOnContact.BoundingBox) && PositionY >= _destroyOnContact.PositionY + _removeAtY)
                {
                    _speed = 0;
                    if (!_endAnimation)
                    {
                        _animation = new Animation(this);
                        _animation.Delay = 100;
                        for (int i = _frameNumber; i < _frameNumber * 2; i++)
                        {
                            _animation.Frames.Add(new Rectangle(_imageWidth * i, 0, _imageWidth, _imageHeight));
                        }
                        _game.Camera.ShakeY = true;
                    }
                    if (_animation.LastFrame)
                    {
                        _game.AbilitiesRemoveAble.Add(this);
                    }
                    _endAnimation = true;
                }
            }

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
