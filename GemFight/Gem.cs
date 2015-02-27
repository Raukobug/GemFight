﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemFight.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GemFight
{
    enum GemColor
    {
        Blue,
        Green,
        Yellow,
        Red,
        Black,
        Gray
    }
    public class Gem : Sprite
    {
        private GemColor _gemColor = GemColor.Red;
        private const int ImageWidth = 91;
        private const int ImageHeight = 88;
        private Animation _animation;
        private Game1 _game = Game1.GetInstance();
        public Gem(Texture2D spriteTexture, Vector2 position, int i)
            : base(spriteTexture, position)
        {
            switch (i)
            {
                case 0:
                    _gemColor = GemColor.Blue;
                    SourceRectangle = new Rectangle(0, 0, ImageWidth, ImageHeight);
                    break;
                case 1:
                    _gemColor = GemColor.Green;
                    SourceRectangle = new Rectangle(0, ImageHeight, ImageWidth, ImageHeight);
                    break;
                case 2:
                    _gemColor = GemColor.Red;
                    SourceRectangle = new Rectangle(0, ImageHeight * 2, ImageWidth, ImageHeight);
                    break;
                case 3:
                    _gemColor = GemColor.Yellow;
                    SourceRectangle = new Rectangle(0, ImageHeight * 3, ImageWidth, ImageHeight);
                    break;
                case 4:
                    _gemColor = GemColor.Gray;
                    SourceRectangle = new Rectangle(0, ImageHeight * 4, ImageWidth, ImageHeight);
                    break;
                case 5:
                    _gemColor = GemColor.Black;
                    SourceRectangle = new Rectangle(0, ImageHeight * 5, ImageWidth, ImageHeight);
                    break;
                case 6:
                    _gemColor = GemColor.Black;
                    SourceRectangle = new Rectangle(0, ImageHeight * 6, ImageWidth, ImageHeight);
                    break;
            }
        }

        public void Destroy()
        {
            _animation = new Animation(this);
            _animation.Delay = 120;
            switch (_gemColor)
            {
                case GemColor.Blue:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 2, 0, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 3, 0, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 4, 0, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 5, 0, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 6, 0, ImageWidth, ImageHeight));
                    break;
                case GemColor.Green:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight, ImageWidth, ImageHeight));
                    break;
                case GemColor.Red:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth * 2, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 2, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 2, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 2, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 2, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 2, ImageWidth, ImageHeight));
                    break;
                case GemColor.Yellow:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth * 3, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 3, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 3, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 3, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 3, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 3, ImageWidth, ImageHeight));
                    break;
                case GemColor.Gray:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth * 4, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 4, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 4, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 4, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 4, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 4, ImageWidth, ImageHeight));
                    break;
                case GemColor.Black:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(ImageWidth, 0, ImageWidth * 5, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 2, ImageHeight * 5, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 3, ImageHeight * 5, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 4, ImageHeight * 5, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 5, ImageHeight * 5, ImageWidth, ImageHeight));
                    _animation.Frames.Add(new Rectangle(ImageWidth * 6, ImageHeight * 5, ImageWidth, ImageHeight));
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_animation != null)
            {
                _animation.Update(gameTime);
                if (_animation.LastFrame)
                {
                    // TODO : In case you forgot.. You have to look in Game1 for LastFrame.
                    _game.GemsRemoveAble.Add(this);                      
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

        public bool LastFrame()
        {
            return _animation.LastFrame;
        }
    }
}
