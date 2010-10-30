using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Graphics;
using Fungasm.Science;
using Fungasm.Tools;

using Tao.OpenGl;

namespace Fungasm.Core
{
    public class DrawSpriteState : IGameObject
    {
        TextureManager _textureManager;
        Renderer _renderer;
        Font _font;
        Text _fpsText;
        FPSCounter _fps;
        Circle _circle;

        public DrawSpriteState(TextureManager textureManager, Renderer renderer)
        {
            _textureManager = textureManager;
            _renderer = renderer;
            _fps = new FPSCounter();
            _font = new Font(_textureManager.Get("TimesFont"), FontParser.Parse("Fonts/timesFont.fnt"));
            _circle = new Circle(Vector.Zero, 200);
        }

        #region IGameObject Members

        public void Update(double deltaTime)
        {
            _fps.Process(deltaTime);
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            _fpsText = new Text("FPS: " + _fps.CurrentFPS.ToString("00.0"), _font, 100,-100);
            _renderer.DrawText(_fpsText);

            //Draw anything left in the Batch before finishing the loop
            _renderer.Render();
        }

        #endregion
    }
}
