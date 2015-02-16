using System;
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
        private int imageWidth = 91;
        private int imageHeight = 88;
        private Animation _animation;
        private Game1 _game = Game1.GetInstance();
        public Gem(Texture2D spriteTexture, Vector2 position, int i)
            : base(spriteTexture, position)
        {
            switch (i)
            {
                case 0:
                    _gemColor = GemColor.Blue;
                    SourceRectangle = new Rectangle(0, 0, imageWidth, imageHeight);
                    break;
                case 1:
                    _gemColor = GemColor.Green;
                    SourceRectangle = new Rectangle(0, imageHeight, imageWidth, imageHeight);
                    break;
                case 2:
                    _gemColor = GemColor.Red;
                    SourceRectangle = new Rectangle(0, imageHeight * 2, imageWidth, imageHeight);
                    break;
                case 3:
                    _gemColor = GemColor.Yellow;
                    SourceRectangle = new Rectangle(0, imageHeight * 3, imageWidth, imageHeight);
                    break;
                case 4:
                    _gemColor = GemColor.Gray;
                    SourceRectangle = new Rectangle(0, imageHeight * 4, imageWidth, imageHeight);
                    break;
                case 5:
                    _gemColor = GemColor.Black;
                    SourceRectangle = new Rectangle(0, imageHeight * 5, imageWidth, imageHeight);
                    break;
                case 6:
                    _gemColor = GemColor.Black;
                    SourceRectangle = new Rectangle(0, imageHeight * 6, imageWidth, imageHeight);
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
                    _animation.Frames.Add(new Rectangle(imageWidth, 0, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 2, 0, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 3, 0, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 4, 0, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 5, 0, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 6, 0, imageWidth, imageHeight));
                    break;
                case GemColor.Green:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(imageWidth, 0, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 2, imageHeight, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 3, imageHeight, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 4, imageHeight, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 5, imageHeight, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 6, imageHeight, imageWidth, imageHeight));
                    break;
                case GemColor.Red:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(imageWidth, 0, imageWidth * 2, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 2, imageHeight * 2, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 3, imageHeight * 2, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 4, imageHeight * 2, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 5, imageHeight * 2, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 6, imageHeight * 2, imageWidth, imageHeight));
                    break;
                case GemColor.Yellow:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(imageWidth, 0, imageWidth * 3, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 2, imageHeight * 3, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 3, imageHeight * 3, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 4, imageHeight * 3, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 5, imageHeight * 3, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 6, imageHeight * 3, imageWidth, imageHeight));
                    break;
                case GemColor.Gray:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(imageWidth, 0, imageWidth * 4, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 2, imageHeight * 4, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 3, imageHeight * 4, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 4, imageHeight * 4, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 5, imageHeight * 4, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 6, imageHeight * 4, imageWidth, imageHeight));
                    break;
                case GemColor.Black:
                    _animation.Loop = false;
                    _animation.Frames.Add(new Rectangle(imageWidth, 0, imageWidth * 5, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 2, imageHeight * 5, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 3, imageHeight * 5, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 4, imageHeight * 5, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 5, imageHeight * 5, imageWidth, imageHeight));
                    _animation.Frames.Add(new Rectangle(imageWidth * 6, imageHeight * 5, imageWidth, imageHeight));
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
