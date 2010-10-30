using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;
using Fungasm.Science;
using Fungasm.Graphics;

using Tao.Platform.Windows;

namespace Fungasm.Core
{
    public class IntersectionTestState : IGameObject
    {
        Circle _circle1 = new Circle(Vector.Zero, 150);
        Rectangle _rectangle = new Rectangle(new Vector(-100, -100, 0), new Vector(100, 100, 0));
        MouseInput _input;
        SimpleOpenGlControl _openGlControl;

        public IntersectionTestState(MouseInput input, SimpleOpenGlControl openGLctrl)
        {
            Gl.glLineWidth(3);
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            _input = input;
            _openGlControl = openGLctrl;
        }

        #region IGameObject Members

        public void Update(double deltaTime)
        {
            if (_circle1.Intersects(_input.MousePosition))
            {
                _circle1.Color = new Color(1, 0, 0, 1);
            }
            else
            {
                // If the circle's not intersected turn it back to white.
                _circle1.Color = new Color(1, 1, 1, 1);
            }

            if (_rectangle.Intersects(_input.MousePosition))
                _rectangle.Color = new Color(1, 0, 0, 1);
            else
                _rectangle.Color = new Color(1,1,1,1);
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _circle1.Draw();
            _rectangle.Render();

            // Draw the mouse cursor as a point
            Gl.glPointSize(5);
            Gl.glBegin(Gl.GL_POINTS);
            {
                Gl.glVertex2f((float)_input.MousePosition.X,
                (float)_input.MousePosition.Y);
            }
            Gl.glEnd();

            //Draw a center point for the screen
            Gl.glPointSize(5);
            Gl.glBegin(Gl.GL_POINTS);
            {
                Gl.glVertex2f(0, 0);
            }
            Gl.glEnd();
        }

        #endregion
    }
}
