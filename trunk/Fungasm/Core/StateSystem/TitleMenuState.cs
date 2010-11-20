using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Tao.OpenGl;

namespace Fungasm.Core
{
    public class TitleMenuState : IRenderable
    {


        #region IGameObject Members

        public void Update(double deltaTime)
        {
        }

        public void Render()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);


            Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
            {
                Gl.glColor4d(1.0, 0.0, 0.0, 0.5);
                Gl.glVertex3d(-50, 0, 0);
                Gl.glColor3d(1.0, 1.0, 0.0);
                Gl.glVertex3d(50, 0, 0);
                Gl.glColor3d(0.0, 1.0, 1.0);
                Gl.glVertex3d(0, 50, 0);
            }
            Gl.glEnd();
            Gl.glFinish();
        }

        #endregion
    }
}
