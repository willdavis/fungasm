using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Fungasm.Science;

namespace Fungasm.Graphics
{
    public class Text
    {
        Font _font;
        List<CharacterSprite> _bitmapText = new List<CharacterSprite>();
        string _text;

        public List<CharacterSprite> CharacterSprites
        {
            get { return _bitmapText; }
        }
        public Text(string text, Font font, double x, double y)
        {
            _text = text;
            _font = font;
            CreateText(x, y);
        }

        private void CreateText(double x, double y)
        {
            _bitmapText.Clear();
            double currentX = x;
            double currentY = y;

            foreach (char c in _text)
            {
                CharacterSprite sprite = _font.CreateSprite(c);
                float xOffset = ((float)sprite.Data.XOffset) / 2;
                float yOffset = ((float)sprite.Data.YOffset) / 2;
                sprite.Sprite.Position = new Vector(currentX + xOffset, currentY - yOffset, 0);
                currentX += sprite.Data.XAdvance;
                _bitmapText.Add(sprite);
            }
        }
    }
}
