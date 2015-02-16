using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GemFight.Framework;
using Microsoft.Xna.Framework;

namespace GemFight
{
    class Animation : IUpdateable
    {
        private double _milisecondsSinceLastFrameUpdate = 0;
        private Sprite _sprite;
        private int _currentFrame = 0;
        private List<Rectangle> _frames = new List<Rectangle>();
        private bool _loop;
        private int _delay;
        private bool _lastFrame;

        public bool LastFrame
        {
            get { return _lastFrame; }
        }
        public bool Loop
        {
            get { return _loop; }
            set { _loop = value; }
        }

        public int Delay
        {
            get { return _delay; }
            set { _delay = value; }
        }

        public List<Rectangle> Frames
        {
            get { return _frames; }
            set { _frames = value; }
        }

        public Animation(Sprite sprite)
        {
            _sprite = sprite;
            _delay = 200;
            _loop = true;
            _lastFrame = false;
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds > _milisecondsSinceLastFrameUpdate + Delay)
            {
                _sprite.SourceRectangle = NextFrame();
                _milisecondsSinceLastFrameUpdate = gameTime.TotalGameTime.TotalMilliseconds;
            }
        }

        private Rectangle NextFrame()
        {
            if (_currentFrame == _frames.Count - 1 && _loop) _currentFrame = 0;
            else if (_currentFrame < _frames.Count - 1) _currentFrame++;
            if (_currentFrame == _frames.Count - 1) _lastFrame = true;
            return Frames[_currentFrame];
        }

        public bool Enabled { get; private set; }
        public int UpdateOrder { get; private set; }
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
    }
}
