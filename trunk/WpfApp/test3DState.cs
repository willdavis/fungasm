using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Core;
using Fungasm.Science;

using Tao.OpenGl;

namespace WpfApp
{
    public class Test3DState : IRenderable
    {
        private double _currentRotation = 0;
        public Test3DState() { }

        #region ISimObject Members

        public void Update(double deltaTime) { _currentRotation += deltaTime; }

        public void Render()
        {
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glClearColor(1, 1, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // This is a simple way of using a camera
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Vector cameraPosition = new Vector(-75, 125, -500); // half a meter back on the Z axis
            Vector cameraLookAt = new Vector(0, 0, 0); // make the camera look at the world origin.
            Vector cameraUpVector = new Vector(0, 1, 0);
            Glu.gluLookAt( cameraPosition.X, cameraPosition.Y, cameraPosition.Z, 
                cameraLookAt.X, cameraLookAt.Y, cameraLookAt.Z, 
                cameraUpVector.X, cameraUpVector.Y, cameraUpVector.Z);

            Gl.glRotated(_currentRotation*50, 0, 1, 0);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            {
                Gl.glColor3d(1, 0, 0);
                Gl.glVertex3d(0.0f, 100, 0.0f);
                Gl.glColor3d(0, 1, 0);
                Gl.glVertex3d(-100, -100, 100);
                Gl.glColor3d(0, 0, 1);
                Gl.glVertex3d(100, -100, 100);
                Gl.glColor3d(0, 1, 0);
                Gl.glVertex3d(100, -100, -100);
                Gl.glColor3d(0, 0, 1);
                Gl.glVertex3d(-100, -100, -100);
                Gl.glColor3d(0, 1, 0);
                Gl.glVertex3d(-100, -100, 100);
            }
            Gl.glEnd();
        }

        #endregion
    }
}
