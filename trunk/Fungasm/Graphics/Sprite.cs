using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Science;

namespace Fungasm.Graphics
{
    public class Sprite
    {
        internal const int VertexAmount = 6;
        Vector[] _vertexPositions = new Vector[VertexAmount];
        Color[] _vertexColors = new Color[VertexAmount];
        Point[] _vertexUVs = new Point[VertexAmount];
        Texture _texture = new Texture();

        public Vector[] VertexPositions { get { return _vertexPositions; } }
        public Color[] VertexColors { get { return _vertexColors; } }
        public Point[] VertexUVs { get { return _vertexUVs; } }


        public Sprite()
        {
            InitVertexPositions(new Vector(0, 0, 0), 1, 1);
            SetColor(new Color(1, 1, 1, 1));
            SetUVs(new Point(0, 0), new Point(1, 1));
        }
        public Texture Texture
        {
            get { return _texture; }
            set
            {
                _texture = value;
                InitVertexPositions(Center, _texture.Width, _texture.Height);
            }
        }
        public Vector Center
        {
            get
            {
                double halfWidth = Width / 2;
                double halfHeight = Height / 2;
                return new Vector(
                _vertexPositions[0].X + halfWidth,
                _vertexPositions[0].Y - halfHeight,
                _vertexPositions[0].Z);
            }
        }
        public double Width
        {
            // topright - topleft
            get { return _vertexPositions[1].X - _vertexPositions[0].X; }
            set { InitVertexPositions(Center, value, Height); }
        }
        public double Height
        {
            // topleft - bottomleft
            get { return _vertexPositions[0].Y - _vertexPositions[2].Y; }
            set { InitVertexPositions(Center, Width, value); }
        }
        public Vector Position
        {
            get { return Center; }
            set { InitVertexPositions(value, Width, Height); }
        }

        public void SetUVs(Point topLeft, Point bottomRight)
        {
            // TopLeft Triangle
            _vertexUVs[0] = topLeft;                                //TopLeft
            _vertexUVs[1] = new Point(bottomRight.X, topLeft.Y);    //TopRight
            _vertexUVs[2] = new Point(topLeft.X, bottomRight.Y);    //BottomLeft

            // BottomRight Triangle
            _vertexUVs[3] = new Point(bottomRight.X, topLeft.Y);    //TopRight
            _vertexUVs[4] = bottomRight;                            //BottomRight
            _vertexUVs[5] = new Point(topLeft.X, bottomRight.Y);    //BottomLeft
        }
        public void SetColor(Color color)
        {
            for (int i = 0; i < VertexAmount; i++)
            {
                _vertexColors[i] = color;
            }
        }
        //TODO: Add SetGradient()?

        private void InitVertexPositions(Vector position, double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;

            // Clockwise creation of two triangles to make a quad.
            // TopLeft, TopRight, BottomLeft
            _vertexPositions[0] = new Vector(position.X - halfWidth, position.Y + halfHeight, position.Z);
            _vertexPositions[1] = new Vector(position.X + halfWidth, position.Y + halfHeight, position.Z);
            _vertexPositions[2] = new Vector(position.X - halfWidth, position.Y - halfHeight, position.Z);
            // TopRight, BottomRight, BottomLeft
            _vertexPositions[3] = new Vector(position.X + halfWidth, position.Y + halfHeight, position.Z);
            _vertexPositions[4] = new Vector(position.X + halfWidth, position.Y - halfHeight, position.Z);
            _vertexPositions[5] = new Vector(position.X - halfWidth, position.Y - halfHeight, position.Z);
        }
    }
}
