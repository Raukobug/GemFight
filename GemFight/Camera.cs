using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GemFight.Framework;
using Microsoft.Xna.Framework;

namespace GemFight
{
    public class Camera
    {
        private double _milisecondsSinceLastUpdate = 0;
        private List<Sprite> _spriteList = new List<Sprite>();
        private int _screenWidth;
        private int _screenHeigh;
        private int _count = 0;
        private bool _shakeY;
        private bool _shakeX;
        private int _delay;

        public bool ShakeY
        {
            get { return _shakeY; }
            set { _shakeY = value; }
        }
        public bool ShakeX
        {
            get { return _shakeX; }
            set { _shakeX = value; }
        }

        public Camera(int screenWidth, int screenHeigh)
        {
            _screenWidth = screenWidth;
            _screenHeigh = screenHeigh;
            _delay = 20;
        }

        public void Add(Sprite sprite)
        {
            if (!_spriteList.Contains(sprite))
            {
                _spriteList.Add(sprite);
            }   
        }

        public void Add(List<Sprite> list)
        {
            foreach (var sprite in list)
            {
                if (!_spriteList.Contains(sprite))
                {
                    _spriteList.Add(sprite);                    
                }          
            }
        }

        public int Top()
        {
            return 0;
        }

        public int Left()
        {
            return 0;
        }

        public int Right()
        {
            return _screenWidth;
        }

        public int Bottom()
        {
            return _screenHeigh;
        }

        public int CenterX()
        {
            return _screenWidth/2;
        }

        public int CenterY()
        {
            return _screenHeigh/2;
        }

        public void Shake(GameTime gameTime)
        {
            if (_shakeY && gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastUpdate + _delay)
            {
                if (_count%2 == 0)
                {
                    foreach (var sprite in _spriteList)
                    {
                        sprite.PositionY = sprite.PositionY + 5;
                    }
                }
                else
                {
                    foreach (var sprite in _spriteList)
                    {
                        sprite.PositionY = sprite.PositionY - 5;    
                    }
                }
                _count++;
                if (_count >= 10)
                {
                    _shakeY = false;
                    _count = 0;
                }
                _milisecondsSinceLastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }

            if (_shakeX && gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastUpdate + _delay)
            {
                if (_count % 2 == 0)
                {
                    foreach (var sprite in _spriteList)
                    {
                        sprite.PositionX = sprite.PositionX + 5;
                    }
                }
                else
                {
                    foreach (var sprite in _spriteList)
                    {
                        sprite.PositionX = sprite.PositionX - 5;
                    }
                }
                _count++;
                if (_count >= 10)
                {
                    _shakeX = false;
                    _count = 0;
                }
                _milisecondsSinceLastUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }
    }
}
