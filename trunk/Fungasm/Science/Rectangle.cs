﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Graphics;

using Tao.OpenGl;

namespace Fungasm.Science
{
    public class Rectangle
    {
        Vector BottomLeft { get; set; }
        Vector TopRight { get; set; }

        public Vector Center 
        {
            get { return new Vector(TopRight.X - BottomLeft.X, TopRight.Y - BottomLeft.Y, 0); }
        }

        Color _color = new Color(1, 1, 1, 1);
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Rectangle(Vector bottomLeft, Vector topRight)
        {
            BottomLeft = bottomLeft;
            TopRight = topRight;
        }
        public void Render()
        {
            Gl.glColor3f(_color.Red, _color.Green, _color.Blue);
            Gl.glBegin(Gl.GL_LINE_LOOP);
            {
                Gl.glVertex2d(BottomLeft.X, BottomLeft.Y);
                Gl.glVertex2d(BottomLeft.X, TopRight.Y);
                Gl.glVertex2d(TopRight.X, TopRight.Y);
                Gl.glVertex2d(TopRight.X, BottomLeft.Y);
            }
            Gl.glEnd();
        }

        public bool Intersects(System.Windows.Point point)
        {
            if (point.X >= BottomLeft.X && point.X <= TopRight.X &&
                point.Y <= TopRight.Y && point.Y >= BottomLeft.Y)
                return true;

            return false;
        }
    }
}
