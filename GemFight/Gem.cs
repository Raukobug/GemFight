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
        Black,
        Gray,
        Blue,
        Green,
        Red,
        Yellow
    }

    public class Gem : Sprite
    {
        public Gem(Texture2D spriteTexture, Vector2 position) : base(spriteTexture, position)
        {
        }
    }
}
