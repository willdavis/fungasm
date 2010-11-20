using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;

using Fungasm.Graphics;

namespace Fungasm.Core
{
    public class SplashScreenState : IRenderable
    {
        Tween _tween = new Tween(0, 300, 5, Tween.EaseInExpo);
        Tween _colorTween = new Tween(0,100,5);
        StateManager _stateManager;
        TextureManager _textureManager;
        Renderer _renderer;

        Sprite _logo;
        Color _logoColor = new Color(1,0,0,0);
        double _delayInSeconds = 10;

        public SplashScreenState(StateManager stateManager, TextureManager tm, Renderer rend)
        {
            _stateManager = stateManager;
            _textureManager = tm;
            _renderer = rend;
            _logo = new Sprite() 
            {
                Texture = _textureManager.Get("FungasmSplash"),
                Position = new Science.Vector(0,-70,0),
                Height = 600,
                Width = 800
            };
        }

        #region IGameObject Members

        public void Update(double deltaTime)
        {
            _delayInSeconds -= deltaTime;
            if (_delayInSeconds <= 0)
            {
                _delayInSeconds = 10;
                _stateManager.ChangeState("SpriteTest");
            }
            
            if (!_tween.IsFinished)
            {
                _tween.Update(deltaTime);
                _logo.Width = (float)_tween.Value;
                _logo.Height = (float)_tween.Value;
            }

            /*
            if (!_colorTween.IsFinished)
            {
                _colorTween.Update(deltaTime);
                _logoColor.Alpha = (float)_tween.Value;
                _logo.SetColor(_logoColor);
            }
             */
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawSprite(_logo);

            _renderer.Render();
        }

        #endregion
    }
}
