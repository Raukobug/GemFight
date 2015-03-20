using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemFight.Framework;
using Microsoft.Xna.Framework;

namespace GemFight
{
    public class Effect
    {
        private double _milisecondsSinceLastUpdate = 0;
        private Game1 _game = Game1.GetInstance();
        private Sprite _sprite;
        private float _startX;
        private float _startY;
        private bool _fallDown;
        private int _delay;
        public Effect(Sprite sprite)
        {
            _sprite = sprite;
            _startX = _sprite.PositionX;
            _startY = _sprite.PositionY;
            _delay = 20;

        }

        public void JumpThenFallDown(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastUpdate + _delay)
            {
                if (_sprite.PositionX < _game.Camera.CenterX())
                {
                    _sprite.PositionX = _sprite.PositionX - 5;
                    _sprite.Rotation = _sprite.Rotation - 1;
                }
                else
                {
                    _sprite.PositionX = _sprite.PositionX + 5;
                    _sprite.Rotation = _sprite.Rotation + 1;
                }

                if (_fallDown)
                {
                    _sprite.PositionY = _sprite.PositionY + 5;
                }
                else
                {
                    _sprite.PositionY = _sprite.PositionY - 5;
                }

                if (_sprite.PositionY < _startY - 30)
                {
                    _fallDown = true;

                }
                _sprite.Scale = _sprite.Scale*0.9f;
                _milisecondsSinceLastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }
    }
}
