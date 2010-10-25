using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;

using Fungasm.Graphics;

namespace Fungasm.Core
{
    public class SplashScreenState : IGameObject
    {
        StateManager _stateManager;
        TextureManager _textureManager;
        Renderer _renderer;

        Sprite _logo;
        double _delayInSeconds = 10;

        public SplashScreenState(StateManager stateManager, TextureManager tm, Renderer rend)
        {
            _stateManager = stateManager;
            _textureManager = tm;
            _renderer = rend;
            _logo = new Sprite() { Texture = _textureManager.Get("testTexture"), Height = 100, Width = 100 };
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
